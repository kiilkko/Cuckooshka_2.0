using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Cuckooshka_2._0
{
    public delegate void loadHandler(Note_ everyNote);
    public delegate int clickedDaysHandler(string _id);
   
    public partial class MainForm : Form
    {
        private event loadHandler OnMFLoad;   

        private Time_watcher timer_Mainf;
        private DB_manager dbManager_Mainf;

        //Список кнопок - кнопка каждого дня недели с кнопками его дел
        private List<Button> MondayList = new List<Button>();
        private List<Button> TuesdayList = new List<Button>();
        private List<Button> WednesdayList = new List<Button>();
        private List<Button> ThursdayList = new List<Button>();
        private List<Button> FridayList = new List<Button>();
        private List<Button> SaturdayList = new List<Button>();
        private List<Button> SundayList = new List<Button>();
        //Массив списков кнопок - дней недели
        private List<Button>[] NotesForAllDays = new List<Button>[7];

        //Массив флагов, какой день недели выбран
        public bool[] ClickedDays = new bool[7];

        public static bool todoClicked;
        //Начальные координаты
        private static int CounterX;
        private static int CounterY;

        private string Key = "";   

        public MainForm()
        {

            InitializeComponent();

            timer_Mainf = new Time_watcher();
            dbManager_Mainf = new DB_manager();
            todoClicked = false;

            //инициализируем списки и массивы
            MondayList.Add(MondayButton);
            TuesdayList.Add(TuesdayButton);
            WednesdayList.Add(WednesdayButton);
            ThursdayList.Add(ThursdayButton);
            FridayList.Add(FridayButton);
            SaturdayList.Add(SaturdayButton);
            SundayList.Add(SundayButton);

            NotesForAllDays[0] = MondayList;
            NotesForAllDays[1] = TuesdayList;
            NotesForAllDays[2] = WednesdayList;
            NotesForAllDays[3] = ThursdayList;
            NotesForAllDays[4] = FridayList;
            NotesForAllDays[5] = SaturdayList;
            NotesForAllDays[6] = SundayList;

            //устанавливаем начальные координаты
            CounterX = MondayButton.Location.X;
            CounterY = MondayButton.Location.Y;

            //подписываем метод создания динамической кнопки на событие ФормыРедактирования
            EditForm.OnApply += CreateToDo;
            EditForm.OnApplyEdition += ChangeToDo;
            OnMFLoad += CreateToDoRestart;
        }

        //метод, создающий динамическую кнопку-заметку
        private void CreateToDo(string todo_id, DateTime todo_time, string todo_text, string todo_cat, string todo_com)
        {
            //определим, какой день выбран
            int clickedDay = WhatDayIsClicked();
            //определяем позицию кнопки           
            Point _location = LocationToDo(clickedDay);

            //создаем кнопку     
            Button todoBut = new Button();
            DrawingToDo(todoBut, todo_time, todo_text);

            todoBut.Location = _location;

            //все другие дни недели должны сдвинуться:
            ChangeCoordinates(todoBut.Height, clickedDay);

            //создаем ID кнопки (имя), хранящее информацию о дне и порядковом номере заметки
            //для корректного порядкового номера нужно проверить в БД максимальный номер
            int todoBut_Number = dbManager_Mainf.Get_MaxID(clickedDay) + 1;
            todoBut.Name = clickedDay + "." + todoBut_Number;
            todo_id = todoBut.Name;

            //добавляем кнопку в список в дне и в БД
            NotesForAllDays[clickedDay].Add(todoBut);
            Note_ todoNote = new Note_() { Id = todo_id, Time = todo_time, ToDo = todo_text, Cathegory = todo_cat, Comment = todo_com };
            dbManager_Mainf.Add_DataBase(todoNote);

            //создаем обработчик клика и добавляем кнопку на панель
            todoBut.Click += new System.EventHandler(TodoBut_Click);
            this.Controls.Add(todoBut);
        }

        //метод, изменяющий данные динамической кнопки-заметки
        private void ChangeToDo(string todo_id, DateTime todo_time, string todo_text, string todo_cat, string todo_com)
        {
            Note_ Note_forChange = dbManager_Mainf.Search_DataBase(Key);
            Note_forChange.Time = todo_time;
            Note_forChange.ToDo = todo_text;
            Note_forChange.Cathegory = todo_cat;
            Note_forChange.Comment = todo_com;

            dbManager_Mainf.Replace_DB(Key, Note_forChange);
            //перезапуск - отрисовать элементы заново.
            Application.Restart();            
        }

        //метод, определяющий положение динамической кнопки-заметки
        private Point LocationToDo(int clickedDay)
        {
            int coord_x = NotesForAllDays[clickedDay][0].Location.X;
            int coord_y = NotesForAllDays[clickedDay][0].Location.Y;
            foreach (Button b in NotesForAllDays[clickedDay])
            {
                coord_y += b.Height;
            }

            return new Point(coord_x, coord_y);
        }

        //метод отрисовки динамической кнопки-заметки на форме
        private void DrawingToDo(Button todoBut, DateTime todo_time, string todo_text)
        {
            todoBut.BringToFront();
            todoBut.Font = new Font("Segoe UI", 10);
            string todo_minute = todo_time.Minute < 10 ? "0" + todo_time.Minute.ToString() : todo_time.Minute.ToString();
            todoBut.Text = todo_time.Hour.ToString() + ":" + todo_minute + " " + todo_text;
            todoBut.TextAlign = ContentAlignment.MiddleLeft;
            todoBut.BackColor = Color.WhiteSmoke;
            todoBut.ForeColor = Color.DimGray;
            todoBut.FlatStyle = FlatStyle.Flat;
            todoBut.FlatAppearance.BorderColor = Color.White;
            todoBut.Size = new Size(MondayButton.Width, MondayButton.Height);
        }

        //метод, отвечающий за сдвиг всех кнопок после появления новой заметки
        private void ChangeCoordinates(int changing, int clickedDay)
        {
            for (int i = clickedDay + 1; i < NotesForAllDays.Length; i++)
            {

                for (int b = 0; b < NotesForAllDays[i].Count; b++)
                {
                    int newYcoord = (NotesForAllDays[i][b].Location.Y + changing);
                    NotesForAllDays[i][b].Location = new Point(NotesForAllDays[i][b].Location.X, newYcoord);
                }
            }
            for (int i = 0; i < ClickedDays.Length; i++)
            {
                ClickedDays[i] = false;
            }
        }

        //метод, отрисовывающий все кнопки заново после перезагрузки
        public void CreateToDoRestart(Note_ existingNote)
        {
            int clickedDay = GetClickedDay(existingNote.Id);
            Point _location = LocationToDo(clickedDay);

            //создаем кнопку     
            Button todoBut = new Button();
            DrawingToDo(todoBut, existingNote.Time, existingNote.ToDo); //из свойств Note_
            todoBut.Location = _location;
            //нужно заново присвоить кнопке ID, вытащив его из данных в БД
            todoBut.Name = existingNote.Id;
            //все другие дни недели должны сдвинуться:
            ChangeCoordinates(todoBut.Height, clickedDay);

            NotesForAllDays[clickedDay].Add(todoBut);

            //создаем обработчик клика и добавляем кнопку на панель
            todoBut.Click += new System.EventHandler(TodoBut_Click);
            this.Controls.Add(todoBut);
        }

        //метод, выводящий на форму события на сегодняшний день
        public void PrintNotes(List<Note_>[] loadingL, List<string> todayL)
        {
            string minute = "";
            foreach (var d in loadingL[timer_Mainf.DayNumberNow()])
            {
                minute = d.Time.Minute < 10 ? "0" + d.Time.Minute.ToString() : d.Time.Minute.ToString();
                if (d.Comment.Equals("") || d.Comment.Equals(" "))
                {
                    todayL.Add(d.Time.Hour.ToString() + ":" + minute + " " + d.ToDo + "\n");
                }
                else
                {
                    todayL.Add(d.Time.Hour.ToString() + ":" + minute + " " + d.ToDo + "\n" + d.Comment + "\n");
                }
            }
        }

        #region Вспомогательные методы

        //метод, определяющий, какой день выбран
        private int WhatDayIsClicked()
        {
            int clickedDay = 0;
            for (int i = 0; i < ClickedDays.Length; i++)
            {
                if (ClickedDays[i] == true)
                {
                    clickedDay = i;
                }
            }
            return clickedDay;
        }

        //метод, определяющий, какая заметка выбрана
        private int WhatNoteIsClicked(List<Button>[] _days, out int clickedDay)
        {
            int clickedNote = 0;
            clickedDay = 0;
            for (int i = 0; i < _days.Length; i++)
            {
                for (int j = 1; j < _days[i].Count; j++)
                {
                    if (todoClicked == true)
                    {
                        clickedNote = j;
                        clickedDay = i;
                    }
                }
            }
            return clickedNote;
        }

        //метод, возвращающий номер дня по ID заметки
        public int GetClickedDay(string noteID)
        {
            string temp = "";
            for (int i = 0; i < noteID.Length; i++)
            {
                if (noteID[i].Equals('.'))
                {
                    break;
                }
                else
                {
                    temp += noteID[i];
                }
            }
            int result = Int32.Parse(temp);
            return result;
        }

#endregion

        #region Обработчики событий       

        //обработка клика по динамической кнопке
        private void TodoBut_Click(object sender, EventArgs e)
        {
            todoClicked = true;

            //вытаскиваем ID кликнутой кнопки (значение поля Name)          
            Type MyType = sender.GetType();
            PropertyInfo[] propMas = MyType.GetProperties();
            foreach (PropertyInfo pr in propMas)
            {
                if (pr.Name.Equals("Name"))
                {
                    Key = pr.GetValue(sender).ToString();

                }
            }            
    
            EditForm edition = new EditForm();
            
            edition.Text = Key + "_редактирование";
            edition.Show();
        }

        //обработка кликов по кнопкам дней
        private void MondayButton_Click(object sender, EventArgs e)
        {
            ClickedDays[0] = true;
           
            EditForm edition = new EditForm();
            edition.Show();
        }
        private void TuesdayButton_Click(object sender, EventArgs e)
        {
            ClickedDays[1] = true;
            
            EditForm edition = new EditForm();
            edition.Show();
        }
        private void WednesdayButton_Click(object sender, EventArgs e)
        {
            ClickedDays[2] = true;

            EditForm edition = new EditForm();
            edition.Show();
        }
        private void ThursdayButton_Click(object sender, EventArgs e)
        {
            ClickedDays[3] = true;

            EditForm edition = new EditForm();
            edition.Show();
        }
        private void FridayButton_Click(object sender, EventArgs e)
        {
            ClickedDays[4] = true;

            EditForm edition = new EditForm();
            edition.Show();
        }
        private void SaturdayButton_Click(object sender, EventArgs e)
        {
            ClickedDays[5] = true;

            EditForm edition = new EditForm();
            edition.Show();
        }
        private void SundayButton_Click(object sender, EventArgs e)
        {
            ClickedDays[6] = true;

            EditForm edition = new EditForm();
            edition.Show();
        }
        

        //обработка события загрузки главной формы
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (OnMFLoad != null)
            {
                //получаем отсортированную по времени выборку Note_ из БД
                List<Note_>[] loadingList = dbManager_Mainf.Sort_Notes();

                foreach (var dayNotes in loadingList)
                {
                    foreach (Note_ n in dayNotes)
                    {
                        OnMFLoad(n);
                    }

                }

                List<string> todayList = new List<string>();
                PrintNotes(loadingList, todayList);
                string[] todayArray = todayList.ToArray();
                this.TodayListTextBox.Lines = todayArray;

                //запуск таймера напоминания для заметки
                timer_Mainf.Remind();  
            }
        }

#endregion
        
    }
}


    



