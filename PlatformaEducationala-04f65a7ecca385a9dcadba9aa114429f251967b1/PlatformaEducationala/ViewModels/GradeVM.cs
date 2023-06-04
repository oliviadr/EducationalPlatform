using PlatformaEducationala.Models.BusinessLogicLayer;
using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PlatformaEducationala.ViewModels
{
    public class GradeVM : BasePropertyChanged
    {
        public GradeBLL GradeBLL = new GradeBLL();
        public SubjectBLL SubjectBLL = new SubjectBLL();
        public StudentBLL StudentBLL = new StudentBLL();
        public TeacherBLL TeacherBLL = new TeacherBLL();

        public ObservableCollection<Tuple<string, int>> ListaIdMaterii { get; set; }
        public ObservableCollection<Tuple<string, int>> ListaIdStudenti { get; set; }

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

        public ObservableCollection<Grade> GetListaNoteTeacheri(int TeacherId)
        {
            return GradeBLL.ObtineToateNoteleDupaSubjectDupaTeacher(TeacherId);
        }

        #region Data Members

        public ObservableCollection<Grade> ListaNote
        {
            get => GradeBLL.ListaNote;
            set => GradeBLL.ListaNote = value;
        }

        #endregion

        public GradeVM()
        {
            ListaNote = GradeBLL.ObtineToateNotele();
            ListaIdMaterii = GetListaIdMaterii();
            ListaIdStudenti = GetListaIdStudenti();
        }

        #region Command Members

        private ICommand comandaActualizare;
        public ICommand ComandaActualizare
        {
            get
            {
                if (comandaActualizare == null)
                {
                    comandaActualizare = new RelayCommand<Grade>(GradeBLL.ActualizareGrade);
                }
                return comandaActualizare;
            }
        }

        private ICommand comandaInserare;
        public ICommand ComandaInserare
        {
            get
            {
                if (comandaInserare == null)
                {
                    comandaInserare = new RelayCommand<Grade>(GradeBLL.InserareGrade);
                }
                return comandaInserare;
            }
        }

        private ICommand comandaStergere;
        public ICommand ComandaStergere
        {
            get
            {
                if (comandaStergere == null)
                {
                    comandaStergere = new RelayCommand<Grade>(GradeBLL.StergereGrade);
                }
                return comandaStergere;
            }
        }

        #endregion
    }
}
