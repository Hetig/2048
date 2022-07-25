using Newtonsoft.Json;
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
    public partial class MainForm : Form
    {
        private const int labelSize = 70;
        private const int padding = 6;
        private const int startX = 10;
        private const int startY = 50;

        private static int mapSize;
        private Label[,] labelsMap;
        private static Random random = new Random();
        private int bestScore = 0;
        public User user;        
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            user = new User(StartForm.UserName);

            DetermineMapSize(StartForm.RadioButtons);
            InitMap();
            GenerateNumber();
            ShowScore();
            ShowBestScore();
        }

        private void DetermineMapSize(List<RadioButton> radioButtons)
        {
            foreach (var radioButton in radioButtons)
            {
                if (radioButton.Checked)
                {
                    mapSize = Convert.ToInt32(radioButton.Text[0].ToString());
                    break;
                }
            }
        }

        private void ShowScore()
        {
            if (user.Score > bestScore)
            {
                bestScoreLabel.Text = user.Score.ToString();
            }
            scoreLabel.Text = user.Score.ToString();
        }

        public void ShowBestScore()
        {
            var users = UserResultStorage.GetAll();
            if (users.Count == 0)
            {
                bestScoreLabel.Text = bestScore.ToString();
                return;
            }
            foreach (var user in users)
            {
                if (user.Score > bestScore)
                {
                    bestScore = user.Score;
                    bestScoreLabel.Text = bestScore.ToString();
                }
            }
        }

        private void InitMap()
        {
            labelsMap = new Label[mapSize, mapSize];
            ClientSize = new Size(startX + (labelSize + padding) * mapSize, startY + (labelSize + padding) * mapSize);

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    var newLabel = CreateLabel(i, j);
                    Controls.Add(newLabel);
                    labelsMap[i, j] = newLabel;
                }
            }
        }

        private void GenerateNumber()
        {
            while (true)
            {
                var randomNumberLabel = random.Next(mapSize * mapSize);
                var indexRow = randomNumberLabel / mapSize;
                var indexColumn = randomNumberLabel % mapSize;
                var percentageLoss = random.Next(1, 5);
                if (labelsMap[indexRow, indexColumn].Text == string.Empty)
                {
                    if (percentageLoss == 4)
                    {
                        labelsMap[indexRow, indexColumn].Text = "4";
                    }
                    else
                    {
                        labelsMap[indexRow, indexColumn].Text = "2";
                    }
                    break;
                }
            }
        }

        private Label CreateLabel(int indexRow, int indexColumn)
        {
            var label = new Label();
            label.BackColor = SystemColors.ButtonShadow;
            label.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            label.Size = new Size(labelSize, labelSize);
            label.Name = "plateLabel";
            label.TextAlign = ContentAlignment.MiddleCenter;
            int x = startX + indexColumn * (labelSize + padding);
            int y = startY + indexRow * (labelSize + padding);
            label.Location = new Point(x, y);

            label.TextChanged += Label_TextChanged;
            return label;
        }

        private void Label_TextChanged(object sender, EventArgs e)
        {
            var label = (Label)sender;
            switch(label.Text)
            {
                case "": label.BackColor = SystemColors.ButtonShadow; break;
                case "2": label.BackColor = Color.FromArgb(250, 240, 230);break;
                case "4": label.BackColor = Color.FromArgb(255, 255, 205); break;
                case "8": label.BackColor = Color.FromArgb(255, 228, 196); break;
                case "16": label.BackColor = Color.FromArgb(222, 184, 135); break;
                case "32": label.BackColor = Color.FromArgb(184, 134, 11); break;
                case "64": label.BackColor = Color.FromArgb(255, 182, 193); break;
                case "128": label.BackColor = Color.FromArgb(255, 140, 0); break;
                case "256": label.BackColor = Color.FromArgb(250, 128, 114); break;
                case "512": label.BackColor = Color.FromArgb(255, 255, 0); break;
                case "1024": label.BackColor = Color.FromArgb(255, 20, 147); break;
                case "2048": label.BackColor = Color.FromArgb(255, 215, 0); break;
            }
                    
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                PressRight();
                GenerateNumber();
            }
            if (e.KeyCode == Keys.Left)
            {
                PressLeft();
                GenerateNumber();
            }

            if (e.KeyCode == Keys.Up)
            {
                PressUp();
                GenerateNumber();
            }

            if (e.KeyCode == Keys.Down)
            {
                PressDown();
                GenerateNumber();
            }           
            ShowScore();

            if (Win())
            {
                MessageBox.Show("Поздравляю! Вы победили");
                return;
            }

            if (EndGame())
            {
                MessageBox.Show("К сожалению, вы проиграли");
                return;
            }
        }

        private void PressDown()
        {
            for (int j = 0; j < mapSize; j++)
            {
                for (int i = mapSize - 1; i >= 0; i--)
                {
                    if (labelsMap[i, j].Text != string.Empty)
                    {
                        for (int k = i - 1; k >= 0; k--)
                        {
                            if (labelsMap[k, j].Text != string.Empty)
                            {
                                if (labelsMap[k, j].Text == labelsMap[i, j].Text)
                                {
                                    var number = int.Parse(labelsMap[i, j].Text);
                                    labelsMap[i, j].Text = (number * 2).ToString();
                                    user.Score += number * 2;
                                    labelsMap[k, j].Text = string.Empty;
                                }
                                break;
                            }
                        }
                    }
                }
            }

            for (int j = 0; j < mapSize; j++)
            {
                for (int i = mapSize - 1; i >= 0; i--)
                {
                    if (labelsMap[i, j].Text == string.Empty)
                    {
                        for (int k = i - 1; k >= 0; k--)
                        {
                            if (labelsMap[k, j].Text != string.Empty)
                            {
                                labelsMap[i, j].Text = labelsMap[k, j].Text;
                                labelsMap[k, j].Text = string.Empty;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void PressUp()
        {
            for (int j = 0; j < mapSize; j++)
            {
                for (int i = 0; i < mapSize; i++)
                {
                    if (labelsMap[i, j].Text != string.Empty)
                    {
                        for (int k = i + 1; k < mapSize; k++)
                        {
                            if (labelsMap[k, j].Text != string.Empty)
                            {
                                if (labelsMap[k, j].Text == labelsMap[i, j].Text)
                                {
                                    var number = int.Parse(labelsMap[i, j].Text);
                                    labelsMap[i, j].Text = (number * 2).ToString();
                                    user.Score += number * 2;
                                    labelsMap[k, j].Text = string.Empty;
                                }
                                break;
                            }
                        }
                    }
                }
            }

            for (int j = 0; j < mapSize; j++)
            {
                for (int i = 0; i < mapSize; i++)
                {
                    if (labelsMap[i, j].Text == string.Empty)
                    {
                        for (int k = i + 1; k < mapSize; k++)
                        {
                            if (labelsMap[k, j].Text != string.Empty)
                            {
                                labelsMap[i, j].Text = labelsMap[k, j].Text;
                                labelsMap[k, j].Text = string.Empty;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void PressLeft()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (labelsMap[i, j].Text != string.Empty)
                    {
                        for (int k = j + 1; k < mapSize; k++)
                        {
                            if (labelsMap[i, k].Text != string.Empty)
                            {
                                if (labelsMap[i, k].Text == labelsMap[i, j].Text)
                                {
                                    var number = int.Parse(labelsMap[i, j].Text);
                                    labelsMap[i, j].Text = (number * 2).ToString();
                                    user.Score += number * 2;
                                    labelsMap[i, k].Text = string.Empty;
                                }
                                break;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (labelsMap[i, j].Text == string.Empty)
                    {
                        for (int k = j + 1; k < mapSize; k++)
                        {
                            if (labelsMap[i, k].Text != string.Empty)
                            {
                                labelsMap[i, j].Text = labelsMap[i, k].Text;
                                labelsMap[i, k].Text = string.Empty;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void PressRight()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = mapSize - 1; j >= 0; j--)
                {
                    if (labelsMap[i, j].Text != string.Empty)
                    {
                        for (int k = j - 1; k >= 0; k--)
                        {
                            if (labelsMap[i, k].Text != string.Empty)
                            {
                                if (labelsMap[i, k].Text == labelsMap[i, j].Text)
                                {
                                    var number = int.Parse(labelsMap[i, j].Text);
                                    labelsMap[i, j].Text = (number * 2).ToString();
                                    user.Score += number * 2;
                                    labelsMap[i, k].Text = string.Empty;
                                }
                                break;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = mapSize - 1; j >= 0; j--)
                {
                    if (labelsMap[i, j].Text == string.Empty)
                    {
                        for (int k = j - 1; k >= 0; k--)
                        {
                            if (labelsMap[i, k].Text != string.Empty)
                            {
                                labelsMap[i, j].Text = labelsMap[i, k].Text;
                                labelsMap[i, k].Text = string.Empty;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private bool Win()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (labelsMap[i, j].Text == "2048")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool EndGame()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (labelsMap[i, j].Text == "")
                    {
                        return false;
                    }
                }
            }

            for (int i = 0; i < mapSize - 1; i++)
            {
                for (int j = 0; j < mapSize - 1; j++)
                {
                    if (labelsMap[i, j].Text == labelsMap[i, j + 1].Text || labelsMap[i, j].Text == labelsMap[i + 1, j].Text)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private void gameRulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var gameRulesForm = new GameRulesForm();
            gameRulesForm.ShowDialog();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showGamesStatisticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var gameStatisticsForm = new GameStatisticsForm();
            gameStatisticsForm.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UserResultStorage.Update(user);
        }
    }
}

