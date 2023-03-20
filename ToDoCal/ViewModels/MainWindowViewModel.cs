using DevExpress.Mvvm;
using System;
using System.Windows.Controls;
using ToDoCal.Services;
using ToDoCal.Views.Pages;

namespace ToDoCal.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly PageService _pageService;
        public Page? PageSource { get; set; }
        public DateTime SelectDate
        {
            get { return GetValue<DateTime>(); }
            set { SetValue(value, changedCallback: ChangePage);}
        }
        public MainWindowViewModel(PageService pageService)
        {
            _pageService = pageService;
            _pageService.onPageChanged += (page) => PageSource = page;
            _pageService.ChangePage(new AllNotes());
        }

        public void ChangePage()
        {
            _pageService.SelectDate = SelectDate;
            _pageService.ChangePage(new SelectedDateNotes());
        }
    }
}
