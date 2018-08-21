using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Cuckooshka_2._0
{
    public delegate void ChangesHandler(string _id, DateTime _time, string _text, string cat, string comment);
    public delegate void DataLoader(string id);

    public partial class EditForm : Form
    {
        public static event ChangesHandler OnApply;
        public static event ChangesHandler OnApplyEdition;
        private event DataLoader OnLoadEditf;

        private DB_manager dbManager_Editf;

        private string ToDoId = "";

        public EditForm()
        {
            InitializeComponent();
            cat_comboBox.SelectedItem = cat_comboBox.Items[0];
            //флаг todoclicked показывает, была ли заметка открыта для редактирования или она только еще создается 
            if(MainForm.todoClicked == false)
            {
                //чекбокс "Неактуально, удалить" не нужен при создании
                this.Done_checkBox.Visible = false;
            }
            dbManager_Editf = new DB_manager();
            OnLoadEditf += LoadData;
        }
        
        private void LoadData(string id)
        {
            Note_ tempNote = dbManager_Editf.Search_DataBase(id);
            todo_textBox.Text = tempNote.ToDo;
            numericUpDown1.Value = tempNote.Time.Hour;
            numericUpDown2.Value = tempNote.Time.Minute;
           
            for (int i=0; i< cat_comboBox.Items.Count; i++)
            {
                if (cat_comboBox.Items[i].Equals(tempNote.Cathegory))
                {
                    cat_comboBox.SelectedItem = cat_comboBox.Items[i].ToString();
                }
            }
        }

        private string GetID(string IDText)
        {
            string ID = "";


            for (int i = 0; i < IDText.Length; i++)
            {
                char x = IDText[i];
                if (x.Equals('_'))
                {
                    break;
                }
                else
                {
                    ID += x;
                }

            }
            return ID;
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            string ToDo_text = todo_textBox.Text;
            string ToDo_Cat = cat_comboBox.SelectedItem.ToString();
            string ToDo_Comment = CommentBox.Text;

            DateTime ToDo_time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Int32.Parse(numericUpDown1.Value.ToString()), Int32.Parse(numericUpDown2.Value.ToString()), 0);

            if (OnApply != null && MainForm.todoClicked == false)
            {
                OnApply(ToDoId, ToDo_time, ToDo_text, ToDo_Cat, ToDo_Comment);
                Application.Restart();
            }
            else if (OnApplyEdition != null)
            {
                ToDoId = GetID(this.Text);

                if (Done_checkBox.Checked == true)
                {
                    dbManager_Editf.Remove_Note(ToDoId);
                    Application.Restart();
                }
                else
                {
                    OnApplyEdition(ToDoId, ToDo_time, ToDo_text, ToDo_Cat, ToDo_Comment);
                   
                }

                MainForm.todoClicked = false;
            }
           
            this.Close();
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            if (OnLoadEditf != null && MainForm.todoClicked == true)
            {
                ToDoId = GetID(this.Text);
                OnLoadEditf(ToDoId);
            }
        }



        
    }
}
