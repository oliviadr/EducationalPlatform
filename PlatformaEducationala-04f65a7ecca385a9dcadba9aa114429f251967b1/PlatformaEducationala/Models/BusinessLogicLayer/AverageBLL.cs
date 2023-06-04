using PlatformaEducationala.Exceptions;
using PlatformaEducationala.Models.DataAccessLayer;
using PlatformaEducationala.Models.EntityLayer;
using System.Collections.ObjectModel;

namespace PlatformaEducationala.Models.BusinessLogicLayer
{
    public class AverageBLL
    {
        public ObservableCollection<Average> ListaMedii { get; set; }

        AverageDAL AverageDAL = new AverageDAL();

        public AverageBLL()
        {
            ListaMedii = new ObservableCollection<Average>();
        }

        public ObservableCollection<Average> ObtineToateMediile()
        {
            return AverageDAL.ObtineToateMediile();
        }

        public void InserareAverage(Average Average)
        {
            if (string.IsNullOrEmpty(Average.IdSubject.ToString()))
            {
                throw new AgendaException("ID-ul Subjecti trebuie precizat.");
            }
            if (string.IsNullOrEmpty(Average.IdStudent.ToString()))
            {
                throw new AgendaException("ID-ul Studentului trebuie precizat.");
            }
            if (string.IsNullOrEmpty(Average.Grade.ToString()))
            {
                throw new AgendaException("Grade Averagei trebuie precizata.");
            }
            AverageDAL.InserareAverage(Average);
            ListaMedii.Add(Average);
        }

        public void ActualizareAverage(Average Average)
        {
            if (Average == null)
            {
                throw new AgendaException("Trebuie selectata o Average.");
            }
            if (string.IsNullOrEmpty(Average.IdSubject.ToString()))
            {
                throw new AgendaException("ID-ul Subjecti trebuie precizat.");
            }
            if (string.IsNullOrEmpty(Average.IdStudent.ToString()))
            {
                throw new AgendaException("ID-ul Studentului trebuie precizat.");
            }
            if (string.IsNullOrEmpty(Average.Grade.ToString()))
            {
                throw new AgendaException("Grade Averagei trebuie precizata.");
            }
            AverageDAL.ActualizareAverage(Average);
        }

        public void StergereAverage(Average Average)
        {
            if (Average == null)
            {
                throw new AgendaException("Grade Averagei trebuie precizata.");
            }
            AverageDAL.StergereAverage(Average);
            ListaMedii.Remove(Average);
        }
    }
}
