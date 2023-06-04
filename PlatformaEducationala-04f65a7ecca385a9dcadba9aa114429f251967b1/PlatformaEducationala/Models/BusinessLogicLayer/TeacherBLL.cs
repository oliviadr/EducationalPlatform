using PlatformaEducationala.Exceptions;
using PlatformaEducationala.Models.DataAccessLayer;
using PlatformaEducationala.Models.EntityLayer;
using System.Collections.ObjectModel;

namespace PlatformaEducationala.Models.BusinessLogicLayer
{
    public class TeacherBLL
    {
        public ObservableCollection<Teacher> ListaTeacheri { get; set; }
        public ObservableCollection<Teacher> ListaDiriginti { get; set; }

        TeacherDAL TeacheriDAL = new TeacherDAL();

        public TeacherBLL()
        {
            ListaTeacheri = new ObservableCollection<Teacher>();
            ListaDiriginti= new ObservableCollection<Teacher>();
        }

        public ObservableCollection<Teacher> ObtineTotiTeacherii()
        {
            return TeacheriDAL.ObtineTotiTeacherii();
        }

        public ObservableCollection<Teacher> ObtineTotiDirigintii()
        {
            return TeacheriDAL.ObtineTotiDirigintii();
        }


        public Teacher ObtineTeacherDupaId(int TeacherId)
        {
            return TeacheriDAL.ObtineTeacherDupaId(TeacherId);
        }

        public void InserareTeacher(Teacher Teacher)
        {
            if (string.IsNullOrEmpty(Teacher.Nume))
            {
                throw new AgendaException("Numele Teacherului trebuie sa fie precizat.");
            }
            if (string.IsNullOrEmpty(Teacher.Prenume))
            {
                throw new AgendaException("Prenumele Teacherului trebuie sa fie precizat.");
            }
          
            
            if (string.IsNullOrEmpty(Teacher.Email))
            {
                throw new AgendaException("Email-ul Teacherului trebuie sa fie precizat.");
            }
            TeacheriDAL.InserareTeacher(Teacher);
            ListaTeacheri.Add(Teacher);
        }

        public void ActualizareTeacher(Teacher Teacher)
        {
            if (Teacher == null)
            {
                throw new AgendaException("Trebuie selectat un Teacher.");
            }
            if (string.IsNullOrEmpty(Teacher.Nume))
            {
                throw new AgendaException("Numele Teacherului trebuie sa fie precizat.");
            }
            if (string.IsNullOrEmpty(Teacher.Prenume))
            {
                throw new AgendaException("Prenumele Teacherului trebuie sa fie precizat.");
            }
            
            if (string.IsNullOrEmpty(Teacher.Email))
            {
                throw new AgendaException("Email-ul Teacherului trebuie sa fie precizat.");
            }
            TeacheriDAL.ActualizareTeacher(Teacher);
        }

        public void StergereTeacher(Teacher Teacher)
        {
            if (Teacher == null)
            {
                throw new AgendaException("Trebuie selectat un Teacher.");
            }
            else
            {
                ClassDAL ClassDAL = new ClassDAL();
                if (ClassDAL.ObtineToateClaseleDupaTeacher(Teacher).Count > 0)
                {
                    throw new AgendaException("Trebuie sa stergeti mai intai Clasele acestui Teacher!");
                }
                SubjectDAL SubjectDAL = new SubjectDAL();
                if (SubjectDAL.ObtineToateMateriileDupaTeacher(Teacher).Count > 0)
                {
                    throw new AgendaException("Trebuie sa stergeti mai intai Materiile acestui Teacher!");
                }
            }
            TeacheriDAL.StergereTeacher(Teacher);
            ListaTeacheri.Remove(Teacher);
        }
    }
}
