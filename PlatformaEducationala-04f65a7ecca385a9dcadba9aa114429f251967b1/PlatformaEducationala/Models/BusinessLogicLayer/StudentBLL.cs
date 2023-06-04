using PlatformaEducationala.Exceptions;
using PlatformaEducationala.Models.DataAccessLayer;
using PlatformaEducationala.Models.EntityLayer;
using System.Collections.ObjectModel;
using System.Linq;

namespace PlatformaEducationala.Models.BusinessLogicLayer
{
    public class StudentBLL
    {
        public ObservableCollection<Student> ListaStudenti { get; set; }

        StudentDAL StudentiDAL = new StudentDAL();

        public StudentBLL()
        {
            ListaStudenti = new ObservableCollection<Student>();
        }

        public ObservableCollection<Student> ObtineTotiStudentii()
        {
            return StudentiDAL.ObtineTotiStudentii();
        }

        public void ObtineTotiStudentiiDupaClass(Class Class)
        {
            ListaStudenti.Clear();
            var Studenti = StudentiDAL.ObtineTotiStudentiiDupaClass(Class);
            foreach (var Student in Studenti)
            {
                ListaStudenti.Add(Student);
            }
        }

        public ObservableCollection<Student> ObtineTotiStudentiiDupaSubjectDupaTeacher(int TeacherId)
        {
            return StudentiDAL.ObtineTotiStudentiiDupaSubjectDupaTeacher(TeacherId);
        }

        public Student ObtineStudentDupaId(int StudentId)
        {
            return StudentiDAL.ObtineStudentDupaId(StudentId);
        }

        public void InserareStudent(Student Student)
        {
            if (string.IsNullOrEmpty(Student.Nume))
            {
                throw new AgendaException("Numele Studentului trebuie sa fie precizat.");
            }
            if (string.IsNullOrEmpty(Student.Prenume))
            {
                throw new AgendaException("Prenumele Studentului trebuie sa fie precizat.");
            }
            
           
            if (string.IsNullOrEmpty(Student.Email))
            {
                throw new AgendaException("Email-ul Studentului trebuie sa fie precizat.");
            }
            if (string.IsNullOrEmpty(Student.IdClass.ToString()))
            {
                throw new AgendaException("ID-ul Clasei Studentului trebuie sa fie precizat.");
            }
            StudentiDAL.InserareStudent(Student);
            ListaStudenti.Add(Student);
        }

        public void ActualizareStudent(Student Student)
        {
            if (Student == null)
            {
                throw new AgendaException("Trebuie selectat un Student.");
            }
            if (string.IsNullOrEmpty(Student.Nume))
            {
                throw new AgendaException("Numele Studentului trebuie sa fie precizat.");
            }
            if (string.IsNullOrEmpty(Student.Prenume))
            {
                throw new AgendaException("Prenumele Studentului trebuie sa fie precizat.");
            }
            
            
            if (string.IsNullOrEmpty(Student.Email))
            {
                throw new AgendaException("Email-ul Studentului trebuie sa fie precizat.");
            }
            if (string.IsNullOrEmpty(Student.IdClass.ToString()))
            {
                throw new AgendaException("ID-ul Clasei Studentului trebuie sa fie precizat.");
            }
            StudentiDAL.ActualizareStudent(Student);
        }

        public void StergereStudent(Student Student)
        {
            if (Student == null)
            {
                throw new AgendaException("Trebuie selectat un Student.");
            }
            else
            {
                AbsenceDAL AbsenceDAL = new AbsenceDAL();
                if (AbsenceDAL.ObtineToateAbsenteleDupaStudent(Student).Count() > 0)
                {
                    throw new AgendaException("Trebuie sa stergeti mai intai absentele pentru Studentul cu ID-ul " + Student.IdStudent);
                }
                AverageDAL AverageDAL = new AverageDAL();
                if (AverageDAL.ObtineToateMediileDupaStudent(Student).Count() > 0)
                {
                    throw new AgendaException("Trebuie sa stergeti mai intai mediile pentru Studentul cu ID-ul " + Student.IdStudent);
                }
            }
            StudentiDAL.StergereStudent(Student);
            ListaStudenti.Remove(Student);
        }
    }
}
