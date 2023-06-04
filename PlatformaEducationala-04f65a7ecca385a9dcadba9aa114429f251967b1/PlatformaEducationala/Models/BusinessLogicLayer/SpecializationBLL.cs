using PlatformaEducationala.Exceptions;
using PlatformaEducationala.Models.DataAccessLayer;
using PlatformaEducationala.Models.EntityLayer;
using System.Collections.ObjectModel;

namespace PlatformaEducationala.Models.BusinessLogicLayer
{
    public class SpecializationBLL
    {
        public ObservableCollection<Specialization> ListaSpecialization { get; set; }

        SpecializationDAL SpecializationDAL = new SpecializationDAL();

        public SpecializationBLL()
        {
            ListaSpecialization = new ObservableCollection<Specialization>();
        }

        public ObservableCollection<Specialization> ObtineToateSpecializarile()
        {
            return SpecializationDAL.ObtineToateSpecializarile();
        }

        public void InserareSpecialization(Specialization Specialization)
        {
            if (string.IsNullOrEmpty(Specialization.Denumire))
            {
                throw new AgendaException("Denumirea specializarii trebuie sa fie precizata.");
            }
            SpecializationDAL.InserareSpecialization(Specialization);
            ListaSpecialization.Add(Specialization);
        }

        public void ActualizareSpecialization(Specialization Specialization)
        {
            if (Specialization == null)
            {
                throw new AgendaException("Trebuie selectata o Specialization.");
            }
            
            if (string.IsNullOrEmpty(Specialization.Denumire))
            {
                throw new AgendaException("Trebuie precizata denumirea specializarii.");
            }
            SpecializationDAL.ActualizareSpecialization(Specialization);
        }

        public void StergereSpecialization(Specialization Specialization)
        {
            if (Specialization == null)
            {
                throw new AgendaException("Trebuie selectata o Specialization.");
            }
            else
            {
                ClassDAL ClassDAL = new ClassDAL();
                if (ClassDAL.ObtineToateClaseleDupaSpecialization(Specialization).Count > 0)
                {
                    throw new AgendaException("Trebuie sa stergeti mai intai clasele cu Specializationa " + Specialization.Denumire);
                }
            }
            SpecializationDAL.StergereSpecialization(Specialization);
            ListaSpecialization.Remove(Specialization);
        }
    }
}
