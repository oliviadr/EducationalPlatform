using PlatformaEducationala.Models.BusinessLogicLayer;
using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PlatformaEducationala.ViewModels
{
    public class AbsenceVM : BasePropertyChanged
    {
        AbsenceBLL AbsenceBLL = new AbsenceBLL();
        public SubjectBLL SubjectBLL = new SubjectBLL();
        public TeacherBLL TeacherBLL = new TeacherBLL();
        public StudentBLL StudentBLL = new StudentBLL();

        public ObservableCollection<Tuple<string, int>> ListaIdSubject { get; set; }
        public ObservableCollection<Tuple<string, int>> ListaIdStudent { get; set; }
        public ObservableCollection<Absence> ListaAbsenteTeacheri { get; set; }

        private ObservableCollection<Tuple<string, int>> GetListaIdMaterii()
        {
            ObservableCollection<Tuple<string, int>> listaIdClase = new ObservableCollection<Tuple<string, int>>();
            foreach (Subject Subject in SubjectBLL.ObtineToateMateriile())
            {
                Tuple<string, int> pair = new Tuple<string, int>(Subject.Nume, (int)Subject.IdSubject);
                if (!listaIdClase.Contains(pair))
                {
                    listaIdClase.Add(pair);
                }
            }
            return listaIdClase;
        }

        private ObservableCollection<Tuple<string, int>> GetListaIdStudenti()
        {
            ObservableCollection<Tuple<string, int>> listaIdClase = new ObservableCollection<Tuple<string, int>>();
            foreach (Student Student in StudentBLL.ObtineTotiStudentii())
            {
                Tuple<string, int> pair = new Tuple<string, int>(Student.Nume, (int)Student.IdStudent);
                if (!listaIdClase.Contains(pair))
                {
                    listaIdClase.Add(pair);
                }
            }
            return listaIdClase;
        }

        public ObservableCollection<Absence> GetListaAbsenteTeacheri(int id)
        {
            return AbsenceBLL.ObtineToateAbsenteleDupaSubjectDupaTeacher(id);
        }

        #region Data Members

        public ObservableCollection<Absence> ListaAbsente
        {
            get => AbsenceBLL.ListaAbsente;
            set => AbsenceBLL.ListaAbsente = value;
        }

        #endregion

        public AbsenceVM()
        {
            ListaAbsente = AbsenceBLL.ObtineToateAbsentele();
            ListaIdSubject = GetListaIdMaterii();
            ListaIdStudent = GetListaIdStudenti();
        }

        #region Command Members

        private ICommand comandaInserare;
        public ICommand ComandaInserare
        {
            get
            {
                if (comandaInserare == null)
                {
                    comandaInserare = new RelayCommand<Absence>(AbsenceBLL.InserareAbsence);
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
                    comandaStergere = new RelayCommand<Absence>(AbsenceBLL.StergereAbsence);
                }
                return comandaStergere;
            }
        }

        private ICommand comandaActualizare;
        public ICommand ComandaActualizare
        {
            get
            {
                if (comandaActualizare == null)
                {
                    comandaActualizare = new RelayCommand<Absence>(AbsenceBLL.ActualizareAbsence);
                }
                return comandaActualizare;
            }
        }

        #endregion
    }
}
