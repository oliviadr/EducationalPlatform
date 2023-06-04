using PlatformaEducationala.Models.BusinessLogicLayer;
using PlatformaEducationala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PlatformaEducationala.ViewModels
{
    public class MainWindowVM : BasePropertyChanged
    {
        public TeacherBLL TeacherBLL = new TeacherBLL();
        public StudentBLL StudentBLL = new StudentBLL();

        public ObservableCollection<Tuple<string, int>> Teacheri { get; set; }
        public ObservableCollection<Tuple<string, int>> Diriginti { get; set; }
        public ObservableCollection<Tuple<string, int>> Studenti { get; set; }

        private ObservableCollection<Tuple<string, int>> GetTeacheri()
        {
            ObservableCollection<Tuple<string, int>> Teacheri = new ObservableCollection<Tuple<string, int>>();
            foreach (Teacher Teacher in TeacherBLL.ObtineTotiTeacherii())
            {
                Tuple<string, int> pair = new Tuple<string, int>(Teacher.Nume, (int)Teacher.IdTeacher);
                if (!Teacheri.Contains(pair))
                {
                    Teacheri.Add(pair);
                }
            }
            return Teacheri;
        }

        private ObservableCollection<Tuple<string, int>> GetDiriginti()
        {
            ObservableCollection<Tuple<string, int>> diriginti = new ObservableCollection<Tuple<string, int>>();
            foreach (Teacher diriginte in TeacherBLL.ObtineTotiDirigintii())
            {
                Tuple<string, int> pair = new Tuple<string, int>(diriginte.Nume, (int)diriginte.IdTeacher);
                if (!diriginti.Contains(pair))
                {
                    diriginti.Add(pair);
                }
            }
            return diriginti;
        }

        private ObservableCollection<Tuple<string, int>> GetStudenti()
        {
            ObservableCollection<Tuple<string, int>> Studenti = new ObservableCollection<Tuple<string, int>>();
            foreach (Student Student in StudentBLL.ObtineTotiStudentii())
            {
                Tuple<string, int> pair = new Tuple<string, int>(Student.Nume, (int)Student.IdStudent);
                if (!Studenti.Contains(pair))
                {
                    Studenti.Add(pair);
                }
            }
            return Studenti;
        }

        public MainWindowVM()
        {
            Teacheri = GetTeacheri();
            Diriginti = GetDiriginti();
            Studenti = GetStudenti();
        }
    }
}
