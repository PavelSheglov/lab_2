using System;
using System.Windows.Forms;
using GUI.Controller;

namespace GUI.Forms
{
    public partial class AviariesForm : Form
    {
        private ZooController _controller;
        private object _zoo;

        public AviariesForm(ZooController controller, object zoo)
        {
            _controller = controller;
            _zoo = zoo;
            InitializeComponent();
            FillAviaryList();
        }

        private void animalsButton_Click(object sender, EventArgs e)
        {
            if (aviariesListBox.SelectedItem != null)
            {
                var animals = new AnimalsForm(_controller, _zoo, aviariesListBox.SelectedItem);
                animals.ShowDialog();
            }
        }

        private void addAviaryButton_Click(object sender, EventArgs e)
        {
            var addAviary = new AddAviaryForm(_controller, _zoo);
            addAviary.ShowDialog();
            FillAviaryList();
        }

        private void deleteAviaryButton_Click(object sender, EventArgs e)
        {
            if (aviariesListBox.SelectedItem != null)
            {
                _controller.DeleteAviary(_zoo, aviariesListBox.SelectedItem);
                FillAviaryList();
            }
        }

        private void openAviaryButton_Click(object sender, EventArgs e)
        {
            if (aviariesListBox.SelectedItem != null)
            {
                _controller.OpenAviary(aviariesListBox.SelectedItem);
                FillAviaryList();
            }
        }

        private void closeAviaryButton_Click(object sender, EventArgs e)
        {
            if (aviariesListBox.SelectedItem != null)
            {
                _controller.CloseAviary(aviariesListBox.SelectedItem);
                FillAviaryList();
            }
        }

        private void viewAviaryButton_Click(object sender, EventArgs e)
        {
            if (aviariesListBox.SelectedItem != null)
            {
                MessageBox.Show(_controller.GetAviaryInformation(aviariesListBox.SelectedItem));
            }
        }

        private void FillAviaryList()
        {
            aviariesListBox.Items.Clear();
            foreach (var aviary in _controller.GetAviaryList(_zoo))
                aviariesListBox.Items.Add(aviary);
        }
    }
}
