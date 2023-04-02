using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoCal.Models;
using ToDoCal.Services;

namespace ToDoCal.ViewModels
{
    public class SelectedDateNotesViewModel : BindableBase
    {
        public DateTime SelectDate { get; set; }
        public string SelectDateFormater { get { return SelectDate.ToLongDateString(); } set { SelectDateFormater = value; } }
        private readonly PageService _pageService;
        public List<Note> notes { get; set; }

        public SelectedDateNotesViewModel(PageService pageService)
        {
            _pageService = pageService;
            SelectDate = _pageService.SelectDate;
            notes = Note.GetDateNotes(SelectDate.ToShortDateString()); 
        }
    }
}
