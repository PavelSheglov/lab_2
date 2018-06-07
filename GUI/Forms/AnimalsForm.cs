using System;
using System.Windows.Forms;
using GUI.Controller;

namespace GUI.Forms
{
    public partial class AnimalsForm : Form
    {
        private ZooController _controller;
        private object _zoo;
        private object _aviary;

        public AnimalsForm(ZooController controller, object zoo, object aviary)
        {
            _controller = controller;
            _zoo = zoo;
            _aviary = aviary;
            InitializeComponent();
            FillAnimalList();
        }

        private void addAnimalButton_Click(object sender, EventArgs e)
        {
            var addAnimalForm = new AddAnimalForm(_controller, _zoo, _aviary);
            addAnimalForm.ShowDialog();
            FillAnimalList();
        }

        private void deleteAnimalButton_Click(object sender, EventArgs e)
        {
            if(animalsListBox.SelectedItem!=null)
            {
                _controller.DeleteAnimal(_zoo, _aviary, animalsListBox.SelectedItem);
                FillAnimalList();
            }
        }

        private void transferAnimalButton_Click(object sender, EventArgs e)
        {
            if (animalsListBox.SelectedItem != null)
            {
                var transferAnimalForm = new TransferAnimalForm(_controller, _zoo, animalsListBox.SelectedItem);
                transferAnimalForm.ShowDialog();
                FillAnimalList();
            }
        }

        private void viewAnimalButton1_Click(object sender, EventArgs e)
        {
            if (animalsListBox.SelectedItem != null)
            {
                MessageBox.Show(_controller.GetAnimalInformation(animalsListBox.SelectedItem));
            }
        }

        private void FillAnimalList()
        {
            animalsListBox.Items.Clear();
            foreach (var animal in _controller.GetAnimalList(_zoo, _aviary))
                animalsListBox.Items.Add(animal);
        }
    }
}
