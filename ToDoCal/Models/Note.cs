using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ToDoCal.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public bool Is_Task { get; set; } // Является ли задачей 
        public string Stat_Task { get; set; }

        public static List<Note> GetNotesFromFile()
        {
            string filedata = File.ReadAllText(@"Data\task.json");
            List<Note> notes = JsonConvert.DeserializeObject<List<Note>>(filedata);
            return notes;
        }
      
        public static void SaveNoteToFile(Note note)
        {
            List<Note>notes = GetNotesFromFile();
            notes.Add(note);
            string SerializedNotes = JsonConvert.SerializeObject(notes, Formatting.Indented);
            File.WriteAllText(@"Data\task.json", SerializedNotes);

        }

        public static void SaveNoteToFile(List<Note> notes)
        {
            string SerializedNotes = JsonConvert.SerializeObject(notes, Formatting.Indented);
            File.WriteAllText(@"Data\task.json", SerializedNotes);

        }
        public static void Delete_Note(Note note)
        {
            List<Note> notes = GetNotesFromFile();
            notes.Remove(note);
            SaveNoteToFile(notes);
        }
        public static void Edit_Note(Note note)
        {
            List<Note> notes = GetNotesFromFile();
            foreach (Note note_Edit in notes)
            {
                if (note_Edit.Id == note.Id)
                {
                    notes.Remove(note_Edit);
                    notes.Add(note);
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
    }
}