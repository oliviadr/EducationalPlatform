using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PlatformaEducationala.Views
{
    /// <summary>
    /// Interaction logic for TeacheriNote.xaml
    /// </summary>
    public partial class ProfesoriNote : Window
    {
        private int TeacherId;
        GradeVM GradeVM;
        private ObservableCollection<Grade> note = new ObservableCollection<Grade>();

        public ProfesoriNote()
        {
            InitializeComponent();
        }

        public ProfesoriNote(int TeacherId)
        {
            InitializeComponent();
            this.TeacherId = TeacherId;
            GradeVM = this.DataContext as GradeVM;
            note = GradeVM.GetListaNoteTeacheri(TeacherId);
            noteDG.ItemsSource = note;
            Teacher Teacher = GradeVM.TeacherBLL.ObtineTeacherDupaId(TeacherId);
            GradeVM.SubjectBLL.ObtineToateMateriileDupaTeacher(Teacher);
            ObservableCollection<Tuple<string, int>> materii = new ObservableCollection<Tuple<string, int>>();
            foreach (Subject Subject in GradeVM.SubjectBLL.ListaMaterii)
            {
                Tuple<string, int> pair = new Tuple<string, int>(Subject.Nume, (int)Subject.IdSubject);
                if (!materii.Contains(pair))
                {
                    materii.Add(pair);
                }
            }
            txtIdSubject.ItemsSource = materii;
            GradeVM.StudentBLL.ListaStudenti = GradeVM.StudentBLL.ObtineTotiStudentii();
            ObservableCollection<Tuple<string, int>> Studenti = new ObservableCollection<Tuple<string, int>>();
            foreach (Student Student in GradeVM.StudentBLL.ListaStudenti)
            {
                Tuple<string, int> pair = new Tuple<string, int>(Student.Nume, (int)Student.IdStudent);
                if (!Studenti.Contains(pair))
                {
                    Studenti.Add(pair);
                }
            }
            txtIdStudent.ItemsSource = Studenti;
        }

        private void InsertButtonClick(object sender, RoutedEventArgs e)
        {
            note = GradeVM.GetListaNoteTeacheri(TeacherId);
            noteDG.ItemsSource = note;
        }

        private void InsertButtonPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.Command != null && button.Command.CanExecute(button.CommandParameter))
                {
                    button.Command.Execute(button.CommandParameter);
                }
            }
            InsertButtonClick(sender, e);
        }
    }
}
