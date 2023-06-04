using PlatformaEducationala.Models.BusinessLogicLayer;
using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PlatformaEducationala.ViewModels
{
    public class StudentVM : BasePropertyChanged
    {
        StudentBLL StudentBLL = new StudentBLL();
        ClassBLL ClassBLL = new ClassBLL();

        public ObservableCollection<Tuple<Tuple<int, string>, int>> ListaIdClase {  get; set; }

        private ObservableCollection<Tuple<Tuple<int, string>, int>> GetListaIdClase()
        {
            ObservableCollection<Tuple<Tuple<int, string>, int>> listaIdClase = new ObservableCollection<Tuple<Tuple<int, string>, int>>();
            foreach (Class Class in ClassBLL.ObtineToateClasele())
            {
                Tuple<int, string> secondaryPair = new Tuple<int, string>(Class.AnStudiu, Class.Grupa);
                Tuple<Tuple<int, string>, int> pair = new Tuple<Tuple<int, string>, int>(secondaryPair, (int)Class.IdClass);
                if (!listaIdClase.Contains(pair))
                {
                    listaIdClase.Add(pair);
                }
            }
            return listaIdClase;
        }

        public ObservableCollection<Student> GetListaStudentiTeacheri(int id)
        {
            return StudentBLL.ObtineTotiStudentiiDupaSubjectDupaTeacher(id);
        }

        #region Data Members

        public ObservableCollection<Student> ListaStudenti
        {
            get => StudentBLL.ListaStudenti;
            set => StudentBLL.ListaStudenti = value;
        }

        #endregion

        public StudentVM()
        {
            ListaStudenti = StudentBLL.ObtineTotiStudentii();
            ListaIdClase = GetListaIdClase();
        }

        #region Command Members

        private ICommand comandaInserare;
        public ICommand ComandaInserare
        {
            get
            {
                if (comandaInserare == null)
                {
                    comandaInserare = new RelayCommand<Student>(StudentBLL.InserareStudent);
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
                    comandaActualizare = new RelayCommand<Student>(StudentBLL.ActualizareStudent);
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
                    comandaStergere = new RelayCommand<Student>(StudentBLL.StergereStudent);
                }
                return comandaStergere;
            }
        }

        #endregion
    }
}
