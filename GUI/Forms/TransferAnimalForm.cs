using System;
using System.Windows.Forms;
using GUI.Controller;

namespace GUI.Forms
{
    public partial class TransferAnimalForm : Form
    {
        private ZooController _controller;
        private object _zoo;
        private object _animal;

        public TransferAnimalForm(ZooController controller, object zoo, object animal)
        {
            _controller = controller;
            _zoo = zoo;
            _animal = animal;
            InitializeComponent();
            FillAviaryList();
        }

        private void FillAviaryList()
        {
            aviaryComboBox.Items.Clear();
            foreach (var aviary in _controller.GetAviaryList(_zoo))
                aviaryComboBox.Items.Add(aviary);
            aviaryComboBox.SelectedIndex = 0;
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            _controller.TransferAnimal(_zoo, aviaryComboBox.SelectedItem, _animal);
        }
    }
}
