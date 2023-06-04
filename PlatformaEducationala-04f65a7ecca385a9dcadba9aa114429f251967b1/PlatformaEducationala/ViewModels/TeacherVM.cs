using PlatformaEducationala.Models.BusinessLogicLayer;
using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PlatformaEducationala.ViewModels
{
    public class TeacherVM : BasePropertyChanged
    {
        TeacherBLL TeacherBLL = new TeacherBLL();

        #region Data Members

        public ObservableCollection<Teacher> ListaTeacheri
        {
            get => TeacherBLL.ListaTeacheri;
            set => TeacherBLL.ListaTeacheri = value;
        }

        public ObservableCollection<Teacher> ListaDiriginti
        {
            get => TeacherBLL.ListaDiriginti;
            set => TeacherBLL.ListaDiriginti = value;
        }
        #endregion

        public TeacherVM()
        {
            ListaTeacheri = TeacherBLL.ObtineTotiTeacherii();
            
        }

        #region Command Members

        private ICommand comandaInserare;
        public ICommand ComandaInserare
        {
            get
            {
                if (comandaInserare == null)
                {
                    comandaInserare = new RelayCommand<Teacher>(TeacherBLL.InserareTeacher);
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
                    comandaActualizare = new RelayCommand<Teacher>(TeacherBLL.ActualizareTeacher);
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
                    comandaStergere = new RelayCommand<Teacher>(TeacherBLL.StergereTeacher);
                }
                return comandaStergere;
            }
        }

        #endregion
    }
}
