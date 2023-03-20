using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoCal.Services;

namespace ToDoCal.ViewModels
{
    public class SelectedDateNotesViewModel : BindableBase
    {
        public DateTime SelectDate { get; set; }
        public string SelectDateFormater { get { return SelectDate.ToShortDateString(); } set { SelectDateFormater = value; } }
        private readonly PageService _pageService;

        public SelectedDateNotesViewModel(PageService pageService)
        {
            _pageService = pageService;
            SelectDate = _pageService.SelectDate;
        }
    }
}
