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
    public partial class GameStatisticsForm : Form
    {
        public GameStatisticsForm()
        {
            InitializeComponent();
        }

        private void GameStatisticsForm_Load(object sender, EventArgs e)
        {
            var users = UserResultStorage.GetAll();

            foreach(var user in users)
            {
                gamesStatisticDataGridView.Rows.Add(user.Name, user.Score);
            }
        }
    }
}
