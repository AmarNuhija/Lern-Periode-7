namespace SimonSaysGame
{
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            lblInfo = new Label();
            button1 = new Button();
            GameTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Stencil", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(104, 9);
            label1.Name = "label1";
            label1.Size = new Size(174, 22);
            label1.TabIndex = 0;
            label1.Text = "Simon Says Game";
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblInfo.Location = new Point(61, 293);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(279, 21);
            lblInfo.TabIndex = 1;
            lblInfo.Text = "Click on 3 Blocks in the same sequence";
            // 
            // button1
            // 
            button1.Location = new Point(104, 316);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(190, 50);
            button1.TabIndex = 2;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ClickEvent;
            // 
            // GameTimer
            // 
            GameTimer.Interval = 20;
            GameTimer.Tick += GameTimerEvent;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(395, 377);
            Controls.Add(button1);
            Controls.Add(lblInfo);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Game By Amar";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblInfo;
        private Button button1;
        private System.Windows.Forms.Timer GameTimer;
    }
}