using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoCal.Models;
using ToDoCal.Services;
using ToDoCal.Views;
using ToDoCal.Views.Pages;
using DevExpress;
using DevExpress.Xpf.Core;
using DevExpress.Mvvm.UI;
using System.Windows;

namespace ToDoCal.ViewModels
{
    public class AllNotesViewModel : ViewModelBase
    {

        private readonly PageService _pageService;
        private NoteService NoteService;
        public Note SelectNote { get; set; }
        public List<Note> notes { get; set; }
        public List<string> CB1 { get; set; } = new List<string> { "Все", "Заметки", "Задачи" };
        public List<string> CB2 { get; set; } = new List<string> { "Все","В процесcе","Выполнено" ,"Брошено" };
        public string CB1_item
        {
            get { return GetValue<string>(); }
            set { SetValue(value, changedCallback : FiltNote); }
        }
        public string CB2_item
        {
            get { return GetValue<string>(); }
            set { SetValue(value, changedCallback: FiltNote); }
        }


        public AllNotesViewModel(PageService pageService, NoteService  noteService)
        {
            _pageService = pageService;
            NoteService = noteService;
            UpdateNotes();
           
        }

        public void UpdateNotes()
        {
            notes = Note.GetNotesFromFile();
        }
        public void FiltNote()
        {
            List<Note> notesf = Note.GetNotesFromFile();
           if (!string.IsNullOrEmpty(CB1_item))
            {
               if (CB1_item == "Заметки")
                {
                    notesf = notesf.Where(predicate => predicate.Is_Task == false).ToList();
                }
               else if (CB1_item == "Задачи")
                {
                    notesf = notesf.Where(predicate => predicate.Is_Task == true).ToList();
                }
                else { };
            }
            if (!string.IsNullOrEmpty(CB2_item))
            {
                switch (CB2_item)
                {
                    case "Все":
                        break;
                    case "В процесcе":
                        notesf = notesf.Where(predicate => predicate.Stat_Task == CB2_item).ToList();
                        break;
                    case "Брошено":
                        notesf = notesf.Where(predicate => predicate.Stat_Task == CB2_item).ToList();
                        break;
                    case "Выполнено":
                        notesf = notesf.Where(predicate => predicate.Stat_Task == CB2_item).ToList();
                        break;
                }
                
          
            }
            notes = notesf;
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
        public ICommand Ch1
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (SelectNote.Is_Task)
                    {
                        Note.Edit_Note(SelectNote, null, null, null, "В процесcе");
                        UpdateNotes();
                    }
                    
                });
            }
        }
        public ICommand Ch2
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (SelectNote.Is_Task)
                    {
                        Note.Edit_Note(SelectNote, null, null, null, "Выполнено");
                        UpdateNotes();
                    }
                    

                });
            }
        }
        public ICommand Ch3
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (SelectNote.Is_Task)
                    {
                        Note.Edit_Note(SelectNote, null, null, null, "Брошено");
                        UpdateNotes();
                    }
                    

                });
            }
        }
        public ICommand Ch4
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if(MessageBox.Show( "Вы точно хотите удалить заметку", "Подтвержение", MessageBoxButton.YesNo, MessageBoxImage.Information)==MessageBoxResult.Yes)
                    {

                        Note.Delete_Note(SelectNote);
                        UpdateNotes();
                    }
                    


                });
            }
        }

        public ICommand SelectedNotePageCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    NoteService.Note = SelectNote;
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
