using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PlatformaEducationala.Views
{
    /// <summary>
    /// Interaction logic for StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        public StudentWindow()
        {
            InitializeComponent();
        }

        private void StudentiMaterialeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (StudentiCB.SelectedItem != null)
            {
                Tuple<string, int> pair = StudentiCB.SelectedItem as Tuple<string, int>;
                if (pair is Tuple<string, int> kv)
                {
                    StudentiMateriale StudentiMateriale = new StudentiMateriale(kv.Item2);
                    StudentiMateriale.Show();
                }
            }
            else
            {
                MessageBox.Show("Trebuie selectat un Student!", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void StudentiNoteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (StudentiCB.SelectedItem != null)
            {
                Tuple<string, int>pair = StudentiCB.SelectedItem as Tuple<string, int>;
                if (pair is Tuple<string, int> kv)
                {
                    StudentiNote StudentiNote = new StudentiNote(kv.Item2);
                    StudentiNote.Show();
                }
            }
            else
            {
                MessageBox.Show("Trebuie selectat un Student!", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void StudentiAbsenteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (StudentiCB.SelectedItem != null)
            {
                Tuple<string, int> pair = StudentiCB.SelectedItem as Tuple<string, int>;
                if (pair is Tuple<string, int> kv)
                {
                    StudentiAbsente StudentiAbsente = new StudentiAbsente(kv.Item2);
                    StudentiAbsente.Show();
                }
            }
            else
            {
                MessageBox.Show("Trebuie selectat un Student!", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void StudentiMediiMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (StudentiCB.SelectedItem != null)
            {
                Tuple<string, int> pair = StudentiCB.SelectedItem as Tuple<string, int>;
                if (pair is Tuple<string, int> kv)
                {
                    StudentiMedii StudentiMedii = new StudentiMedii(kv.Item2);
                    StudentiMedii.Show();
                }
            }
            else
            {
                MessageBox.Show("Trebuie selectat un Student!", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

