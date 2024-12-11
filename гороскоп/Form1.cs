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

namespace гороскоп
{
    public partial class Form1 : Form
    {
        private Dictionary<string, string> horoscopes = new Dictionary<string, string>();
        private readonly Form2 form2;
        public Form1()
        {
            InitializeComponent();
            // Заполняем ComboBox знаками зодиака
            comboBox1.Items.AddRange(new string[] { "Овен", "Телец", "Близнецы", "Рак", "Лев", "Дева", "Весы", "Скорпион", "Стрелец", "Козерог", "Водолей", "Рыбы" });
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Выберите знак зодиака!");
                return;
            }
            Form2 form2 = new Form2(comboBox1.SelectedItem.ToString());
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, form2.Horoscope((string)comboBox1.SelectedItem));
                    
                    statusStrip1.Items[0].Text = $"Гороскоп сохранен в {saveFileDialog.FileName}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сохранения: {ex.Message}");
                }
            }
        }

        private int GetZodiacSign(string dateString)
        {
           
            try
            {
                // Парсим строку в объект DateTime
                   DateTime date  = DateTime.ParseExact(dateString, "dd/MM", null);

                // Определяем знак Зодиака
                if ((date.Month == 12 && date.Day >= 22)||(date.Month == 1 && date.Day <= 19))
                    return 0; // Овен
                else if ((date.Month == 1 && date.Day >= 20) || (date.Month == 2 && date.Day <= 18))
                    return 1; // Водолей
                else if ((date.Month == 2 && date.Day >= 19) || (date.Month == 3 && date.Day <= 20))
                    return 2; // Рыбы
                else if ((date.Month == 3 && date.Day >= 21) || (date.Month == 4 && date.Day <= 19))
                    return 3; // Овен
                else if ((date.Month == 4 && date.Day >= 20) || (date.Month == 5 && date.Day <= 20))
                    return 4; // Телец
                else if ((date.Month == 5 && date.Day >= 21) || (date.Month == 6 && date.Day <= 20))
                    return 5; // Близнецы
                else if ((date.Month == 6 && date.Day >= 21) || (date.Month == 7 && date.Day <= 22))
                    return 6; // Рак
                else if ((date.Month == 7 && date.Day >= 23) || (date.Month == 8 && date.Day <= 22))
                    return 7; // Лев
                else if ((date.Month == 8 && date.Day >= 23) || (date.Month == 9 && date.Day <= 22))
                    return 8; // Дева
                else if ((date.Month == 9 && date.Day >= 23) || (date.Month == 10 && date.Day <= 22))
                    return 9; // Весы
                else if ((date.Month == 10 && date.Day >= 23) || (date.Month == 11 && date.Day <= 21))
                    return 10; // Скорпион
                else if ((date.Month == 11 && date.Day >= 22) || (date.Month == 12 && date.Day <= 21))
                    return 11; // Стрелец
                else
                    throw new ArgumentException("Невозможно определить знак Зодиака.");
            }
            catch
            {
                return 0;
            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = GetZodiacSign(maskedTextBox1.Text);
        }
    }
}
