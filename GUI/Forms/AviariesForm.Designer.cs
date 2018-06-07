namespace GUI.Forms
{
    partial class AviariesForm
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
            this.aviariesListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addAviaryButton = new System.Windows.Forms.Button();
            this.deleteAviaryButton = new System.Windows.Forms.Button();
            this.openAviaryButton = new System.Windows.Forms.Button();
            this.closeAviaryButton = new System.Windows.Forms.Button();
            this.animalsButton = new System.Windows.Forms.Button();
            this.viewAviaryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // aviariesListBox
            // 
            this.aviariesListBox.FormattingEnabled = true;
            this.aviariesListBox.ItemHeight = 16;
            this.aviariesListBox.Location = new System.Drawing.Point(37, 33);
            this.aviariesListBox.Name = "aviariesListBox";
            this.aviariesListBox.Size = new System.Drawing.Size(362, 148);
            this.aviariesListBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Вольеры";
            // 
            // addAviaryButton
            // 
            this.addAviaryButton.Location = new System.Drawing.Point(435, 33);
            this.addAviaryButton.Name = "addAviaryButton";
            this.addAviaryButton.Size = new System.Drawing.Size(131, 33);
            this.addAviaryButton.TabIndex = 2;
            this.addAviaryButton.Text = "Добавить";
            this.addAviaryButton.UseVisualStyleBackColor = true;
            this.addAviaryButton.Click += new System.EventHandler(this.addAviaryButton_Click);
            // 
            // deleteAviaryButton
            // 
            this.deleteAviaryButton.Location = new System.Drawing.Point(435, 76);
            this.deleteAviaryButton.Name = "deleteAviaryButton";
            this.deleteAviaryButton.Size = new System.Drawing.Size(131, 31);
            this.deleteAviaryButton.TabIndex = 3;
            this.deleteAviaryButton.Text = "Удалить";
            this.deleteAviaryButton.UseVisualStyleBackColor = true;
            this.deleteAviaryButton.Click += new System.EventHandler(this.deleteAviaryButton_Click);
            // 
            // openAviaryButton
            // 
            this.openAviaryButton.Location = new System.Drawing.Point(435, 118);
            this.openAviaryButton.Name = "openAviaryButton";
            this.openAviaryButton.Size = new System.Drawing.Size(131, 32);
            this.openAviaryButton.TabIndex = 4;
            this.openAviaryButton.Text = "Открыть";
            this.openAviaryButton.UseVisualStyleBackColor = true;
            this.openAviaryButton.Click += new System.EventHandler(this.openAviaryButton_Click);
            // 
            // closeAviaryButton
            // 
            this.closeAviaryButton.Location = new System.Drawing.Point(435, 157);
            this.closeAviaryButton.Name = "closeAviaryButton";
            this.closeAviaryButton.Size = new System.Drawing.Size(131, 31);
            this.closeAviaryButton.TabIndex = 5;
            this.closeAviaryButton.Text = "Закрыть";
            this.closeAviaryButton.UseVisualStyleBackColor = true;
            this.closeAviaryButton.Click += new System.EventHandler(this.closeAviaryButton_Click);
            // 
            // animalsButton
            // 
            this.animalsButton.Location = new System.Drawing.Point(37, 202);
            this.animalsButton.Name = "animalsButton";
            this.animalsButton.Size = new System.Drawing.Size(122, 31);
            this.animalsButton.TabIndex = 6;
            this.animalsButton.Text = "Обитатели";
            this.animalsButton.UseVisualStyleBackColor = true;
            this.animalsButton.Click += new System.EventHandler(this.animalsButton_Click);
            // 
            // viewAviaryButton
            // 
            this.viewAviaryButton.Location = new System.Drawing.Point(249, 202);
            this.viewAviaryButton.Name = "viewAviaryButton";
            this.viewAviaryButton.Size = new System.Drawing.Size(150, 31);
            this.viewAviaryButton.TabIndex = 7;
            this.viewAviaryButton.Text = "Информация";
            this.viewAviaryButton.UseVisualStyleBackColor = true;
            this.viewAviaryButton.Click += new System.EventHandler(this.viewAviaryButton_Click);
            // 
            // AviariesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 315);
            this.Controls.Add(this.viewAviaryButton);
            this.Controls.Add(this.animalsButton);
            this.Controls.Add(this.closeAviaryButton);
            this.Controls.Add(this.openAviaryButton);
            this.Controls.Add(this.deleteAviaryButton);
            this.Controls.Add(this.addAviaryButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.aviariesListBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AviariesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вольеры";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox aviariesListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addAviaryButton;
        private System.Windows.Forms.Button deleteAviaryButton;
        private System.Windows.Forms.Button openAviaryButton;
        private System.Windows.Forms.Button closeAviaryButton;
        private System.Windows.Forms.Button animalsButton;
        private System.Windows.Forms.Button viewAviaryButton;
    }
}