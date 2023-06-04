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
    /// Interaction logic for TeacheriAbsente.xaml
    /// </summary>
    public partial class ProfesoriAbsente : Window
    {
        private int TeacherId;
        private ObservableCollection<Absence> absente = new ObservableCollection<Absence>();
        AbsenceVM AbsenceVM;

        public ProfesoriAbsente()
        {
            InitializeComponent();
        }

        public ProfesoriAbsente(int TeacherId)
        {
            InitializeComponent();
            this.TeacherId = TeacherId;
            AbsenceVM = DataContext as AbsenceVM;
            absente = AbsenceVM.GetListaAbsenteTeacheri(TeacherId);
            absenteDG.ItemsSource = absente;
            Teacher Teacher = AbsenceVM.TeacherBLL.ObtineTeacherDupaId(TeacherId);
            AbsenceVM.SubjectBLL.ObtineToateMateriileDupaTeacher(Teacher);
            ObservableCollection<Tuple<string, int>> materii = new ObservableCollection<Tuple<string, int>>();
            foreach (Subject Subject in AbsenceVM.SubjectBLL.ListaMaterii)
            {
                Tuple<string, int> pair = new Tuple<string, int>(Subject.Nume, (int)Subject.IdSubject);
                if (!materii.Contains(pair))
                {
                    materii.Add(pair);
                }
            }
            txtIdSubject.ItemsSource = materii;
        }

        private void InsertButtonClick(object sender, RoutedEventArgs e)
        {
            absente = AbsenceVM.GetListaAbsenteTeacheri(TeacherId);
            absenteDG.ItemsSource = absente;
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

        private void txtIdStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
