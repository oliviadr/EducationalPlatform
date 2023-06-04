using PlatformaEducationala.Models.BusinessLogicLayer;
using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PlatformaEducationala.ViewModels
{
    public class ClassVM : BasePropertyChanged
    {
        ClassBLL ClassBLL = new ClassBLL();
        SpecializationBLL SpecializationBLL = new SpecializationBLL();
        TeacherBLL TeacherBLL = new TeacherBLL();

        public ObservableCollection<Tuple<string, int>> ListaIdSpecializari { get; set; }
        public ObservableCollection<Tuple<string, int>> ListaIdTeacheri { get; set; }
        public ObservableCollection<Tuple<string, int>> ListaIdDiriginti { get; set; }

        private ObservableCollection<Tuple<string, int>> GetListaIdSpecializari()
        {
            ObservableCollection<Tuple<string, int>> listaIdSpecializari = new ObservableCollection<Tuple<string, int>>();
            foreach (Specialization Specialization in SpecializationBLL.ObtineToateSpecializarile())
            {
                Tuple<string, int> pair = new Tuple<string, int>(Specialization.Denumire, (int)Specialization.IdSpecialization);
                if (!listaIdSpecializari.Contains(pair))
                {
                    listaIdSpecializari.Add(pair);
                }
            }
            return listaIdSpecializari;
        }

        private ObservableCollection<Tuple<string, int>> GetListaIdTeacheri()
        {
            ObservableCollection<Tuple<string, int>> listaIdSpecializari = new ObservableCollection<Tuple<string, int>>();
            foreach (Teacher Teacher in TeacherBLL.ObtineTotiTeacherii())
            {
                Tuple<string, int> pair = new Tuple<string, int>(Teacher.Nume, (int)Teacher.IdTeacher);
                if (!listaIdSpecializari.Contains(pair))
                {
                    listaIdSpecializari.Add(pair);
                }
            }
            return listaIdSpecializari;
        }
        private ObservableCollection<Tuple<string, int>> GetListaIdDiriginti()
        {
            ObservableCollection<Tuple<string, int>> listaIdSpecializari = new ObservableCollection<Tuple<string, int>>();
            foreach (Teacher Teacher in TeacherBLL.ObtineTotiDirigintii())
            {
                Tuple<string, int> pair = new Tuple<string, int>(Teacher.Nume, (int)Teacher.IdTeacher);
                if (!listaIdSpecializari.Contains(pair))
                {
                    listaIdSpecializari.Add(pair);
                }
            }
            return listaIdSpecializari;
        }
        #region Data Members

        public ObservableCollection<Class> ListaClase
        {
            get => ClassBLL.ListaClase;
            set => ClassBLL.ListaClase = value;
        }

        #endregion

        public ClassVM()
        {
            ListaClase = ClassBLL.ObtineToateClasele();
            ListaIdSpecializari = GetListaIdSpecializari();
            ListaIdTeacheri = GetListaIdTeacheri();
            ListaIdDiriginti= GetListaIdDiriginti();
        }

        #region Command Members

        private ICommand comandaInserare;
        public ICommand ComandaInserare
        {
            get
            {
                if (comandaInserare == null)
                {
                    comandaInserare = new RelayCommand<Class>(ClassBLL.InserareClass);
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
                    comandaStergere = new RelayCommand<Class>(ClassBLL.StergereClass);
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
                    comandaActualizare = new RelayCommand<Class>(ClassBLL.ActualizareClass);
                }
                return comandaActualizare;
            }
        }

        #endregion
    }
}
