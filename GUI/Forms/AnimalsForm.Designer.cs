namespace GUI.Forms
{
    partial class AnimalsForm
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
            this.animalsListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addAnimalButton = new System.Windows.Forms.Button();
            this.deleteAnimalButton = new System.Windows.Forms.Button();
            this.viewAnimalButton = new System.Windows.Forms.Button();
            this.transferAnimalButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // animalsListBox
            // 
            this.animalsListBox.FormattingEnabled = true;
            this.animalsListBox.ItemHeight = 16;
            this.animalsListBox.Location = new System.Drawing.Point(40, 32);
            this.animalsListBox.Name = "animalsListBox";
            this.animalsListBox.Size = new System.Drawing.Size(320, 148);
            this.animalsListBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Животные";
            // 
            // addAnimalButton
            // 
            this.addAnimalButton.Location = new System.Drawing.Point(415, 32);
            this.addAnimalButton.Name = "addAnimalButton";
            this.addAnimalButton.Size = new System.Drawing.Size(132, 33);
            this.addAnimalButton.TabIndex = 2;
            this.addAnimalButton.Text = "Поселить";
            this.addAnimalButton.UseVisualStyleBackColor = true;
            this.addAnimalButton.Click += new System.EventHandler(this.addAnimalButton_Click);
            // 
            // deleteAnimalButton
            // 
            this.deleteAnimalButton.Location = new System.Drawing.Point(415, 75);
            this.deleteAnimalButton.Name = "deleteAnimalButton";
            this.deleteAnimalButton.Size = new System.Drawing.Size(132, 32);
            this.deleteAnimalButton.TabIndex = 3;
            this.deleteAnimalButton.Text = "Выселить";
            this.deleteAnimalButton.UseVisualStyleBackColor = true;
            this.deleteAnimalButton.Click += new System.EventHandler(this.deleteAnimalButton_Click);
            // 
            // viewAnimalButton
            // 
            this.viewAnimalButton.Location = new System.Drawing.Point(415, 153);
            this.viewAnimalButton.Name = "viewAnimalButton";
            this.viewAnimalButton.Size = new System.Drawing.Size(132, 37);
            this.viewAnimalButton.TabIndex = 4;
            this.viewAnimalButton.Text = "Информация";
            this.viewAnimalButton.UseVisualStyleBackColor = true;
            this.viewAnimalButton.Click += new System.EventHandler(this.viewAnimalButton_Click);
            // 
            // transferAnimalButton
            // 
            this.transferAnimalButton.Location = new System.Drawing.Point(415, 113);
            this.transferAnimalButton.Name = "transferAnimalButton";
            this.transferAnimalButton.Size = new System.Drawing.Size(132, 34);
            this.transferAnimalButton.TabIndex = 5;
            this.transferAnimalButton.Text = "Переселить";
            this.transferAnimalButton.UseVisualStyleBackColor = true;
            this.transferAnimalButton.Click += new System.EventHandler(this.transferAnimalButton_Click);
            // 
            // AnimalsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 263);
            this.Controls.Add(this.transferAnimalButton);
            this.Controls.Add(this.viewAnimalButton);
            this.Controls.Add(this.deleteAnimalButton);
            this.Controls.Add(this.addAnimalButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.animalsListBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AnimalsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Животные";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox animalsListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addAnimalButton;
        private System.Windows.Forms.Button deleteAnimalButton;
        private System.Windows.Forms.Button viewAnimalButton;
        private System.Windows.Forms.Button transferAnimalButton;
    }
}