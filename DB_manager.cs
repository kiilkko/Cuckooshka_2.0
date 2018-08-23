using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuckooshka_2._0
{
    public class DB_manager
    {
        public DB_manager()
        { }

        public int CheckNotesAtDay (int dayNumber)
        {
            using (CuckooEntities ce = new CuckooEntities())
            {
                var all_Notes = ce.Note_.Where(p => p.Id.StartsWith("" + dayNumber + "."));
                int x = all_Notes.Count();
                return x;
            }
        }

        public List<Note_> Select_all_Notes ()
        {
            using (CuckooEntities ce = new CuckooEntities())
            {
                List<Note_> nList = new List<Note_>();
                var all_Notes = ce.Note_;                
                foreach(Note_ n in all_Notes)
                {
                    nList.Add(n);
                }
                return nList;
            }
        }

        public List<Note_> Select_all_Notes_at_Day(int dayNumber)
        {
            using (CuckooEntities ce = new CuckooEntities())
            {
                List<Note_> nList = new List<Note_>();
                var all_Notes = ce.Note_.Where(y => y.Id.StartsWith("" + dayNumber + "."));
                foreach (Note_ n in all_Notes)
                {
                    nList.Add(n);
                }
                return nList;
            }
        }

        public List<Note_> [] Sort_Notes()
        {
            using (CuckooEntities ce = new CuckooEntities())
            {
                List<Note_>[] allNotes = new List<Note_>[7]; 
                for(int i=0; i<allNotes.Length;i++)
                {
                    allNotes[i] = new List<Note_>();
                }

                for (int i=0; i<7; i++)
                {
                    var dayNotes = ce.Note_.Where(e => e.Id.StartsWith(i.ToString()))
                                           .OrderBy(s => s.Time.Hour)
                                           .ThenBy(s => s.Time.Minute);

                    foreach (var n in dayNotes)
                    {
                        allNotes[i].Add(n);
                    }
                }
                return allNotes;
            }
        }
        
        public void Add_DataBase(Note_ newNote)
        {
            using (CuckooEntities ce = new CuckooEntities())
            {
                ce.Note_.Add(newNote);
                ce.SaveChanges();
            }

        }

        public Note_ Search_DataBase(string ID)
        {
            using (CuckooEntities ce = new CuckooEntities())
            {
                Note_ found = ce.Note_.Find(ID);
                return found;
            }
            
        }


        public void Remove_Note(string ID)
        {
            using (CuckooEntities ce = new CuckooEntities())
            {
                Note_ found = ce.Note_.Find(ID);
                ce.Note_.Remove(found);
                
                ce.SaveChanges();
            }

        }

        public int Get_MaxID(int dayNumber)
        {
            using (CuckooEntities ce = new CuckooEntities())
            {
                int maxID = 0;

                if (CheckNotesAtDay(dayNumber)==0)
                {
                    maxID = -1;
                }
                else
                {
                    
                    var allIDs = ce.Note_;
                    List<int> numberList = new List<int>();
                    foreach(Note_ n in allIDs)
                    {
                        numberList.Add(Int32.Parse(n.Id.Substring(2)));
                    }
                    if (numberList != null)
                    {
                        numberList.Sort();
                        maxID = numberList[numberList.Count-1];
                    }
                    
                }
                

                return maxID;

                
            }

        }

        public void Replace_DB(string ID, Note_ newNote)
        {
            using (CuckooEntities ce = new CuckooEntities())
            {
                Note_ note = Search_DataBase(ID);
                if(note != null)
                {
                    ce.Note_.Attach(note);
                    note.Time = newNote.Time;
                    note.ToDo = newNote.ToDo;
                    note.Cathegory = newNote.Cathegory;
                    note.Comment = newNote.Comment;                
                    ce.SaveChanges();
                }
                
            }
        }
    }
}
