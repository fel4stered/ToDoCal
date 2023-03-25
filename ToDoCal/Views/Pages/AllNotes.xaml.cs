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
using ToDoCal.ViewModels;

namespace ToDoCal.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для AllNotes.xaml
    /// </summary>
    public partial class AllNotes : Page
    {
        public AllNotes()
        {
            InitializeComponent();
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var vm = (AllNotesViewModel)this.DataContext;
            vm.SelectedNotePageCommand.Execute(null);
        }
    }
}
