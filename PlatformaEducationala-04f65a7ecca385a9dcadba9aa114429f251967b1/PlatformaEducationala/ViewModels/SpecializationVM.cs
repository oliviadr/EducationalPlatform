using PlatformaEducationala.Models.BusinessLogicLayer;
using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PlatformaEducationala.ViewModels
{
    public class SpecializationVM : BasePropertyChanged
    {
        SpecializationBLL SpecializationBLL = new SpecializationBLL();

        public ObservableCollection<Specialization> ListaSpecialization
        {
            get => SpecializationBLL.ListaSpecialization;
            set => SpecializationBLL.ListaSpecialization = value;
        }

        #region Data Members

        public SpecializationVM()
        {
            ListaSpecialization = SpecializationBLL.ObtineToateSpecializarile();
        }

        #endregion

        #region Command Members

        private ICommand comandaInserare;
        public ICommand ComandaInserare
        {
            get
            {
                if (comandaInserare == null)
                {
                    comandaInserare = new RelayCommand<Specialization>(SpecializationBLL.InserareSpecialization);
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
                    comandaActualizare = new RelayCommand<Specialization>(SpecializationBLL.ActualizareSpecialization);
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
                    comandaStergere = new RelayCommand<Specialization>(SpecializationBLL.StergereSpecialization);
                }
                return comandaStergere;
            }
        }

        #endregion
    }
}
