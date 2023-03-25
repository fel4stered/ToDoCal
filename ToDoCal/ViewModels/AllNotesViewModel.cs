using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoCal.Services;
using ToDoCal.Views;
using ToDoCal.Views.Pages;

namespace ToDoCal.ViewModels
{
    public class AllNotesViewModel
    {
        private readonly PageService _pageService;


        public AllNotesViewModel(PageService pageService)
        {
            _pageService = pageService;
        }

        public ICommand AddNotePageCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _pageService.ChangePage(new AddNote());
                });
            }
        }

        public ICommand SelectedNotePageCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    SelectedNotePage();
                });
            }
        }

        public void SelectedNotePage()
        {
            _pageService.ChangePage(new SelectedNote());
        }
    }
}
