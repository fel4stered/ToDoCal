using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.ApplicationServices;
using System.Windows.Markup;
using Newtonsoft.Json;

namespace ToDoCal.Models
{
    public class Note
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public bool Is_Task { get; set; } // Является ли задачей 
        public string Stat_Task { get; set; }

        public static List<Note> GetNotesFromFile()
        {
            string filedata = File.ReadAllText(@"C:\Users\Viksy\Source\Repos\fel4stered\ToDoCal\ToDoCal\Data\task.json");
            List<Note> notes = JsonConvert.DeserializeObject<List<Note>>(filedata);
            return notes;
        }
      
        public static void SaveNoteToFile(Note note)
        {
            List<Note>notes = GetNotesFromFile();
            notes.Add(note);
            string SerializedNotes = JsonConvert.SerializeObject(notes, Formatting.Indented);
            File.WriteAllText(@"C:\Users\Viksy\Source\Repos\fel4stered\ToDoCal\ToDoCal\Data\task.json", SerializedNotes);

        }

        public static void SaveNoteToFile(List<Note> notes)
        {
            string SerializedNotes = JsonConvert.SerializeObject(notes, Formatting.Indented);
            File.WriteAllText(@"C:\Users\Viksy\Source\Repos\fel4stered\ToDoCal\ToDoCal\Data\task.json", SerializedNotes);

        }
        public static void Delete_Note(Note note)
        {
            List<Note> notes = GetNotesFromFile();
            notes.Remove(note);
            SaveNoteToFile(notes);
        }
        public static void Edit_Note(Note note,string titleNote, string descriptionNote, string dateNote, string statusNote)
        {
            List<Note> notes = GetNotesFromFile();
            foreach (Note note_Edit in notes)
            {
                if (note_Edit.Id == note.Id)
                {

                    note_Edit.Name = titleNote == null ? note_Edit.Name : titleNote;
                    note_Edit.Description = descriptionNote == null ? note_Edit.Description : descriptionNote;
                    note_Edit.Date = dateNote == null ? note_Edit.Date : dateNote;
                    note_Edit.Stat_Task = statusNote == null ? note_Edit.Stat_Task : statusNote;

                }
            }
            SaveNoteToFile(notes);
        }
        public static bool Task_On_One_Date(string date)
        {
            List<Note> notes = GetNotesFromFile();
            int count = 0 ;
            foreach (Note note in notes)
            {
                if (note.Date == date)
                {
                    count++;
                }
            }
            if (count <= 5)
            {
                return true;
            }
            else { return false; }
        }
        public static uint Get_Id_To_New()
        {
            uint count;
            List<Note> notes = GetNotesFromFile();
            if(notes.Count == 0)
            {
                count = 1;
            }
            else
            {
                count = (uint)notes[notes.Count - 1].Id;
               
            }
            return count;
        }
    }
}