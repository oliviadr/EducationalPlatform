using Microsoft.Win32;
using System.Windows;

namespace PlatformaEducationala.Views
{
    /// <summary>
    /// Interaction logic for Materiale.xaml
    /// </summary>
    public partial class Materiale : Window
    {
        public Materiale()
        {
            InitializeComponent();
        }

        private void IncarcaFisier_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            ofd.Filter = "txt files (*.txt)|*txt|All files (*.*)|*.*";
            ofd.DefaultExt = ".txt";
        }
    }
}
