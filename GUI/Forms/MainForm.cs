using System;
using System.Windows.Forms;
using GUI.Controller;

namespace GUI.Forms
{
    public partial class MainForm : Form
    {
        private ZooController _controller;
        public MainForm(ZooController controller)
        {
            _controller = controller;
            InitializeComponent();
            FillZooList();
        }

        private void aviariesButton_Click(object sender, EventArgs e)
        {
            if (zoosListBox.SelectedItem != null)
            {
                var aviariesForm = new AviariesForm(_controller, zoosListBox.SelectedItem);
                aviariesForm.ShowDialog();
            }
        }

        private void animalsButton_Click(object sender, EventArgs e)
        {
            if (zoosListBox.SelectedItem != null && _controller.GetAviaryList(zoosListBox.SelectedItem).Count!=0)
            {
                var animalsForm = new AnimalsForm(_controller, zoosListBox.SelectedItem, null);
                animalsForm.ShowDialog();
            }
        }

        private void addZooButton_Click(object sender, EventArgs e)
        {
            var addZooForm = new AddZooForm(_controller);
            addZooForm.ShowDialog();
            FillZooList();
        }

        private void changeZooButton_Click(object sender, EventArgs e)
        {
            if (zoosListBox.SelectedItem != null)
            {
                var editZooForm = new EditZooForm(_controller, zoosListBox.SelectedItem);
                editZooForm.ShowDialog();
                FillZooList();
            }
        }

        private void deleteZooButton_Click(object sender, EventArgs e)
        {
            if (zoosListBox.SelectedItem != null)
            {
                _controller.DeleteZoo(zoosListBox.SelectedItem);
                FillZooList();
            }
        }

        private void viewZooButton_Click(object sender, EventArgs e)
        {
            if (zoosListBox.SelectedItem != null)
            {
                MessageBox.Show(_controller.GetZooInformation(zoosListBox.SelectedItem));
            }
        }

        private void FillZooList()
        {
            zoosListBox.Items.Clear();
            foreach (var zoo in _controller.GetZooList())
                zoosListBox.Items.Add(zoo);
        }
    }
}
