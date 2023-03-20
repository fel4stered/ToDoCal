using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToDoCal.Views.Pages;

namespace ToDoCal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region AltTab
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr window, int index, int value);

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr window, int index);

        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_TOOLWINDOW = 0x00000080;

        public static void HideFromAltTab(IntPtr Handle)
        {
            SetWindowLong(Handle, GWL_EXSTYLE, GetWindowLong(Handle, GWL_EXSTYLE) | WS_EX_TOOLWINDOW);
        }
        private IntPtr Handle
        {
            get
            {
                return new WindowInteropHelper(this).Handle;
            }
        }

        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(int hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        public const int HWND_BOTTOM = 0x1;
        public const uint SWP_NOSIZE = 0x1;
        public const uint SWP_NOMOVE = 0x2;
        public const uint SWP_SHOWWINDOW = 0x40;

        private void ShoveToBackground()
        {
            SetWindowPos((int)this.Handle, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HideFromAltTab(Handle);
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            ShoveToBackground();
        }
        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) this.DragMove();
        }

        #region HideVisBorderButtonPropertyChange
        private void BorderLeft_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (BorderLeft.IsVisible)
            {
                BorderRight.CornerRadius = new CornerRadius(0, 20, 20, 0);
                Grid.SetColumn(HideVisBorderButton, 0);
                ImageForHideVisBorderButton.Data = Geometry.Parse("M4,24C4,35.028 12.972,44 24,44 35.028,44 44,35.028 44,24 44,12.972000000000001 35.028,4 24,4 12.972000000000001,4 4,12.972 4,24z M29.061,24.561L21.061,32.561C20.768,32.854 20.384,33 20,33 19.616,33 19.232,32.854 18.939,32.561 18.353,31.975 18.353,31.026 18.939,30.44L25.878,23.501 18.939,16.562C18.353,15.976 18.353,15.027000000000001 18.939,14.441 19.525,13.855 20.474,13.855 21.06,14.441L29.06,22.441000000000003C29.646,23.025,29.646,23.975,29.061,24.561z");
                ImageForHideVisBorderButton.Fill = Brushes.White;
            }
            else
            {
                BorderRight.CornerRadius = new CornerRadius(20);
                Grid.SetColumn(HideVisBorderButton, 1);
                ImageForHideVisBorderButton.Data = Geometry.Parse("M24,44C35.028,44 44,35.028 44,24 44,12.972000000000001 35.028,4 24,4 12.972000000000001,4 4,12.972 4,24 4,35.028 12.972,44 24,44z M17.439,22.439L25.439,14.439C26.025,13.853 26.974,13.853 27.56,14.439 28.145999999999997,15.025 28.145999999999997,15.974 27.56,16.56L20.621,23.5 27.56,30.439C28.145999999999997,31.025 28.145999999999997,31.974 27.56,32.56 27.268,32.854 26.884,33 26.5,33 26.116,33 25.732,32.854 25.439,32.561L17.439,24.561C16.854,23.975,16.854,23.025,17.439,22.439z");
                var converter = new System.Windows.Media.BrushConverter();
                ImageForHideVisBorderButton.Fill = (Brush)converter.ConvertFromString("#9E30C5");
            }
        }

        private void HideVisBorderButton_Click(object sender, RoutedEventArgs e)
        {
            if (BorderLeft.IsVisible) BorderLeft.Visibility = Visibility.Hidden;
            else BorderLeft.Visibility = Visibility.Visible;
        }
        #endregion

        private void myNotifyIcon_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
