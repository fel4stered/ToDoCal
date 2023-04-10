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
using System.Text.RegularExpressions;

namespace ToDoCal.ViewModels
{

    public class AddNoteViewModel
    {
        private readonly PageService _pageService;
        public string Title { get; set; }
        public string Description { get; set; }
        public string TypeNote { get; set; }
        public DateTime DateSelect { get; set; } = DateTime.Now;
        public string TextDate { get; set; }
        public DateTime result;
        public string patern;
        public AddNoteViewModel(PageService pageService)
        {
            _pageService = pageService;
            TextDate = DateSelect.ToShortDateString();
            patern = @"[a-zа-яё\s]";

        }
        public ICommand AddNote
        {
            
            get
            {
                return new DelegateCommand(() =>
                {
                    Note note = new Note();
                    note.Id = Note.Get_Id_To_New() + 1;
                    note.Name = Title;
                    note.Description = Description;
                    note.Date = DateSelect.ToShortDateString();
                    if(TypeNote == "Задача") 
                    {
                        note.Is_Task = true;
                        note.Stat_Task = "В процесcе";
                    }
                    else
                    {
                        note.Is_Task = false;
                        note.Stat_Task = "";


                    }
                    Note.SaveNoteToFile(note);
                    _pageService.ChangePage(new AllNotes());
                } , bool () => (!string.IsNullOrWhiteSpace(Title) && !Regex.IsMatch(Title, @"[~`!@#$%^&*()+=|\\{}':;.,<>/?[\]""_-]") && !string.IsNullOrWhiteSpace(Description) && DateTime.TryParse(TextDate,out result) ));
                                


               
            }
        }

    }
}
