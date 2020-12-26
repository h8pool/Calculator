using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace calc
{
    public partial class Form1 : Form
    {
        private List<double> nums = new List<double>();
        public string History;
        public double y;
         public string text;
        
        int[] counts = new int[2];

        public Form1()
        {
            InitializeComponent();
        }
        int count;
        
        //ЦИФРЫ
        private void button_0_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + 0;
        }
        private void button_1_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + 1;
        }
        private void button_2_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + 2;
        }
        private void button_3_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + 3;
        }
        private void button_4_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + 4;
        }
        private void button_5_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + 5;
        }
        private void button_6_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + 6;
        }
        private void button_7_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + 7;
        }
        private void button_8_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + 8;
        }
        private void button_9_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + 9;
        }
        //КНОПКИ МАТ ОПЕРАЦИИ
        private void buttonPlus_Click(object sender, EventArgs e)
        {
            textBox2.Text += " + ";
            count = 1;
        }
        private void buttonMinus_Click(object sender, EventArgs e)
        {
            textBox2.Text += " - ";
            count = 2;
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            textBox2.Text += " * ";
            count = 3;
        }
        private void buttonShare_Click(object sender, EventArgs e)
        {
            textBox2.Text += " / ";
            count = 4;
        }
        private void buttonPower_Click(object sender, EventArgs e)
        {
            textBox2.Text += " ^ ";
            count = 5;
        }
        private void buttonLog_Click(object sender, EventArgs e)
        {
            textBox2.Text += " L ";
            count = 6;
        }
        //Кнопки Мат операции не требующие равно
        private void buttonSquare_Click(object sender, EventArgs e)
        {
            AssignText(textBox2.Text);
            Square();
            GetText();
            textBox2.Clear();
            textBox2.Text = text.ToString();
            richTextBox1.AppendText("\n" + History + " Square " + textBox2.Text + "\n");
            nums.Clear();
            count = 7;
        }
        private void buttonFactorial_Click(object sender, EventArgs e)
        {
            AssignText(textBox2.Text);
            Factorial();
            GetText();
            textBox2.Clear();
            textBox2.Text = text.ToString();
            richTextBox1.AppendText("\n" + History + " Factorial " + textBox2.Text + "\n");
            nums.Clear();
            count = 8;
        }
        private void buttonSquareRoot_Click(object sender, EventArgs e)
        {
            AssignText(textBox2.Text);
            SquareRoot();
            GetText();
            textBox2.Clear();
            textBox2.Text = text.ToString();
            richTextBox1.AppendText("\n" + History + " SquareRoot " + textBox2.Text + "\n");
            nums.Clear();
            count = 9;

        }
        private void Median_Click(object sender, EventArgs e)
        {
            AssignText(textBox2.Text);
            Medians();
            GetText();
            textBox2.Clear();
            textBox2.Text = text.ToString();
            richTextBox1.AppendText("\n" + History + " Median " + textBox2.Text + "\n");
            nums.Clear();
            count = 10;
        }
        private void Disp_Click(object sender, EventArgs e)
        {
            AssignText(textBox2.Text);
            Disps();
            GetText();
            textBox2.Clear();
            textBox2.Text = text.ToString();
            richTextBox1.AppendText("\n" + History + " Disp " + textBox2.Text + "\n");
            nums.Clear();
            count = 11;
        }

        //КНОПКИ ДОП ФУНКЦИЙ
        public void Equal_Click(object sender, EventArgs e)
        {
            calculate();
            sendHistory();
            nums.Clear();
           
        }

        public void C_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            int lenght = textBox2.Text.Length - 1;
            string text = textBox2.Text;
            textBox2.Clear();
            for (int i = 0; i < lenght; i++)
            {
                textBox2.Text = textBox2.Text + text[i];
            }

        }

        private void Dot_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + ",";
        }
        private void undo_Click(object sender, EventArgs e)
        {
            int pos = 0;
            string Undo, changeUndo;
            string Res = "";
            string symbols = "=MDFS";
            Undo = richTextBox1.Text;
            counts[0] = Undo.Length;
            richTextBox1.Undo();
            changeUndo = richTextBox1.Text;
            counts[1] = changeUndo.Length;
            for (int i = counts[1] - 1; i < counts[0]; i++)
            {
                Res += Undo[i];

            }
            for (int i = 0; i < Res.Length; i++)
            {
                for (int j = 0; j < symbols.Length; j++)
                {
                    if (Res[i] == symbols[j])
                    {
                        pos = i;
                        break;
                    }
                }
            }
            textBox2.Text = "";
            for (int i = 0; i < pos; i++)
            {
                textBox2.Text += Res[i];
            }


        }

        private void Repeat_Click(object sender, EventArgs e)
        {
            switch (count)
            {
                case 1:
                    nums.Clear();
                    buttonPlus.PerformClick();
                    textBox2.Text += y;
                    calculate();
                    sendHistory();
                    break;
                case 2:
                    nums.Clear();
                    buttonMinus.PerformClick();
                    textBox2.Text += y;
                    calculate();
                    sendHistory();
                    break;
                case 3:
                    nums.Clear();
                    buttonMultiply.PerformClick();
                    textBox2.Text += y;
                    calculate();
                    sendHistory();
                    break;
                case 4:
                    nums.Clear();
                    buttonShare.PerformClick();
                    textBox2.Text += y;
                    calculate();
                    sendHistory();
                    break;
                case 5:
                    nums.Clear();
                    buttonPower.PerformClick();
                    textBox2.Text += y;
                    calculate();
                    sendHistory();
                    break;
                case 6:
                    nums.Clear();
                    buttonLog.PerformClick();
                    textBox2.Text += y;
                    calculate();
                    sendHistory();
                    break;
                case 7:
                    nums.Clear();
                    buttonSquare.PerformClick();


                    break;
                case 8:
                    nums.Clear();
                    buttonFactorial.PerformClick();

                    break;
                case 9:
                    nums.Clear();
                    buttonSquareRoot.PerformClick();

                    break;
                case 10:
                    nums.Clear();
                    Median.PerformClick();

                    break;
                case 11:
                    nums.Clear();
                    Disp.PerformClick();

                    break;

                default:
                    break;
            }
        }
        private void Space_Click(object sender, EventArgs e)
        {
            textBox2.Text += " ";
        }
        // ФУНКЦИИ ДЛЯ МАТ ОПЕРАЦИЙ
        public string Plus(string val)
        {
            History = val;
            text = val;
            string[] words = text.Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries);
            text = words[0];
            y = double.Parse(words[1]);
            TextToNums();
            for (int i = 0; i < nums.Count; ++i)
            {
                nums[i] += y;
            }
            TextRebuild();
            return text;
        }
        public string Minus(string val)
        {
            History = val;
            text = val;
            string[] words = text.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            text = words[0];
            y = double.Parse(words[1]);
            TextToNums();
            for (int i = 0; i < nums.Count; ++i)
            {
                nums[i] -= y;
            }
            TextRebuild();
            return text;
        }
        public string Multiply(string val)
        {
            History = val;
            text = val;
            string[] words = text.Split(new char[] { '*' }, StringSplitOptions.RemoveEmptyEntries);
            text = words[0];
            y = double.Parse(words[1]);
            TextToNums();
            for (int i = 0; i < nums.Count; ++i)
            {
                nums[i] *= y;
            }
            TextRebuild();
            return text;
        }

        public string Share(string val)
        {
            History = val;
            text = val;
            string[] words = text.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            text = words[0];
            y = double.Parse(words[1]);
            TextToNums();
            for (int i = 0; i < nums.Count; ++i)
            {
                nums[i] /= y;
            }
            TextRebuild();
            return text;
        }

        public string Power(string val)
        {
            History = val;
            text = val;
            string[] words = text.Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries);
            text = words[0];
            y = double.Parse(words[1]);
            TextToNums();
            for (int i = 0; i < nums.Count; ++i)
            {
                nums[i] = Math.Pow(nums[i], y);
            }
            TextRebuild();
            return text;
        }
        public void Square()
        {
            History = textBox2.Text;
            TextToNums();
            for (int i = 0; i < nums.Count; ++i)
            {
                nums[i] = Math.Pow(nums[i], 2);
            }
            TextRebuild();

        }
        public void SquareRoot()
        {
            History = textBox2.Text;
            TextToNums();
            for (int i = 0; i < nums.Count; ++i)
            {
                nums[i] = Math.Pow(nums[i], 0.5);
            }
            TextRebuild();
        }

        public string Log(string val)
        {
            History = val;
            text = val;
            string[] words = text.Split(new char[] { 'L' }, StringSplitOptions.RemoveEmptyEntries);
            text = words[0];
            y = double.Parse(words[1]);
            TextToNums();
            for (int i = 0; i < nums.Count; ++i)
            {
                nums[i] = Math.Log(nums[i] );
            }
            TextRebuild();
            return text;
        }

        public void Factorial()
        {
            History = textBox2.Text;
            TextToNums();

            for (int i = 0; i < nums.Count; ++i)
            {
                double temp = 1;
                for (double j = 1; j <= nums[i]; ++j)
                {
                    temp *= j;
                }
                nums[i] = temp;
            }
            TextRebuild();
        }
        public void Medians()
        {
            History = textBox2.Text;
            TextToNums();
            double median;
            if (nums.Count % 2 == 0)
            {
                double sum = 0;
                foreach (double a in nums)
                {
                    sum += a;
                }
                median = sum / nums.Count; 
            } else {
                for (int i = nums.Count - 1; i >= 1; i--)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (nums[j] > nums[j + 1])
                        {
                            double foo = nums[j];

                            nums[j] = nums[j + 1];
                            nums[j + 1] = foo;
                        }
                    }
                }
                median = nums[nums.Count / 2];
            }
            text = median.ToString();
            nums.Clear();

        }

        public void Disps()
        {
            History = textBox2.Text;
            TextToNums();
            double sum = 0;
            for (int i = 0;  i < nums.Count; ++i)
            {
                sum += nums[i];
            }
            double temp = sum / nums.Count;
            sum = 0;
            for (int i = 0; i < nums.Count; ++i)
            {
                nums[i] -= temp;
                nums[i] = Math.Pow(nums[i], 2);
                sum += nums[i];
            }
            sum /= nums.Count;
            text = sum.ToString();
            nums.Clear();

        }

        private void calculate()
        {
            switch (count)
            {
                case 1:
                    Plus(textBox2.Text);
                    textBox2.Clear();
                    textBox2.Text += text;
                    nums.Clear();
                    break;
                case 2:
                    Minus(textBox2.Text);
                    textBox2.Clear();
                    textBox2.Text += text;
                    nums.Clear();
                    break;
                case 3:
                    Multiply(textBox2.Text);
                    textBox2.Clear();
                    textBox2.Text += text;
                    nums.Clear();
                    break;
                case 4:
                    Share(textBox2.Text);
                    textBox2.Clear();
                    textBox2.Text += text;
                    nums.Clear();
                    break;
                case 5:
                    Power(textBox2.Text);
                    textBox2.Clear();
                    textBox2.Text += text;
                    nums.Clear();
                    break;
                case 6:
                    Log(textBox2.Text);
                    textBox2.Clear();
                    textBox2.Text += text;
                    nums.Clear();
                    break;

                default:
                    break;
            }

        }
        public string GetText()
        {
            return text;
        }
        public void AssignText(string val)
        {
            text = val;
        }
        //*МАТ ОПЕРАЦИИ*

        //ОБЩИЕ ФУНКЦИИ

        public void sendHistory()
        {
            richTextBox1.AppendText("\n" + History + " = " + textBox2.Text + "\n");
        }

        public void TextToNums()
        {
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in words)
            {
                try
                {
                    nums.Add(double.Parse(s));
                }
                catch (Exception ex)
                {
                    nums.Add(0);
                    Console.WriteLine(ex.Message);
                }
               
            }
            text = "";


        }

        public void TextRebuild()
        {
            text = "";
            foreach (double a in nums)
            {
                try
                {
                    text = text + a.ToString() + " ";
                }
                catch (Exception ex)
                {
                    text += "";
                    Console.WriteLine(ex.Message);
                }
            }
        }
        
        //*ОБЩИЕ ФУНКЦИИ*
       //Работа с файлом
        private void saveAsFileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Save File";
            save.Filter = "Text Files(*.txt)|*.txt|All Files() (*.*)|*.*";
            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamWriter write = new StreamWriter(File.Create(save.FileName));
                write.Write(richTextBox1.Text);
                write.Dispose();
            }
        }

        private void openFileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            
                OpenFileDialog open = new OpenFileDialog();
                open.Title = "Open File";
                open.Filter = "Text Files(*.txt)|*.txt|All Files() (*.*)|*.*";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    StreamReader read = new StreamReader(File.OpenRead(open.FileName));
                    textBox2.Text = read.ReadToEnd();
                    read.Dispose();
                }
            
        }
    }
}
