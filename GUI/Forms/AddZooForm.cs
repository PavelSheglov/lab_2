using System;
using System.Windows.Forms;
using GUI.Controller;

namespace GUI.Forms
{
    public partial class AddZooForm : Form
    {
        private ZooController _controller;
        private string _name;
        private string _address;

        public AddZooForm(ZooController controller)
        {
            _controller = controller;
            _name = string.Empty;
            _address = string.Empty;
            InitializeComponent();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            if (_name != string.Empty && _address != string.Empty)
                _controller.AddZoo(zooNameTextBox.Text, zooAddressTextBox.Text);
            else
                MessageBox.Show("Зоопарк с пустым названием и/или адресом не будет создан!");
        }
        
        private void zooTextBoxTextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError((TextBox)sender, null);
            if (string.IsNullOrEmpty((sender as TextBox).Text) ||
               string.IsNullOrWhiteSpace((sender as TextBox).Text))
            {
                errorProvider.SetError((TextBox)sender, "Недопустимое значение поля!");
                if ((sender as TextBox) == zooNameTextBox)
                    _name = string.Empty;
                else
                    _address = string.Empty;
            }
            else if ((sender as TextBox) == zooNameTextBox)
                _name = (sender as TextBox).Text;
            else
                _address = (sender as TextBox).Text;
        }
    }
}
