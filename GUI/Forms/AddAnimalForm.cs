using System;
using System.Windows.Forms;
using GUI.Controller;

namespace GUI.Forms
{
    public partial class AddAnimalForm : Form
    {
        private ZooController _controller;
        private object _zoo;
        private object _aviary;
        private string _family;
        private string _genus;
        private string _species;

        public AddAnimalForm(ZooController controller, object zoo, object aviary)
        {
            _controller = controller;
            _zoo = zoo;
            _aviary = aviary;
            _family = string.Empty;
            _genus = string.Empty;
            _species = string.Empty;
            InitializeComponent();
            FillAviaryList();
            FillAnimalClassesList();
            FillAnimalDetachmentsList();
        }

        private void FillAviaryList()
        {
            aviaryComboBox.Items.Clear();
            foreach (var aviary in _controller.GetAviaryList(_zoo))
                aviaryComboBox.Items.Add(aviary);
            if (_aviary == null)
                aviaryComboBox.SelectedIndex = 0;
            else
            {
                aviaryComboBox.Enabled=false;
            }
        }

        private void FillAnimalClassesList()
        {
            animalClassesListBox.Items.Clear();
            foreach (var animalClass in _controller.GetAnimalClassesList())
                animalClassesListBox.Items.Add(animalClass);
            animalClassesListBox.SetSelected(0, true);
        }

        private void FillAnimalDetachmentsList()
        {
            detachmentComboBox.Items.Clear();
            foreach (var detachment in _controller.GetAnimalDetachmentsList(animalClassesListBox.SelectedItem))
                detachmentComboBox.Items.Add(detachment);
            detachmentComboBox.SelectedIndex = 0;
        }

        private void animalClassesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillAnimalDetachmentsList();
        }

        private void animalTextBoxTextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError((TextBox)sender, null);
            if (string.IsNullOrEmpty((sender as TextBox).Text) ||
               string.IsNullOrWhiteSpace((sender as TextBox).Text))
            {
                errorProvider.SetError((TextBox)sender, "Недопустимое значение поля!");
                if ((sender as TextBox) == familyTextBox)
                    _family = string.Empty;
                if ((sender as TextBox) == genusTextBox)
                    _genus = string.Empty;
                if ((sender as TextBox) == speciesTextBox)
                    _species = string.Empty;
            }
            else
            {
                if ((sender as TextBox) == familyTextBox)
                    _family = (sender as TextBox).Text;
                if ((sender as TextBox) == genusTextBox)
                    _genus = (sender as TextBox).Text;
                if ((sender as TextBox) == speciesTextBox)
                    _species = (sender as TextBox).Text;
            }
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            if (_aviary == null)
                _aviary = aviaryComboBox.SelectedItem;
            if (_family != string.Empty && _genus != string.Empty && _species != string.Empty)
                _controller.AddAnimal(_zoo, _aviary, animalClassesListBox.SelectedItem, 
                                      detachmentComboBox.SelectedItem, _family, _genus, _species);
            else
                MessageBox.Show("Животное с пустыми полями не будет создано!");
        }
    }
}
