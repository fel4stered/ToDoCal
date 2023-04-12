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
using ToDoCal.Views.Pages;

namespace ToDoCal.Views
{
    /// <summary>
    /// Логика взаимодействия для AddNote.xaml
    /// </summary>
    public partial class AddNote : Page
    {
        public AddNote()
        {
            InitializeComponent();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            NavigationService.Navigate(new AllNotes());
        }
    }
}
