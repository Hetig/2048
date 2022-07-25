namespace _2048WindowsFormsApp
{
    partial class GameRulesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gameRulesLabel = new System.Windows.Forms.Label();
            this.rulesLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameRulesLabel
            // 
            this.gameRulesLabel.AutoSize = true;
            this.gameRulesLabel.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gameRulesLabel.Location = new System.Drawing.Point(12, 52);
            this.gameRulesLabel.Name = "gameRulesLabel";
            this.gameRulesLabel.Size = new System.Drawing.Size(147, 19);
            this.gameRulesLabel.TabIndex = 0;
            this.gameRulesLabel.Text = "Здесь правила игры";
            // 
            // rulesLabel
            // 
            this.rulesLabel.AutoSize = true;
            this.rulesLabel.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rulesLabel.Location = new System.Drawing.Point(15, 13);
            this.rulesLabel.Name = "rulesLabel";
            this.rulesLabel.Size = new System.Drawing.Size(165, 25);
            this.rulesLabel.TabIndex = 1;
            this.rulesLabel.Text = "Правила игры";
            // 
            // GameRulesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 279);
            this.Controls.Add(this.rulesLabel);
            this.Controls.Add(this.gameRulesLabel);
            this.Name = "GameRulesForm";
            this.Text = "GameRulesForm";
            this.Load += new System.EventHandler(this.GameRulesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label gameRulesLabel;
        private System.Windows.Forms.Label rulesLabel;
    }
}