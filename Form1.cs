
using System.Diagnostics;
using System.Reflection.Metadata;

namespace SimonSaysGame
{
    public partial class Form1 : Form
    {
        int blocksX = 100;
        int blocksY = 80;
        int score = 0;
        int level = 3;

        List<PictureBox> pictureBoxes = new List<PictureBox>();
        List<PictureBox> chosenBoxes = new List<PictureBox>();
        Random random = new Random();

        Color temp;

        int index = 0;
        int tries = 0;

        int timelimit = 0;
        bool selectingColor = false;

        string correctorder = string.Empty;
        string playerorder = string.Empty;

        public Form1()
        {
            InitializeComponent();
            SetUpBlocks();
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            if (selectingColor)
            {
                timelimit++;

                switch (timelimit)
                {
                    case 10:
                        temp = chosenBoxes[index].BackColor;
                        chosenBoxes[index].BackColor = Color.White;
                        break;

                    case 20:
                        chosenBoxes[index].BackColor = temp;
                        break;
                    case 30:
                        chosenBoxes[index].BackColor = Color.White;
                        break;
                    case 40:
                        chosenBoxes[index].BackColor = temp;
                        break;
                    case 50:
                        if (index < chosenBoxes.Count - 1)
                        {
                            index++;
                            timelimit = 0;
                        
                        }

                        else
                        {
                            selectingColor = false;
                        }
                        break;

                }
            }

            if (tries >= level)
            {
                if (correctorder == playerorder)
                {
                    tries = 0;
                    GameTimer.Stop();
                    MessageBox.Show("Well done you got it correct");
                    score++;
                }
                else
                {
                    tries = 0;
                    GameTimer.Stop();
                    MessageBox.Show("It was false, Try again");
                }
            }

            lblInfo.Text = "Click on " + level + " Blocks in the same sequence.";
        }

        private void ClickEvent(object sender, EventArgs e)
        {

            if (score == 3 && level < 7)
            {
                level++;
                score = 0;
            }

            correctorder = string.Empty;
            playerorder = string.Empty;
            chosenBoxes.Clear();
            chosenBoxes = pictureBoxes.OrderBy(x => random.Next()).Take(level).ToList();

            for (int i = 0; i < chosenBoxes.Count; i++)
            {
                correctorder += chosenBoxes[i].Name + " ";
               
            }

            foreach (PictureBox x in pictureBoxes)
            {
                x.BackColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
               
            }

            Debug.WriteLine(correctorder);
            index = 0;
            timelimit = 0;
            selectingColor = true;
            GameTimer.Start();
        }

        private void SetUpBlocks()
        {
            for (int i = 1; i < 17; i++)
            {
                PictureBox newPic = new PictureBox();
                newPic.Name = "pic_" + i;
                newPic.Height = 53;
                newPic.Width = 53;
                newPic.BackColor = Color.Black;
                newPic.Left = blocksX;
                newPic.Top = blocksY;
                newPic.Click += ClickOnPictureBlocks;

                this.Controls.Add(newPic);
                pictureBoxes.Add(newPic);

                if (i == 4 || i == 8 || i == 12)
                {
                    blocksY += 65;
                    blocksX = 100;  // Reset X position to the initial value
                }
                else
                {
                    blocksX += 65;
                }
            }
        }

        private void ClickOnPictureBlocks(object? sender, EventArgs e)
        {
            if (!selectingColor && chosenBoxes.Count > 1)
            {
                PictureBox temp = sender as PictureBox;
                temp.BackColor = Color.Black;
                playerorder += temp.Name + " ";
                Debug.WriteLine(playerorder);
                tries++;
            }

            else
            {
                return;
            }
        }
    }
}
