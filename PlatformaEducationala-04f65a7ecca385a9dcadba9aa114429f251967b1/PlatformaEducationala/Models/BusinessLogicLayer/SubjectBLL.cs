using PlatformaEducationala.Exceptions;
using PlatformaEducationala.Models.DataAccessLayer;
using PlatformaEducationala.Models.EntityLayer;
using System.Collections.ObjectModel;

namespace PlatformaEducationala.Models.BusinessLogicLayer
{
    public class SubjectBLL
    {
        public ObservableCollection<Subject> ListaMaterii { get; set; }

        SubjectDAL SubjectDAL = new SubjectDAL();

        public SubjectBLL()
        {
            ListaMaterii = new ObservableCollection<Subject>();
        }

        public ObservableCollection<Subject> ObtineToateMateriile()
        {
            return SubjectDAL.ObtineToateMateriile();
        }

        public void ObtineToateMateriileDupaTeacher(Teacher Teacher)
        {
            ListaMaterii.Clear();
            var materii = SubjectDAL.ObtineToateMateriileDupaTeacher(Teacher);
            foreach (var Subject in materii)
            {
                ListaMaterii.Add(Subject);
            }
        }

        public void InserareSubject(Subject Subject)
        {
            if (string.IsNullOrEmpty(Subject.Nume))
            {
                throw new AgendaException("Numele Subjecti trebuie sa fie precizat.");
            }
            if (string.IsNullOrEmpty(Subject.IdTeacher.ToString()))
            {
                throw new AgendaException("ID-ul profesurului trebuie precizat.");
            }
            if (string.IsNullOrEmpty(Subject.AnStudiu.ToString()))
            {
                throw new AgendaException("Anul de studiu trebuie precizat.");
            }
            SubjectDAL.InserareSubject(Subject);
            ListaMaterii.Add(Subject);
        }

        public void ActualizareSubject(Subject Subject)
        {
            if (Subject == null)
            {
                throw new AgendaException("Trebuie selectata o Subject.");
            }
            if (string.IsNullOrEmpty(Subject.Nume))
            {
                throw new AgendaException("Numele Subjecti trebuie sa fie precizat.");
            }
            if (string.IsNullOrEmpty(Subject.IdTeacher.ToString()))
            {
                throw new AgendaException("ID-ul profesurului trebuie precizat.");
            }
            if (string.IsNullOrEmpty(Subject.AnStudiu.ToString()))
            {
                throw new AgendaException("Anul de studiu trebuie precizat.");
            }
            SubjectDAL.ActualizareSubject(Subject);
        }

        public void StergereSubject(Subject Subject)
        {
            if (Subject == null)
            {
                throw new AgendaException("Trebuie selectata o Subject.");
            }
            else
            {
                AbsenceDAL AbsenceDAL = new AbsenceDAL();
                if (AbsenceDAL.ObtineToateAbsenteleDupaSubject(Subject).Count > 0)
                {
                    throw new AgendaException("Trebuie sa stergeti mai intai absentele pentru materia cu ID-ul " + Subject.IdSubject);
                }
                AverageDAL AverageDAL = new AverageDAL();
                if (AverageDAL.ObtineToateMediileDupaSubject(Subject).Count > 0)
                {
                    throw new AgendaException("Trebuie sa stergeti mai intai mediile pentru materia cu ID-ul " + Subject.IdSubject);
                }
                GradeDAL GradeDAL = new GradeDAL();
                if (GradeDAL.ObtineToateNoteleDupaSubject(Subject).Count > 0)
                {
                    throw new AgendaException("Trebuie sa stergeti mai intai notele pentru materia cu ID-ul " + Subject.IdSubject);
                }
                MaterialDAL materialDAL = new MaterialDAL();
                if (materialDAL.ObtineToateMaterialeleDupaSubject(Subject).Count > 0)
                {
                    throw new AgendaException("Trebuie sa stergeti mai intai materialele pentru materia cu ID-ul " + Subject.IdSubject);
                }
            }
            SubjectDAL.StergereSubject(Subject);
            ListaMaterii.Remove(Subject);
        }
    }
}
