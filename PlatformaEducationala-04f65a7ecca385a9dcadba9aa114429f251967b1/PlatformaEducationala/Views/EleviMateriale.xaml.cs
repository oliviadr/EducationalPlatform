using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace PlatformaEducationala.Views
{
    /// <summary>
    /// Interaction logic for StudentiMateriale.xaml
    /// </summary>
    public partial class StudentiMateriale : Window
    {
        int StudentId;
        MaterialVM materialVM;

        public StudentiMateriale()
        {
            InitializeComponent();
        }

        public StudentiMateriale(int StudentId)
        {
            InitializeComponent();
            this.StudentId = StudentId;
            materialVM = DataContext as MaterialVM;
            ObservableCollection<Material> materiale = new ObservableCollection<Material>();
            Student Student = materialVM.StudentBLL.ObtineStudentDupaId(StudentId);
            int anStudiu = materialVM.ClassBLL.ObtineAnStudiuDupaClass((int)Student.IdClass);
            ObservableCollection<Subject> materii = materialVM.SubjectBLL.ObtineToateMateriile();
            ObservableCollection<Subject> materiiPentruStudent = new ObservableCollection<Subject>();
            foreach (Subject Subject in materii)
            {
                if (Subject.AnStudiu == anStudiu && !materiiPentruStudent.Contains(Subject))
                {
                    materiiPentruStudent.Add(Subject);
                }
            }
            foreach (Material material in materialVM.ListaMateriale)
            {
                foreach (Subject Subject in materiiPentruStudent)
                {
                    if (material.IdSubject == Subject.IdSubject && !materiale.Contains(material))
                    {
                        materiale.Add(material);
                    }
                }
            }
            gridMateriale.ItemsSource = materiale;
        }
    }
}
