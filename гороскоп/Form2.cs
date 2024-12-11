using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace гороскоп
{
    public partial class Form2 : Form
    {
        public Form2(string zodiacSign) : this()
        {
            
            this.Text = $"Гороскоп для {zodiacSign}";
            textBox1.Text = Horoscope(zodiacSign.ToString());
            label1.Text = zodiacSign;

        }
        public Form2()
        {
            InitializeComponent();
        }
        private string GetHoroscope(string sign)
        {

            string filePath = $"C:\\Users\\Пользователь\\Documents\\Микушин\\Гороскоп.txt"; // путь к файлу

            if (File.Exists(filePath))
            {
                try
                {
                    return File.ReadAllText(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка чтения файла: {ex.Message}");
                    return "Ошибка получения гороскопа.";
                }
            }
            else
            {
                return "Файл с гороскопом не найден.";
            }
        }
        public string Horoscope(string zodiacSign)
        {
            if (GetHoroscope(zodiacSign).Contains(zodiacSign))
            {
                string[] liens = GetHoroscope(zodiacSign).Split('\n');
                int index = 0;
                foreach (var item in liens)
                {
                    if (item.Contains(zodiacSign))
                    {
                        index = Array.IndexOf(liens, item);
                        break;
                    }
                }
                return liens[index].Substring(zodiacSign.Length);
            }
            return "";
            
        }
        }
    

        
    }

