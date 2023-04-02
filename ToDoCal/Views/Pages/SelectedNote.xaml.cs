using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToDoCal.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для SelectedNote.xaml
    /// </summary>
    public partial class SelectedNote : Page
    {
        public SelectedNote()
        {
            InitializeComponent();
        }

        private void TitleTextBox_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TitleTextBox.IsReadOnly = false;
        }

        private void DateTextBox_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DateTextBox.IsReadOnly = false;
        }

        private void DescriptionTextBox_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DescriptionTextBox.IsReadOnly = false;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            NavigationService.Navigate(new AllNotes());
        }
    }
}
