namespace InvaderGameWinForms;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Text = "Form1";

        // UI Elements
        this.startScreenPanel = new System.Windows.Forms.Panel();
        this.titleLabel = new System.Windows.Forms.Label();
        this.startGameButton = new System.Windows.Forms.Button();
        this.gamePanel = new System.Windows.Forms.Panel();
        this.scoreText = new System.Windows.Forms.Label();
        this.player = new System.Windows.Forms.PictureBox();

        // startScreenPanel
        this.startScreenPanel.SuspendLayout();
        this.SuspendLayout();
        this.startScreenPanel.BackColor = System.Drawing.Color.LightGray;
        this.startScreenPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.startScreenPanel.Location = new System.Drawing.Point(0, 0);
        this.startScreenPanel.Name = "startScreenPanel";
        this.startScreenPanel.Size = new System.Drawing.Size(800, 450);
        this.startScreenPanel.TabIndex = 0;
        // titleLabel
        this.titleLabel.AutoSize = true;
        this.titleLabel.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.titleLabel.Location = new System.Drawing.Point(200, 100); // Placeholder, will be adjusted in Form1_Load
        this.titleLabel.Name = "titleLabel";
        this.titleLabel.Size = new System.Drawing.Size(399, 75);
        this.titleLabel.TabIndex = 0;
        this.titleLabel.Text = "Invader Game";
        // startGameButton
        this.startGameButton.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.startGameButton.Location = new System.Drawing.Point(325, 250);
        this.startGameButton.Name = "startGameButton";
        this.startGameButton.Size = new System.Drawing.Size(150, 50);
        this.startGameButton.TabIndex = 1;
        this.startGameButton.Text = "Start Game";
        this.startGameButton.UseVisualStyleBackColor = true;
        this.startGameButton.Click += new System.EventHandler(this.StartGame_Click);
        // gamePanel
        this.gamePanel.BackColor = System.Drawing.Color.Black;
        this.gamePanel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.gamePanel.Location = new System.Drawing.Point(0, 0);
        this.gamePanel.Name = "gamePanel";
        this.gamePanel.Size = new System.Drawing.Size(800, 450);
        this.gamePanel.TabIndex = 1;
        this.gamePanel.Visible = false;
        this.gamePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GamePanel_Paint);
        // scoreText
        this.scoreText.AutoSize = true;
        this.scoreText.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.scoreText.ForeColor = System.Drawing.Color.White;
        this.scoreText.Location = new System.Drawing.Point(10, 10);
        this.scoreText.Name = "scoreText";
        this.scoreText.Size = new System.Drawing.Size(114, 32);
        this.scoreText.TabIndex = 0;
        this.scoreText.Text = "Score: 0";
        // player
        this.player.BackColor = System.Drawing.Color.Transparent;
        this.player.Image = System.Drawing.Image.FromFile("hikouki.png");
        this.player.Location = new System.Drawing.Point(375, 380); // Placeholder, will be adjusted in SetupGame
        this.player.Name = "player";
        this.player.Size = new System.Drawing.Size(50, 50);
        this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.player.TabIndex = 1;
        this.player.TabStop = false;

        // Add controls to panels
        this.startScreenPanel.Controls.Add(this.titleLabel);
        this.startScreenPanel.Controls.Add(this.startGameButton);
        this.gamePanel.Controls.Add(this.scoreText);
        this.gamePanel.Controls.Add(this.player);

        // Add panels to form
        this.Controls.Add(this.gamePanel);
        this.Controls.Add(this.startScreenPanel);

        this.startScreenPanel.ResumeLayout(false);
        this.startScreenPanel.PerformLayout();
        this.gamePanel.ResumeLayout(false);
        this.gamePanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.Panel startScreenPanel;
    private System.Windows.Forms.Label titleLabel;
    private System.Windows.Forms.Button startGameButton;
    private System.Windows.Forms.Panel gamePanel;
    private System.Windows.Forms.Label scoreText;
    private System.Windows.Forms.PictureBox player;

    #endregion
}