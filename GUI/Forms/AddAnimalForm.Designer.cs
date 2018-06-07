namespace GUI.Forms
{
    partial class AddAnimalForm
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
            this.components = new System.ComponentModel.Container();
            this.acceptButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.aviaryComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.detachmentComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.familyTextBox = new System.Windows.Forms.TextBox();
            this.genusTextBox = new System.Windows.Forms.TextBox();
            this.speciesTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.animalClassesListBox = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // acceptButton
            // 
            this.acceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.acceptButton.Location = new System.Drawing.Point(378, 228);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 34);
            this.acceptButton.TabIndex = 0;
            this.acceptButton.Text = "Ок";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(542, 228);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 34);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // aviaryComboBox
            // 
            this.aviaryComboBox.FormattingEnabled = true;
            this.aviaryComboBox.Location = new System.Drawing.Point(46, 35);
            this.aviaryComboBox.Name = "aviaryComboBox";
            this.aviaryComboBox.Size = new System.Drawing.Size(232, 24);
            this.aviaryComboBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Вольер";
            // 
            // detachmentComboBox
            // 
            this.detachmentComboBox.FormattingEnabled = true;
            this.detachmentComboBox.Location = new System.Drawing.Point(378, 35);
            this.detachmentComboBox.Name = "detachmentComboBox";
            this.detachmentComboBox.Size = new System.Drawing.Size(239, 24);
            this.detachmentComboBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(375, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Отряд";
            // 
            // familyTextBox
            // 
            this.familyTextBox.Location = new System.Drawing.Point(378, 89);
            this.familyTextBox.Name = "familyTextBox";
            this.familyTextBox.Size = new System.Drawing.Size(239, 22);
            this.familyTextBox.TabIndex = 7;
            this.familyTextBox.TextChanged += new System.EventHandler(this.animalTextBoxTextChanged);
            // 
            // genusTextBox
            // 
            this.genusTextBox.Location = new System.Drawing.Point(378, 137);
            this.genusTextBox.Name = "genusTextBox";
            this.genusTextBox.Size = new System.Drawing.Size(239, 22);
            this.genusTextBox.TabIndex = 8;
            this.genusTextBox.TextChanged += new System.EventHandler(this.animalTextBoxTextChanged);
            // 
            // speciesTextBox
            // 
            this.speciesTextBox.Location = new System.Drawing.Point(378, 191);
            this.speciesTextBox.Name = "speciesTextBox";
            this.speciesTextBox.Size = new System.Drawing.Size(239, 22);
            this.speciesTextBox.TabIndex = 9;
            this.speciesTextBox.TextChanged += new System.EventHandler(this.animalTextBoxTextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(378, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Семейство";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(378, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Род";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(378, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Вид";
            // 
            // animalClassesListBox
            // 
            this.animalClassesListBox.FormattingEnabled = true;
            this.animalClassesListBox.ItemHeight = 16;
            this.animalClassesListBox.Location = new System.Drawing.Point(49, 89);
            this.animalClassesListBox.Name = "animalClassesListBox";
            this.animalClassesListBox.Size = new System.Drawing.Size(229, 164);
            this.animalClassesListBox.TabIndex = 13;
            this.animalClassesListBox.SelectedIndexChanged += new System.EventHandler(this.animalClassesListBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Класс";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // AddAnimalForm
            // 
            this.AcceptButton = this.acceptButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(681, 292);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.animalClassesListBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.speciesTextBox);
            this.Controls.Add(this.genusTextBox);
            this.Controls.Add(this.familyTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.detachmentComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.aviaryComboBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.acceptButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddAnimalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Поселить новое животное";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox aviaryComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox detachmentComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox familyTextBox;
        private System.Windows.Forms.TextBox genusTextBox;
        private System.Windows.Forms.TextBox speciesTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox animalClassesListBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}