using PlatformaEducationala.Models.BusinessLogicLayer;
using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PlatformaEducationala.ViewModels
{
    public class SubjectVM : BasePropertyChanged
    {
        SubjectBLL SubjectBLL = new SubjectBLL();
        TeacherBLL TeacherBLL = new TeacherBLL();

        public ObservableCollection<Tuple<string, int>> ListaIdTeacheri { get; set; }

        public ObservableCollection<Tuple<string, int>> GetListaIdTeacheri()
        {
            ObservableCollection<Tuple<string, int>> listaIdTeacheri = new ObservableCollection<Tuple<string, int>>();
            foreach (Teacher Teacher in TeacherBLL.ObtineTotiTeacherii())
            {
                Tuple<string, int> pair = new Tuple<string, int>(Teacher.Nume, (int)Teacher.IdTeacher);
                if (!listaIdTeacheri.Contains(pair))
                {
                    listaIdTeacheri.Add(pair);
                }
            }
            return listaIdTeacheri;
        }

        #region Data Members

        public ObservableCollection<Subject> ListaSubject
        {
            get => SubjectBLL.ListaMaterii;
            set => SubjectBLL.ListaMaterii = value;
        }

        #endregion

        public SubjectVM()
        {
            ListaSubject = SubjectBLL.ObtineToateMateriile();
            ListaIdTeacheri = GetListaIdTeacheri();
        }

        #region Command Members

        private ICommand comandaInserare;
        public ICommand ComandaInserare
        {
            get
            {
                if (comandaInserare == null)
                {
                    comandaInserare = new RelayCommand<Subject>(SubjectBLL.InserareSubject);
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
                    comandaActualizare = new RelayCommand<Subject>(SubjectBLL.ActualizareSubject);
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
                    comandaStergere = new RelayCommand<Subject>(SubjectBLL.StergereSubject);
                }
                return comandaStergere;
            }
        }

        #endregion
    }
}
