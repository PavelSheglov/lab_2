using System;
using System.Windows.Forms;
using GUI.Controller;

namespace GUI.Forms
{
    public partial class EditZooForm : Form
    {
        private ZooController _controller;
        private object _zoo;
        private string _name;
        private string _address;

        public EditZooForm(ZooController controller, object zoo)
        {
            _controller = controller;
            _zoo = zoo;
            _name = string.Empty;
            _address = string.Empty;
            InitializeComponent();
            zooNameTextBox.Text = _controller.GetZooName(zoo);
            zooAddressTextBox.Text = _controller.GetZooAddress(zoo);
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            if(_name!=string.Empty)
                _controller.SetZooName(_zoo, _name);
            if (_address != string.Empty)
                _controller.SetZooAddress(_zoo, _address);
            if (_name == string.Empty || _address == string.Empty)
                MessageBox.Show("Наименование и/или адрес были введены некорректно, для этого(их) поля(ей) будет(ут) использовано(ы) прежнее(ие) значение(я)!");
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
