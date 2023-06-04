using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace PlatformaEducationala.Views
{
    /// <summary>
    /// Interaction logic for StudentiMedii.xaml
    /// </summary>
    public partial class StudentiMedii : Window
    {
        int StudentId;

        public StudentiMedii()
        {
            InitializeComponent();
        }

        public StudentiMedii(int StudentId)
        {
            InitializeComponent();
            this.StudentId = StudentId;
            AverageVM AverageVM = DataContext as AverageVM;
            ObservableCollection<Average> medii = new ObservableCollection<Average>();
            Student Student = AverageVM.StudentBLL.ObtineStudentDupaId(StudentId);
            double sumaMedii = 0.0;
            int numarMedii = 0;
            foreach (Average Average in AverageVM.ListaAverage)
            {
                if (!medii.Contains(Average) && Average.IdStudent == Student.IdStudent)
                {
                    medii.Add(Average);
                    sumaMedii += (double)Average.Grade;
                    numarMedii++;
                }
            }
            gridMedii.ItemsSource = medii;
            txtAverage.Text = (sumaMedii / numarMedii).ToString();
        }
    }
}
