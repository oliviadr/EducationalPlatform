using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace PlatformaEducationala.Views
{
    /// <summary>
    /// Interaction logic for StudentiAbsente.xaml
    /// </summary>
    public partial class StudentiAbsente : Window
    {
        int StudentId;

        public StudentiAbsente()
        {
            InitializeComponent();
        }

        public StudentiAbsente(int StudentId)
        {
            InitializeComponent();
            this.StudentId = StudentId;
            AbsenceVM AbsenceVM = DataContext as AbsenceVM;
            ObservableCollection<Absence> absente = new ObservableCollection<Absence>();
            Student Student = AbsenceVM.StudentBLL.ObtineStudentDupaId(StudentId);
            foreach (Absence Absence in AbsenceVM.ListaAbsente)
            {
                if (!absente.Contains(Absence) && Absence.IdStudent == Student.IdStudent)
                {
                    absente.Add(Absence);
                }
            }
            gridAbsente.ItemsSource = absente;
        }
    }
}
