using PlatformaEducationala.Exceptions;
using PlatformaEducationala.Models.DataAccessLayer;
using PlatformaEducationala.Models.EntityLayer;
using System.Collections.ObjectModel;

namespace PlatformaEducationala.Models.BusinessLogicLayer
{
    public class GradeBLL
    {
        public ObservableCollection<Grade> ListaNote { get; set; }

        GradeDAL GradeDAL = new GradeDAL();

        public GradeBLL()
        {
            ListaNote = new ObservableCollection<Grade>();
        }

        public ObservableCollection<Grade> ObtineToateNotele()
        {
            return GradeDAL.ObtineToateNotele();
        }

        public ObservableCollection<Grade> ObtineToateNoteleDupaSubjectDupaTeacher(int TeacherId)
        {
            return GradeDAL.ObtineToateAbsenteleDupaSubjectDupaTeacher(TeacherId);
        }

        public void ObtineToateNoteleDupaSubject(Subject Subject)
        {
            ListaNote.Clear();
            var note = GradeDAL.ObtineToateNoteleDupaSubject(Subject);
            foreach (var Grade in note)
            {
                ListaNote.Add(Grade);
            }
        }

        public void InserareGrade(Grade Grade)
        {
            if (string.IsNullOrEmpty(Grade.IdSubject.ToString()))
            {
                throw new AgendaException("ID-ul Subjecti notei trebuie precizat.");
            }
            if (string.IsNullOrEmpty(Grade.Valoare.ToString()))
            {
                throw new AgendaException("Valoarea notei trebuie precizata.");
            }
            if (string.IsNullOrEmpty(Grade.Semestru.ToString()))
            {
                throw new AgendaException("Semestrul notei trebuie precizat.");
            }
            if (string.IsNullOrEmpty(Grade.IdStudent.ToString()))
            {
                throw new AgendaException("ID-ul Studentului trebuie precizat.");
            }
            GradeDAL.InserareGrade(Grade);
            ListaNote.Add(Grade);
        }

        public void ActualizareGrade(Grade Grade)
        {
            if (Grade == null)
            {
                throw new AgendaException("Trebuie selectat o Grade.");
            }
            if (string.IsNullOrEmpty(Grade.IdSubject.ToString()))
            {
                throw new AgendaException("ID-ul Subjecti notei trebuie precizat.");
            }
            if (string.IsNullOrEmpty(Grade.Valoare.ToString()))
            {
                throw new AgendaException("Valoarea notei trebuie precizata.");
            }
            if (string.IsNullOrEmpty(Grade.Semestru.ToString()))
            {
                throw new AgendaException("Semestrul notei trebuie precizat.");
            }
            if (string.IsNullOrEmpty(Grade.IdStudent.ToString()))
            {
                throw new AgendaException("ID-ul Studentului trebuie precizat.");
            }
            GradeDAL.ActualizareGrade(Grade);
        }

        public void StergereGrade(Grade Grade)
        {
            if (Grade == null)
            {
                throw new AgendaException("Trebuie selectata o Grade.");
            }
            GradeDAL.StergereGrade(Grade);
            ListaNote.Remove(Grade);
        }
    }
}
