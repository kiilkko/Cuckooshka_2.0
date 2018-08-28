using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cuckooshka_2._0
{
    public delegate void TimeComesHandler(object sender, EventArgs e);
    public class Time_watcher
    {
        //экземпляр класса, отвечающего за связь с БД
        private DB_manager dbManager_;
        private Dictionary<string, int> _dayNames;

        public Time_watcher()
        {
            dbManager_ = new DB_manager();
            Timer timer = new Timer();
            _dayNames = new Dictionary<string, int>() { { "Monday", 0 }, { "Tuesday", 1 }, { "Wednesday", 2 }, { "Thursday", 3 }, { "Friday", 4 }, { "Sunday", 5 }, { "Saturday", 6 } };
        }
        
        //метод получает из БД выборку записей на текущую дату, перебирает, и если время записи совпадает с текущим, выдает сообщение
        public void Remind ()
        {
            List<Note_> notesToday = dbManager_.Select_all_Notes_at_Day(DayNumberNow());
           
            for (int i = 0; i < notesToday.Count; i++)
            {
                Note_ currentNote = notesToday[i];
                if (currentNote.Time.TimeOfDay >= DateTime.Now.TimeOfDay)
                {
                    Timer timeBeforeEvent = new Timer();
                    TimeComesHandler time_handler = (sender, e) =>
                    {
                        MessageBox.Show("Время выполнить:\n" + currentNote.Time.TimeOfDay + " " + currentNote.ToDo + " \n" + currentNote.Comment);
                        timeBeforeEvent.Stop();
                    };
                    TimeSpan tSpan = currentNote.Time.TimeOfDay.Subtract(DateTime.Now.TimeOfDay);
                    timeBeforeEvent.Tick += new EventHandler(time_handler);
                    timeBeforeEvent.Interval = TransformDateToMillisec(tSpan);
                    timeBeforeEvent.Start();
                }
                else
                {
                    MessageBox.Show("Просрочено!\n" + currentNote.Time.TimeOfDay + " " + currentNote.ToDo + " \n" + currentNote.Comment);
                }
            }
        }

        
        private int TransformDateToMillisec(TimeSpan span)
        {
            int result = span.Milliseconds + span.Seconds * 1000 + span.Minutes * 1000 * 60 + span.Hours * 1000 * 3600;
            return result;
        }

       public int DayNumberNow()
        {
            string day = DateTime.Now.DayOfWeek.ToString();
            
            int dayNumber = _dayNames[day];
            return dayNumber;
        }

    }

    
}
