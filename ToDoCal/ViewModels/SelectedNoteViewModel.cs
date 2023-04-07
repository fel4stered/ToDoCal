using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoCal.Models;
using ToDoCal.Services;
using ToDoCal.Views.Pages;
using System.Text.RegularExpressions;

namespace ToDoCal.ViewModels
{
    public class SelectedNoteViewModel
    {
        public string DisplayTitle { get; set; }
        public string DisplayDate { get; set;  }
        public string DisplayStatus { get; set; }
        public string DisplayIsTask { get; set; }
        public string DisplayText { get; set; }
        public string StartTitle { get; set; }
        public string StartText { get; set; }
        public Note Note { get; set; }
        private readonly PageService _pageService;
        public SelectedNoteViewModel(NoteService noteService, PageService pageService)
        {
            Note = noteService.Note;
            DisplayTitle = Note.Name; DisplayDate = Note.Date;
            DisplayStatus = Note.Stat_Task;
            StartTitle = Note.Name;
            StartText = Note.Description;
            if (Note.Is_Task)
            {
                DisplayIsTask = "Задача";
            }
            else DisplayIsTask = "Заметка";
            DisplayText = Note.Description;
            _pageService = pageService;
        }
        public ICommand AddNotePageCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    bool istask;
                    if (DisplayIsTask == "Задача")
                    {
                        istask = true;
                    }
                    else istask = false;
                    Note.Edit_Note(Note, DisplayTitle, DisplayText, DisplayDate, DisplayStatus);
                    _pageService.ChangePage(new AllNotes());
                }, bool () => !string.Equals(StartTitle,DisplayTitle) || !string.Equals(StartText,DisplayText) && Regex.IsMatch(DisplayTitle, @"[А-я]") && !string.IsNullOrWhiteSpace(DisplayTitle) && !string.IsNullOrWhiteSpace(DisplayText));
            }
        }

    }
}
