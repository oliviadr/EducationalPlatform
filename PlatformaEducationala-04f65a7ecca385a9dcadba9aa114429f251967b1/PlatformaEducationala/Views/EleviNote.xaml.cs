using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace PlatformaEducationala.Views
{
    /// <summary>
    /// Interaction logic for StudentiNote.xaml
    /// </summary>
    public partial class StudentiNote : Window
    {
        int StudentId;

        public StudentiNote()
        {
            InitializeComponent();
        }

        public StudentiNote(int StudentId)
        {
            InitializeComponent();
            this.StudentId = StudentId;
            GradeVM GradeVM = DataContext as GradeVM;
            ObservableCollection<Grade> note = new ObservableCollection<Grade>();
            Student Student = GradeVM.StudentBLL.ObtineStudentDupaId(StudentId);
            foreach (Grade Grade in GradeVM.ListaNote)
            {
                if (!note.Contains(Grade) && Grade.IdStudent == Student.IdStudent)
                {
                    note.Add(Grade);
                }
            }
            gridNote.ItemsSource = note;
        }
    }
}
