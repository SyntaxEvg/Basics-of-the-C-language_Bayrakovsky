using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace Lesson7
{ //2. Используя Windows Forms, разработать игру «Угадай число». Компьютер загадывает число от 1 до 100, а человек пытается его угадать за минимальное число попыток. Компьютер говорит, больше или меньше загаданное число введенного.
    //a) Для ввода данных от человека используется элемент TextBox;
    //б) **Реализовать отдельную форму c TextBox для ввода числа.//Старайтесь разбивать программы на подпрограммы. Переписывайте в начало программы условие и свою фамилию. Все программы сделать в одном решении.
    //В свойствах проектах в качестве запускаемого проекта укажите “Текущий выбор”.

    public enum Result
    {
        Угадали,
        Меньше,
        Больше,
        none,
    }

    public partial class Form1 : Form
    {
        public static Func<int, Result> ComparerDel;

        public string UserName { get; set; }

        private static int hiddenNumber;

        public static int HiddenNumber
        {
            get { return hiddenNumber; }
            set { hiddenNumber = value; }
        }
        /// <summary>
        /// Кол-во попыток
        /// </summary>
        public static int attempts { get; set; }


        public static Regex regexnumb;
        static Form1()
        {
            regexnumb = new Regex( "[^0-9]", RegexOptions.Compiled);
            ComparerDel = ComparerNumber;
            attempts = 0;

        }


        /// <summary>
        /// Сравнение с тем что загадано
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        static Result ComparerNumber(int a)
        {
            if(a.Equals(hiddenNumber))
            {
                return Result.Угадали;
            }
            else if(a > hiddenNumber)
            {
                return Result.Больше;
            }
            else if (a < hiddenNumber)
            {
                return Result.Меньше;
            }
            return Result.none;
        }


        public Form1()
        {
            InitializeComponent();
            this.Text = "Угадай число";
            this.textNumb.KeyPress += CheckInput!;
            this.textNumb.Cursor = System.Windows.Forms.Cursors.Hand;
        }



        void CheckInput(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                int.TryParse(textNumb.Text,out var number);                
                if (ComparerDel != null)
                {
                    var res= ComparerDel(number);
                    MessageBox.Show(res.ToString());
                    if (res == Result.Угадали)
                    {
                        button1.Text = "Играть!";
                        attempts = 0;
                        button1.Enabled = true;
                        textNumb.Enabled = false;
                        textNumb.Text = "";
                        MessageBox.Show(res.ToString());
                        listBox1.Items.Clear();
                        return;
                    }
                    else
                    {
                        listBox1.Items.Add($"{UserName} - кол-во попыток: {++attempts} : {textNumb.Text}");
                    }

                }            
            }
        }

         void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (regexnumb.IsMatch(textNumb.Text))
            {
                MessageBox.Show("Введено не число");
                textNumb.Text = textNumb.Text.Remove(textNumb.Text.Length - 1);
            }
        }

       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ListW_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form TextBlockForm = new Form();
            StartForm.CreatForms(ref TextBlockForm);//создание типовых форм
           
           
            TextBlockForm.ShowDialog();
            // TextBlockForm.
            UserName = TextBlockForm.Controls["TextUserName"].Text;
            MessageBox.Show($"Ваше имя: {UserName}");
            TextBlockForm.Close();

            attempts = 0;
            button1.Text = "Game start";
            button1.Enabled = false;
            textNumb.Enabled = true;
            listBox1.Items.Clear();
            Random rnd = new Random();
            HiddenNumber = rnd.Next(1, 100);
            this.Text = $"Угадай число, Загадано: {HiddenNumber}";



        }

        private void textNumb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
