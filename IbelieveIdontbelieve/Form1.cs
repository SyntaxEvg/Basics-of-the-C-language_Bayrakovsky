using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using IbelieveIdontbelieve.Service;
using System.IO;
using System.Web;
using System.Text.Json;

namespace IbelieveIdontbelieve
{
    /// <summary>
    /// 1. С помощью рефлексии выведите все свойства структуры DateTime.
//2.а) Создать приложение, показанное на уроке, добавив в него защиту от возможных ошибок(не создана база данных, обращение к несуществующему вопросу, открытие слишком большого файла и т.д.).
//б) Изменить интерфейс программы, увеличив шрифт, поменяв цвет элементов и добавив другие «косметические» улучшения на свое усмотрение.
////в) Добавить в приложение меню «О программе» с информацией о программе(автор, версия, авторские права и др.).
//г)* Добавить пункт меню Save As, в котором можно выбрать имя для сохранения базы данных(элемент SaveFileDialog).
//Разделяйте логику между классами.В свойствах проектах в качестве запускаемого проекта укажите “Текущий выбор”
    /// </summary>

    public partial class Form1 : Form
    {
        string path = "ListBoxItems.json";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dateTime = new DateTime();
            listBox1.Items.Clear();
          var R= new Reflection(dateTime);
            foreach (var item in R.read())
            {
                listBox1.Items.Add(item);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string str = "";
                    while ((str = sr.ReadLine()!) != null)
                    {
                        var sp =str.Split(',');
                        foreach (var item in sp)
                        {
                            listBox1.Items.Add(item);
                        }
                        
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
         
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    string jsonString;
                    jsonString = JsonSerializer.Serialize(listBox1.Items);
                    sw.WriteLine(jsonString);
                }
            }
        }
    }
}
