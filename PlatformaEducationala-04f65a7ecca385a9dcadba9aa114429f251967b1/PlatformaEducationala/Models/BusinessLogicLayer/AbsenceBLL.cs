using PlatformaEducationala.Exceptions;
using PlatformaEducationala.Models.DataAccessLayer;
using PlatformaEducationala.Models.EntityLayer;
using System.Collections.ObjectModel;

namespace PlatformaEducationala.Models.BusinessLogicLayer
{
    public class AbsenceBLL
    {
        public ObservableCollection<Absence> ListaAbsente { get; set; }

        AbsenceDAL AbsenceDAL = new AbsenceDAL();

        public AbsenceBLL()
        {
            ListaAbsente = new ObservableCollection<Absence>();
        }

        public ObservableCollection<Absence> ObtineToateAbsentele()
        {
            return AbsenceDAL.ObtineToateAbsentele();
        }

        public ObservableCollection<Absence> ObtineToateAbsenteleDupaSubjectDupaTeacher(int idTeacher)
        {
            return AbsenceDAL.ObtineToateAbsenteleDupaSubjectDupaTeacher(idTeacher);
        }

        public void InserareAbsence(Absence absence)
        {
            if (string.IsNullOrEmpty(absence.IdSubject.ToString()))
            {
                throw new AgendaException("Id-ul Subjecti la care este Absence trebuie precizat.");
            }
            if (string.IsNullOrEmpty(absence.IdStudent.ToString()))
            {
                throw new AgendaException("Id-ul Studentului care a primit Absence trebuie precizat.");
            }
            AbsenceDAL.InserareAbsence(absence);
            ListaAbsente.Add(absence);
        }

        public void ActualizareAbsence(Absence absence)
        {
            if (absence == null)
            {
                throw new AgendaException("Trebuie selectata o Absence.");
            }
            if (string.IsNullOrEmpty(absence.IdSubject.ToString()))
            {
                throw new AgendaException("Id-ul Subjecti la care este Absence trebuie precizat.");
            }
            if (string.IsNullOrEmpty(absence.IdStudent.ToString()))
            {
                throw new AgendaException("Id-ul Studentului care a primit Absence trebuie precizat.");
            }
            AbsenceDAL.ActualizareAbsence(absence);
        }

        public void StergereAbsence(Absence absence)
        {
            if (absence == null)
            {
                throw new AgendaException("Trebuie selectata o Absence.");
            }
            AbsenceDAL.StergereAbsence(absence);
            ListaAbsente.Remove(absence);
        }

        public void ObtineToateAbsenteleDupaStudent(Student student)
        {
            ListaAbsente.Clear();
            var absente = AbsenceDAL.ObtineToateAbsenteleDupaStudent(student);
            foreach (var absence in absente)
            {
                ListaAbsente.Add(absence);
            }
        }

        public void ObtineToateAbsenteleDupaSubject(Subject subject)
        {
            ListaAbsente.Clear();
            var absente = AbsenceDAL.ObtineToateAbsenteleDupaSubject(subject);
            foreach (var absence in absente)
            {
                ListaAbsente.Add(absence);
            }
        }
    }
}
