using PlatformaEducationala.Models.BusinessLogicLayer;
using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PlatformaEducationala.ViewModels
{
    public class MaterialVM : BasePropertyChanged
    {
        MaterialBLL materialBLL = new MaterialBLL();
        public SubjectBLL SubjectBLL = new SubjectBLL();
        public StudentBLL StudentBLL = new StudentBLL();
        public TeacherBLL TeacherBLL = new TeacherBLL();
        public ClassBLL ClassBLL = new ClassBLL();

        public ObservableCollection<Tuple<string, int>> ListaIdMaterii { get; set; }

        public ObservableCollection<Tuple<string, int>> GetLIstaIdMaterii()
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

        public ObservableCollection<Material> GetListaMaterialeTeacheri(int id)
        {
            return materialBLL.ObtineToateMaterialeleDupaSubjectDupaTeacher(id);
        }

        #region Data Members

        public ObservableCollection<Material> ListaMateriale
        {
            get => materialBLL.ListaMateriale;
            set => materialBLL.ListaMateriale = value;
        }

        #endregion

        public MaterialVM()
        {
            ListaMateriale = materialBLL.ObtineToateMaterialele();
            ListaIdMaterii = GetLIstaIdMaterii();
        }

        #region Command Members

        private ICommand comandaInserare;
        public ICommand ComandaInserare
        {
            get
            {
                if (comandaInserare == null)
                {
                    comandaInserare = new RelayCommand<Material>(materialBLL.InserareMaterial);
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
                    comandaActualizare = new RelayCommand<Material>(materialBLL.ActualizareMaterial);
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
                    comandaStergere = new RelayCommand<Material>(materialBLL.StergereMaterial);
                }
                return comandaStergere;
            }
        }

        #endregion
    }
}
