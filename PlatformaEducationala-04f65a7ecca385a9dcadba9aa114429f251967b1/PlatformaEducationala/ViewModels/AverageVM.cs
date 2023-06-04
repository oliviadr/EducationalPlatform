using PlatformaEducationala.Models.BusinessLogicLayer;
using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PlatformaEducationala.ViewModels
{
    public class AverageVM : BasePropertyChanged
    {
        public AverageBLL AverageBLL = new AverageBLL();
        public TeacherBLL TeacherBLL = new TeacherBLL();
        public StudentBLL StudentBLL = new StudentBLL();
        public SubjectBLL SubjectBLL = new SubjectBLL();
        public GradeBLL GradeBLL = new GradeBLL();

        public ObservableCollection<Tuple<string, int>> ListaIdStudenti { get; set; }
        public ObservableCollection<Tuple<string, int>> ListaIdMaterii { get; set; }
        public ObservableCollection<Tuple<string, int>> ListaIdStudentiDupaTeacher { get; set; }

        public ObservableCollection<Tuple<string, int>> GetListaIdStudenti()
        {
            ObservableCollection<Tuple<string, int>> listaIdStudenti = new ObservableCollection<Tuple<string, int>>();
            foreach (Student Student in StudentBLL.ObtineTotiStudentii())
            {
                Tuple<string, int> pair = new Tuple<string, int>(Student.Nume, (int)Student.IdStudent);
                if (!listaIdStudenti.Contains(pair))
                {
                    listaIdStudenti.Add(pair);
                }
            }
            return listaIdStudenti;
        }

        public ObservableCollection<Tuple<string, int>> GetListaIdStudentiTeacher(Teacher Teacher)
        {
            ObservableCollection<Tuple<string, int>> listaIdStudenti = new ObservableCollection<Tuple<string, int>>();
            foreach (Student Student in StudentBLL.ObtineTotiStudentii())
            {
                Tuple<string, int> pair = new Tuple<string, int>(Student.Nume, (int)Student.IdStudent);
                if (!listaIdStudenti.Contains(pair))
                {
                    listaIdStudenti.Add(pair);
                }
            }
            return listaIdStudenti;
        }

        public ObservableCollection<Tuple<string, int>> GetListaIdMaterii()
        {
            ObservableCollection<Tuple<string, int>> listaIdMaterii = new ObservableCollection<Tuple<string, int>>();
            foreach (Subject Subject in SubjectBLL.ObtineToateMateriile())
            {
                Tuple<string, int> pair = new Tuple<string, int>(Subject.Nume, (int)Subject.IdSubject);
                if (!listaIdMaterii.Contains(pair))
                {
                    listaIdMaterii.Add(pair);
                }
            }
            return listaIdMaterii;
        }

        public ObservableCollection<Tuple<string, int>> GetListaIdMateriiTeacher(Teacher Teacher)
        {
            ObservableCollection<Tuple<string, int>> listaIdMaterii = new ObservableCollection<Tuple<string, int>>();
            foreach (Subject Subject in SubjectBLL.ObtineToateMateriile())
            {
                Tuple<string, int> pair = new Tuple<string, int>(Subject.Nume, (int)Subject.IdSubject);
                if (!listaIdMaterii.Contains(pair) && Teacher.IdTeacher == Subject.IdTeacher)
                {
                    listaIdMaterii.Add(pair);
                }
            }
            return listaIdMaterii;
        }

        #region Data Members

        public ObservableCollection<Average> ListaAverage
        {
            get => AverageBLL.ListaMedii;
            set => AverageBLL.ListaMedii = value;
        }

        #endregion

        public AverageVM()
        {
            ListaAverage = AverageBLL.ObtineToateMediile();
            ListaIdStudenti = GetListaIdStudenti();
            ListaIdMaterii = GetListaIdMaterii();
        }

        #region

        private ICommand comandaInserare;
        public ICommand ComandaInserare
        {
            get
            {
                if (comandaInserare == null)
                {
                    comandaInserare = new RelayCommand<Average>(AverageBLL.InserareAverage);
                }
                return comandaInserare;
            }
        }

        private ICommand comandaActualizare;
        public ICommand ComandaActualizare
        {
            get
            {
                if (comandaActualizare == null)
                {
                    comandaActualizare = new RelayCommand<Average>(AverageBLL.ActualizareAverage);
                }
                return comandaActualizare;
            }
        }

        private ICommand comandaStergere;
        public ICommand ComandaStergere
        {
            get
            {
                if (comandaStergere == null)
                {
                    comandaStergere = new RelayCommand<Average>(AverageBLL.StergereAverage);
                }
                return comandaStergere;
            }
        }

        #endregion
    }
}
