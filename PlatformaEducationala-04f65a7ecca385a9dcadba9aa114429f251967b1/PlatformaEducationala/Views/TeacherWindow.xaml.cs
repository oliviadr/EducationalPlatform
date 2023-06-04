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
    /// Interaction logic for Administrator.xaml
    /// </summary>
    public partial class TeacherWindow: Window
    {
        public TeacherWindow()
        {
            InitializeComponent();
        }

       

        private void TeacheriAbsenteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (TeacheriCB.SelectedItem != null)
            {
                Tuple<string, int> pair = TeacheriCB.SelectedItem as Tuple<string, int>;
                if (pair is Tuple<string, int> kv)
                {
                    ProfesoriAbsente TeacheriAbsente = new ProfesoriAbsente(kv.Item2);
                    TeacheriAbsente.Show();
                }
            }
            else
            {
                MessageBox.Show("Trebuie selectat un Teacher!", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TeacheriNoteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (TeacheriCB.SelectedItem != null)
            {
                Tuple<string, int> pair = TeacheriCB.SelectedItem as Tuple<string, int>;
                if (pair is Tuple<string, int> kv)
                {
                   ProfesoriNote TeacheriNote = new ProfesoriNote(kv.Item2);
                    TeacheriNote.Show();
                }
            }
            else
            {
                MessageBox.Show("Trebuie selectat un Teacher!", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TeacheriMaterialeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (TeacheriCB.SelectedItem != null)
            {
                Tuple<string, int> pair = TeacheriCB.SelectedItem as Tuple<string, int>;
                if (pair is Tuple<string, int> kv)
                {
                    ProfesoriMateriale TeacheriMateriale = new ProfesoriMateriale(kv.Item2);
                    TeacheriMateriale.Show();
                }
            }
            else
            {
                MessageBox.Show("Trebuie selectat un Teacher!", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TeacheriMediiMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (TeacheriCB.SelectedItem != null)
            {
                Tuple<string, int> pair = TeacheriCB.SelectedItem as Tuple<string, int>;
                if (pair is Tuple<string, int> kv)
                {
                    ProfesoriMedii TeacheriMedii = new ProfesoriMedii(kv.Item2);
                    TeacheriMedii.Show();
                }
            }
            else
            {
                MessageBox.Show("Trebuie selectat un Teacher!", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TeacheriCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

