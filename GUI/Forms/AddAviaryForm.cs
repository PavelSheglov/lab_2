using System;

using System.Windows.Forms;
using GUI.Controller;

namespace GUI.Forms
{
    public partial class AddAviaryForm : Form
    {
        private ZooController _controller;
        private object _zoo;
        private double _size;
        private byte _capacity;

        public AddAviaryForm(ZooController controller, object zoo)
        {
            _controller = controller;
            _zoo = zoo;
            _size = 0;
            _capacity = 0;
            InitializeComponent();
            FillAviaryTypesList();
            FillAviaryKindsList();
        }

        private void aviaryTypesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillAviaryKindsList();
        }

        private void FillAviaryTypesList()
        {
            aviaryTypesListBox.Items.Clear();
            foreach (var type in _controller.GetAviaryTypesList())
                aviaryTypesListBox.Items.Add(type);
            aviaryTypesListBox.SetSelected(0, true);
        }

        private void FillAviaryKindsList()
        {
            aviaryKindComboBox.Items.Clear();
            foreach (var kind in _controller.GetAviaryKindsList(aviaryTypesListBox.SelectedItem))
                aviaryKindComboBox.Items.Add(kind);
            aviaryKindComboBox.SelectedIndex = 0;
        }

        private void sizeTextBox_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError((TextBox)sender, null);
            try
            {
                var value = double.Parse(sizeTextBox.Text);
                if (value <= 0)
                    throw new ArgumentException("Значение должно быть больше нуля!");
                _size = value;
            }
            catch(FormatException)
            {
                errorProvider.SetError((TextBox)sender, "Должно быть число!");
            }
            catch (ArgumentException ex)
            {
                errorProvider.SetError((TextBox)sender, ex.Message);
            }
            catch (OverflowException)
            {
                errorProvider.SetError((TextBox)sender, "Недопустимое значение!");
            }
        }

        private void capacityTextBox_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError((TextBox)sender, null);
            try
            {
                var value = byte.Parse(capacityTextBox.Text);
                if (value == 0)
                    throw new ArgumentException("Значение должно быть больше нуля!");
                _capacity = value;

            }
            catch (FormatException)
            {
                errorProvider.SetError((TextBox)sender, "Должно быть число!");
            }
            catch (ArgumentException ex)
            {
                errorProvider.SetError((TextBox)sender, ex.Message);
            }
            catch(OverflowException)
            {
                errorProvider.SetError((TextBox)sender, "Недопустимое значение!");
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (_size == 0 || _capacity == 0)
                MessageBox.Show("Будут использованы значения по умолчанию для Площади/объема и Емкости!");
            _controller.AddAviary(_zoo, aviaryTypesListBox.SelectedItem, aviaryKindComboBox.SelectedItem, _size, _capacity);
        }
    }
}
