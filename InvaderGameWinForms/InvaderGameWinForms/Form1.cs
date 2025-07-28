using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace InvaderGameWinForms
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer gameTimer;
        private double playerSpeed = 5;
        private bool isLeftPressed = false;
        private bool isRightPressed = false;
        private List<PictureBox> invaders = new List<PictureBox>();
        private List<Rectangle> playerBullets = new List<Rectangle>();
        private List<Rectangle> invaderBullets = new List<Rectangle>();

        private bool gameEnded = false;

        private double invaderSpeed = 1;
        private bool invaderMovingRight = true;
        private int invaderRows = 5;
        private int invaderCols = 10;
        private double invaderSpacing = 50;
        private double invaderStartX = 50;
        private double invaderStartY = 50;

        private int score = 0;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;
            this.DoubleBuffered = true; // Flickering reduction
            this.KeyPreview = true; // Enable form to receive key events before controls
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Adjust titleLabel position after form is loaded and sized
            titleLabel.Location = new Point((startScreenPanel.Width - TextRenderer.MeasureText("Invader Game", titleLabel.Font).Width) / 2, startScreenPanel.Height / 2 - 100);
            startGameButton.Location = new Point((startScreenPanel.Width - startGameButton.Width) / 2, startScreenPanel.Height / 2 + 50);
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            startScreenPanel.Visible = false;
            gamePanel.Visible = true;
            SetupGame();
            startGameButton.Enabled = false; // Disable the button to prevent re-clicking with spacebar
            gamePanel.Focus(); // Set focus to the game panel
        }

        private void SetupGame()
        {
            // Clear any previous game elements if restarting
            invaders.Clear();
            playerBullets.Clear();
            invaderBullets.Clear();
            score = 0;
            scoreText.Text = "Score: 0";
            gameEnded = false; // Reset gameEnded flag

            // Player setup
            player.Location = new Point((gamePanel.Width / 2) - (player.Width / 2), gamePanel.Height - player.Height - 20);

            // Invaders setup
            for (int r = 0; r < invaderRows; r++)
            {
                for (int c = 0; c < invaderCols; c++)
                {
                    PictureBox invader = new PictureBox
                    {
                        Size = new Size(40, 40),
                        Image = Image.FromFile("utyuujin.png"),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        BackColor = Color.Transparent,
                        Location = new Point((int)(invaderStartX + c * invaderSpacing), (int)(invaderStartY + r * invaderSpacing))
                    };
                    invaders.Add(invader);
                }
            }

            // Game Timer
            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 20; // Approximately 50 FPS
            gameTimer.Tick += GameLoop;
            gameTimer.Start();
        }

        private void GameLoop(object sender, EventArgs e)
        {
            if (gameEnded) return; // If game has ended, do nothing

            // Player movement
            if (isLeftPressed)
            {
                int newLeft = player.Left - (int)playerSpeed;
                if (newLeft >= 0)
                {
                    player.Left = newLeft;
                }
            }
            if (isRightPressed)
            {
                int newLeft = player.Left + (int)playerSpeed;
                if (newLeft + player.Width <= gamePanel.Width)
                {
                    player.Left = newLeft;
                }
            }

            // Player bullet movement
            for (int i = playerBullets.Count - 1; i >= 0; i--)
            {
                Rectangle bullet = playerBullets[i];
                bullet.Y -= 10; // Bullet speed
                playerBullets[i] = bullet; // Reassign the modified bullet back to the list

                if (bullet.Y < 0)
                {
                    playerBullets.RemoveAt(i);
                }
                else
                {
                    // Check for collision with invaders
                    for (int j = invaders.Count - 1; j >= 0; j--)
                    {
                        PictureBox invader = invaders[j];
                        if (bullet.IntersectsWith(invader.Bounds))
                        {
                            playerBullets.RemoveAt(i);
                            invaders.RemoveAt(j);
                            score += 10;
                            scoreText.Text = $"Score: {score}";
                            break;
                        }
                    }
                }
            }

            // Invader movement
            if (invaders.Count == 0)
            {
                gameEnded = true; // Set flag before showing message
                MessageBox.Show("You Win!");
                gameTimer.Stop();
                startScreenPanel.Visible = true;
                gamePanel.Visible = false;
                return;
            }

            // Calculate invader group bounds
            int minX = gamePanel.Width;
            int maxX = 0;
            foreach (var invader in invaders)
            {
                if (invader.Location.X < minX) minX = invader.Location.X;
                if (invader.Location.X + invader.Width > maxX) maxX = invader.Location.X + invader.Width;
            }

            if (invaderMovingRight)
            {
                if (maxX + invaderSpeed < gamePanel.Width)
                {
                    foreach (PictureBox invader in invaders)
                    {
                        invader.Left += (int)invaderSpeed;
                    }
                }
                else
                {
                    invaderMovingRight = false;
                    foreach (PictureBox invader in invaders)
                    {
                        invader.Top += (int)invaderSpacing / 2;
                    }
                }
            }
            else
            {
                if (minX - invaderSpeed > 0)
                {
                    foreach (PictureBox invader in invaders)
                    {
                        invader.Left -= (int)invaderSpeed;
                    }
                }
                else
                {
                    invaderMovingRight = true;
                    foreach (PictureBox invader in invaders)
                    {
                        invader.Top += (int)invaderSpacing / 2;
                    }
                }
            }

            // Invader bullet firing (simple random firing for now)
            if (new Random().Next(0, 100) < 5 && invaders.Count > 0) // 5% chance to fire a bullet
            {
                int invaderIndex = new Random().Next(0, invaders.Count);
                PictureBox firingInvader = invaders[invaderIndex];
                Rectangle invaderBullet = new Rectangle(firingInvader.Left + firingInvader.Width / 2 - 2, firingInvader.Bottom, 5, 10);
                invaderBullets.Add(invaderBullet);
            }

            // Invader bullet movement and collision with player
            for (int i = invaderBullets.Count - 1; i >= 0; i--)
            {
                Rectangle bullet = invaderBullets[i];
                bullet.Y += 5; // Invader bullet speed
                invaderBullets[i] = bullet; // Reassign the modified bullet back to the list

                if (bullet.Y > gamePanel.Height)
                {
                    invaderBullets.RemoveAt(i);
                }
                else
                {
                    if (bullet.IntersectsWith(player.Bounds))
                    {
                        invaderBullets.RemoveAt(i);
                        gameEnded = true; // Set flag before showing message
                        gameTimer.Stop();
                        MessageBox.Show("Game Over!");
                        startScreenPanel.Visible = true;
                        gamePanel.Visible = false;
                        // You might want to add a proper game over screen or reset logic here
                    }
                }
            }
            gamePanel.Invalidate(); // Redraw the game panel
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                isLeftPressed = true;
            }
            else if (e.KeyCode == Keys.Right)
            {
                isRightPressed = true;
            }
            else if (e.KeyCode == Keys.Space)
            {
                // Fire bullet
                Rectangle bullet = new Rectangle(player.Left + player.Width / 2 - 2, player.Top - 15, 5, 15);
                playerBullets.Add(bullet);
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                isLeftPressed = false;
            }
            else if (e.KeyCode == Keys.Right)
            {
                isRightPressed = false;
            }
        }

        private void GamePanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Draw player bullets
            foreach (Rectangle bullet in playerBullets)
            {
                g.FillRectangle(Brushes.LimeGreen, bullet);
            }

            // Draw invaders
            foreach (PictureBox invader in invaders)
            {
                g.DrawImage(invader.Image, invader.Location.X, invader.Location.Y, invader.Width, invader.Height);
            }

            // Draw invader bullets
            foreach (Rectangle bullet in invaderBullets)
            {
                g.FillRectangle(Brushes.Red, bullet);
            }
        }
    }
}