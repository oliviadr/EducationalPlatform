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
    public partial class Administrator:Window
    {
        public Administrator()
        {
            InitializeComponent();
        }

        private void specializariMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Specializari specializari = new Specializari();
            specializari.Show();
        }

        private void TeacheriMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Profesori Teacheri = new Profesori();
            Teacheri.Show();
        }

        private void materiiMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Materii materii = new Materii();
            materii.Show();
        }

        private void claseMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Clase clase = new Clase();
            clase.Show();
        }

        private void StudentiMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Studenti Studenti = new Studenti();
            Studenti.Show();
        }

        private void absenteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Absente absente = new Absente();
            absente.Show();
        }

        private void noteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Note note = new Note();
            note.Show();
        }

        private void mediiMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Medii medii = new Medii();
            medii.Show();
        }

        private void materialeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Materiale materiale = new Materiale();
            materiale.Show();
        }

        private void StudentAnStudiuSpecializationMenuItem_Click(object sender, RoutedEventArgs e)
        {
            StudentAnStudiuSpecializare studentAnStudiuSpecialization = new StudentAnStudiuSpecializare();
            studentAnStudiuSpecialization.Show();
        }

        
    }
}

