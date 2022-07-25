using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048WindowsFormsApp
{
    public partial class StartForm : Form
    {
        public static string UserName;
        public static List<RadioButton> RadioButtons;
        public StartForm()
        {
            InitializeComponent();           

            RadioButtons = new List<RadioButton>
            {
               radioButton1, radioButton2, radioButton3, radioButton4
            };
            radioButton1.Checked = true;
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {

            if (userNameTextBox.Text != String.Empty)
            {
                UserName = userNameTextBox.Text;

                var mainForm = new MainForm();
                this.Hide();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Введите имя пользователя!");
                return;
            }

        }
    }
}
