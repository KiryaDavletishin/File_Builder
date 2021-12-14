using System;
using System.Collections.Generic;
using System.IO;

namespace File_Builder
{
    struct Note
    {
        public String Text;
        public String Name;
        public DateTime Date;
    }

    public class NoteStorage
    {
        private List<Note> NoteList;

        public void ReadFromDisk(String path)
        {
            try
            {
                using StreamReader stream = new(path);
                for (int counter = 0; stream.EndOfStream; counter++)
                {
                    Note not = new();
                    not.Text = stream.ReadLine();
                    not.Name = stream.ReadLine();
                    not.Date = Convert.ToDateTime(stream.ReadLine());
                    NoteList.Add(not);
                }
            }
            catch (FileNotFoundException)
            {
                File.Create(path);
            }
        }
        public void SaveOnDisk(String path)
        {
            using StreamWriter stream = new(path, true);
            stream.WriteLine(NoteList[NoteList.Count - 1].Text);
            stream.WriteLine(NoteList[NoteList.Count - 1].Name);
            stream.WriteLine(Convert.ToString(NoteList[NoteList.Count - 1].Date));
        }
    }
}
