namespace GUI.Forms
{
    partial class MainForm
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
            this.zoosListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addZooButton = new System.Windows.Forms.Button();
            this.deleteZooButton = new System.Windows.Forms.Button();
            this.changeZooButton = new System.Windows.Forms.Button();
            this.viewZooButton = new System.Windows.Forms.Button();
            this.aviariesButton = new System.Windows.Forms.Button();
            this.animalsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // zoosListBox
            // 
            this.zoosListBox.FormattingEnabled = true;
            this.zoosListBox.ItemHeight = 16;
            this.zoosListBox.Location = new System.Drawing.Point(34, 45);
            this.zoosListBox.Name = "zoosListBox";
            this.zoosListBox.Size = new System.Drawing.Size(379, 132);
            this.zoosListBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Зоопарки";
            // 
            // addZooButton
            // 
            this.addZooButton.Location = new System.Drawing.Point(435, 45);
            this.addZooButton.Name = "addZooButton";
            this.addZooButton.Size = new System.Drawing.Size(144, 29);
            this.addZooButton.TabIndex = 2;
            this.addZooButton.Text = "Добавить";
            this.addZooButton.UseVisualStyleBackColor = true;
            this.addZooButton.Click += new System.EventHandler(this.addZooButton_Click);
            // 
            // deleteZooButton
            // 
            this.deleteZooButton.Location = new System.Drawing.Point(435, 92);
            this.deleteZooButton.Name = "deleteZooButton";
            this.deleteZooButton.Size = new System.Drawing.Size(144, 31);
            this.deleteZooButton.TabIndex = 3;
            this.deleteZooButton.Text = "Удалить";
            this.deleteZooButton.UseVisualStyleBackColor = true;
            this.deleteZooButton.Click += new System.EventHandler(this.deleteZooButton_Click);
            // 
            // changeZooButton
            // 
            this.changeZooButton.Location = new System.Drawing.Point(435, 139);
            this.changeZooButton.Name = "changeZooButton";
            this.changeZooButton.Size = new System.Drawing.Size(144, 31);
            this.changeZooButton.TabIndex = 4;
            this.changeZooButton.Text = "Изменить";
            this.changeZooButton.UseVisualStyleBackColor = true;
            this.changeZooButton.Click += new System.EventHandler(this.changeZooButton_Click);
            // 
            // viewZooButton
            // 
            this.viewZooButton.Location = new System.Drawing.Point(435, 188);
            this.viewZooButton.Name = "viewZooButton";
            this.viewZooButton.Size = new System.Drawing.Size(144, 31);
            this.viewZooButton.TabIndex = 5;
            this.viewZooButton.Text = "Информация";
            this.viewZooButton.UseVisualStyleBackColor = true;
            this.viewZooButton.Click += new System.EventHandler(this.viewZooButton_Click);
            // 
            // aviariesButton
            // 
            this.aviariesButton.Location = new System.Drawing.Point(34, 189);
            this.aviariesButton.Name = "aviariesButton";
            this.aviariesButton.Size = new System.Drawing.Size(144, 30);
            this.aviariesButton.TabIndex = 6;
            this.aviariesButton.Text = "Вольеры";
            this.aviariesButton.UseVisualStyleBackColor = true;
            this.aviariesButton.Click += new System.EventHandler(this.aviariesButton_Click);
            // 
            // animalsButton
            // 
            this.animalsButton.Location = new System.Drawing.Point(269, 189);
            this.animalsButton.Name = "animalsButton";
            this.animalsButton.Size = new System.Drawing.Size(144, 30);
            this.animalsButton.TabIndex = 7;
            this.animalsButton.Text = "Животные";
            this.animalsButton.UseVisualStyleBackColor = true;
            this.animalsButton.Click += new System.EventHandler(this.animalsButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 361);
            this.Controls.Add(this.animalsButton);
            this.Controls.Add(this.aviariesButton);
            this.Controls.Add(this.viewZooButton);
            this.Controls.Add(this.changeZooButton);
            this.Controls.Add(this.deleteZooButton);
            this.Controls.Add(this.addZooButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zoosListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Зоопарки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox zoosListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addZooButton;
        private System.Windows.Forms.Button deleteZooButton;
        private System.Windows.Forms.Button changeZooButton;
        private System.Windows.Forms.Button viewZooButton;
        private System.Windows.Forms.Button aviariesButton;
        private System.Windows.Forms.Button animalsButton;
    }
}