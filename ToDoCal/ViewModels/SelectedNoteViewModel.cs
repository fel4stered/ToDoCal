using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoCal.Models;
using ToDoCal.Services;

namespace ToDoCal.ViewModels
{
    public class SelectedNoteViewModel
    {
        public string DisplayTitle { get; set; }
        public string DisplayDate { get; set;  }
        public string DisplayStatus { get; set; }
        public string DisplayIsTask { get; set; }
        public string DisplayText { get; set; }
        public Note Note { get; set; }
        public SelectedNoteViewModel(NoteService noteService)
        {
            Note = noteService.Note;
            DisplayTitle = Note.Name; DisplayDate = Note.Date;
            DisplayStatus = Note.Stat_Task;
            if (Note.Is_Task)
            {
                DisplayIsTask = "Задача";
            }
            else DisplayIsTask = "Заметка";
            DisplayText = Note.Description;
        }

    }
}
