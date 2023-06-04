using PlatformaEducationala.Models.BusinessLogicLayer;
using PlatformaEducationala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PlatformaEducationala.ViewModels
{
    public class StudentAnStudiuSpecializareVM : BasePropertyChanged
    {
        public StudentBLL StudentBLL = new StudentBLL();
        public ClassBLL ClassBLL = new ClassBLL();
        public SpecializationBLL SpecializationBLL = new SpecializationBLL();

        public ObservableCollection<Tuple<string, int>> ListaIdStudenti { get; set; }
        public ObservableCollection<string> ListaSpecializari { get; set; }

        public int anStudiu { get; set; }
        //public string Specialization { get; set; }

        private ObservableCollection<Tuple<string, int>> GetListaIdStudenti()
        {
            ObservableCollection<Tuple<string, int>> listaIdStudent = new ObservableCollection<Tuple<string, int>>();
            foreach (Student Student in StudentBLL.ObtineTotiStudentii())
            {
                Tuple<string, int> pair = new Tuple<string, int>(Student.Nume, (int)Student.IdStudent);
                if (!listaIdStudent.Contains(pair))
                {
                    listaIdStudent.Add(pair);
                }
            }
            return listaIdStudent;
        }

        public ObservableCollection<string> ObtineToateDenumirileSpecializarilor(ObservableCollection<Specialization> specializari)
        {
            ObservableCollection<string> listaSpecializari = new ObservableCollection<string>();
            foreach (Specialization Specialization in specializari)
            {
                if (!listaSpecializari.Contains(Specialization.Denumire))
                {
                    listaSpecializari.Add(Specialization.Denumire);
                }
            }
            return listaSpecializari;
        }

        //public void ObtineSpecializationDupaSpecialization(int SpecializationId)
        //{
        //    Specialization = SpecializationBLL.ObtineSpecializationDupaSpecialization(SpecializationId);
        //}

        public void ObtineAnStudiuDupaClass(int Class)
        {
            anStudiu = ClassBLL.ObtineAnStudiuDupaClass(Class);
        }

        public StudentAnStudiuSpecializareVM()
        {
            ListaIdStudenti = GetListaIdStudenti();
        }
    }
}
