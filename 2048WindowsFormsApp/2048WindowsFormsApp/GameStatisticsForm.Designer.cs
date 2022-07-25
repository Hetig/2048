namespace _2048WindowsFormsApp
{
    partial class GameStatisticsForm
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
            this.gamesStatisticDataGridView = new System.Windows.Forms.DataGridView();
            this.UserNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResultColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gamesStatisticDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // gamesStatisticDataGridView
            // 
            this.gamesStatisticDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gamesStatisticDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserNameColumn,
            this.ResultColumn});
            this.gamesStatisticDataGridView.Location = new System.Drawing.Point(13, 13);
            this.gamesStatisticDataGridView.Name = "gamesStatisticDataGridView";
            this.gamesStatisticDataGridView.RowHeadersWidth = 51;
            this.gamesStatisticDataGridView.RowTemplate.Height = 24;
            this.gamesStatisticDataGridView.Size = new System.Drawing.Size(396, 425);
            this.gamesStatisticDataGridView.TabIndex = 0;
            // 
            // UserNameColumn
            // 
            this.UserNameColumn.HeaderText = "Имя";
            this.UserNameColumn.MinimumWidth = 6;
            this.UserNameColumn.Name = "UserNameColumn";
            this.UserNameColumn.Width = 125;
            // 
            // ResultColumn
            // 
            this.ResultColumn.HeaderText = "Результат";
            this.ResultColumn.MinimumWidth = 6;
            this.ResultColumn.Name = "ResultColumn";
            this.ResultColumn.Width = 125;
            // 
            // GameStatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 450);
            this.Controls.Add(this.gamesStatisticDataGridView);
            this.Name = "GameStatisticsForm";
            this.Text = "GameStatisticsForm";
            this.Load += new System.EventHandler(this.GameStatisticsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gamesStatisticDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gamesStatisticDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResultColumn;
    }
}