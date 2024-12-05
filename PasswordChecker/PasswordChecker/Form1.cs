using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PasswordChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Проверка длины пароля
            if (textBox1.Text.Length < 6)
            {
                label1.ForeColor = Color.Red;
            }
            else
            {
                label1.ForeColor = Color.Green;
            }

            // Проверка наличия прописных букв
            bool hasUppercase = false;
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if (char.IsUpper(textBox1.Text[i]))
                {
                    hasUppercase = true;
                    break;
                }
            }
            if (!hasUppercase)
            {
                label2.ForeColor = Color.Red;
            }
            else
            {
                label2.ForeColor = Color.Green;
            }

            // Проверка наличия цифр
            bool hasDigit = false;
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if (char.IsDigit(textBox1.Text[i]))
                {
                    hasDigit = true;
                    break;
                }
            }
            if (!hasDigit)
            {
                label3.ForeColor = Color.Red;
            }
            else
            {
                label3.ForeColor = Color.Green;
            }

            // Проверка наличия специальных символов
            bool hasSpecialChar = false;
            char[] specialChars = { '!', '@', '#', '$', '%', '^' };
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                for (int j = 0; j < specialChars.Length; j++)
                {
                    if (textBox1.Text[i] == specialChars[j])
                    {
                        hasSpecialChar = true;
                        break;
                    }
                }
                if (hasSpecialChar)
                {
                    break;
                }
            }
            if (!hasSpecialChar)
            {
                label4.ForeColor = Color.Red;
            }
            else
            {
                label4.ForeColor = Color.Green;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                // Сохранение корректного пароля в файл
                if (label1.ForeColor == Color.Green && label2.ForeColor == Color.Green && label3.ForeColor == Color.Green && label4.ForeColor == Color.Green)
                {
                    File.WriteAllText("C:\\Users\\isip\\Documents\\Микушин\\password.txt", textBox1.Text);
                    MessageBox.Show("Пароль сохранен в файл password.txt");
                }
            }
    }
    }
}
