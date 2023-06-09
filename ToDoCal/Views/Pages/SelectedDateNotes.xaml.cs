﻿using System;
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
    /// Логика взаимодействия для SelectedDateNotes.xaml
    /// </summary>
    public partial class SelectedDateNotes : Page
    {
        public SelectedDateNotes()
        {
            InitializeComponent();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            NavigationService.Navigate(new AllNotes());
        }
        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var vm = (SelectedDateNotesViewModel)this.DataContext;
            vm.SelectedNotePageCommand.Execute(null);
        }
    }
}
