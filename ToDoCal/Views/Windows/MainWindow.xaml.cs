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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!fix)
            {
                if (e.ChangedButton == MouseButton.Left) this.DragMove();
            }
            else
            {
                e.Handled = true;
            }
        }

        #region HideVisBorderButtonPropertyChange
        private void BorderLeft_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (BorderLeft.IsVisible)
            {
                BorderRight.CornerRadius = new CornerRadius(0, 20, 20, 0);
                
            }
            else
            {
                BorderRight.CornerRadius = new CornerRadius(20);
                
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

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Cal.DisplayDate = DateTime.Now;
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        private const int GWL_EX_STYLE = -20;
        private const int WS_EX_APPWINDOW = 0x00040000, WS_EX_TOOLWINDOW = 0x00000080;

        bool fix = false;
        private void FixButton_Click(object sender, RoutedEventArgs e)
        {
            if (!fix)
            {
                
                ImageForFixButton.Data = Geometry.Parse("M14.707031,2.2929688L13.292969,3.7070312 14.388672,4.8027344 8.1894531,9.7753906 6.7070312,8.2929688 5.2929688,9.7070312 9.09375,13.507812 3,19.599609 3,21 4.4003906,21 10.492188,14.90625 14.292969,18.707031 15.707031,17.292969 14.310547,15.896484 19.214844,9.6289062 20.292969,10.707031 21.707031,9.2929688 14.707031,2.2929688z");
                fix = true;
            }
            else
            {
                ImageForFixButton.Data = Geometry.Parse("M14.707031,2.2929688L13.292969,3.7070312 14.388672,4.8027344 8.1894531,9.7753906 6.7070312,8.2929688 5.2929688,9.7070312 9.09375,13.507812 3,19.599609 3,21 4.4003906,21 10.492188,14.90625 14.292969,18.707031 15.707031,17.292969 14.310547,15.896484 19.214844,9.6289062 20.292969,10.707031 21.707031,9.2929688 14.707031,2.2929688z M15.798828,6.2363281L17.779297,8.2167969 12.976562,14.359375 9.7246094,11.107422 15.798828,6.2363281z");
                fix = false;
            }
        }

        void FormLoaded(object sender, RoutedEventArgs args)
        {
            //Variable to hold the handle for the form
            var helper = new WindowInteropHelper(this).Handle;
            //Performing some magic to hide the form from Alt+Tab
            SetWindowLong(helper, GWL_EX_STYLE, (GetWindowLong(helper, GWL_EX_STYLE) | WS_EX_TOOLWINDOW) & ~WS_EX_APPWINDOW);

        }
    }
}
