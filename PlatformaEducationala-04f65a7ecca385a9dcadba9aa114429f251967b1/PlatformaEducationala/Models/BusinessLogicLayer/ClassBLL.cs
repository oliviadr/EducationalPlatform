using PlatformaEducationala.Exceptions;
using PlatformaEducationala.Models.DataAccessLayer;
using PlatformaEducationala.Models.EntityLayer;
using System.Collections.ObjectModel;

namespace PlatformaEducationala.Models.BusinessLogicLayer
{
    public class ClassBLL
    {
        public ObservableCollection<Class> ListaClase { get; set; }

        ClassDAL ClassDAL = new ClassDAL();

        int anStudiu;

        public ClassBLL()
        {
            ListaClase = new ObservableCollection<Class>();
            anStudiu = 0;
        }

        public ObservableCollection<Class> ObtineToateClasele()
        {
            return ClassDAL.ObtineToateClasele();
        }

        public int ObtineAnStudiuDupaClass(int Class)
        {
            return ClassDAL.ObtineAnStudiuDupaClass(Class);
        }

        public void ObtineToateClaseleDupaSpecialization(Specialization Specialization)
        {
            ListaClase.Clear();
            var clase = ClassDAL.ObtineToateClaseleDupaSpecialization(Specialization);
            foreach (var Class in clase)
            {
                ListaClase.Add(Class);
            }
        }

        public void ObtineToateClaseleDupaTeacher(Teacher Teacher)
        {
            ListaClase.Clear();
            var clase = ClassDAL.ObtineToateClaseleDupaTeacher(Teacher);
            foreach (var Class in clase)
            {
                ListaClase.Add(Class);
            }
        }

        public void InserareClass(Class Class)
        {
            if (string.IsNullOrEmpty(Class.AnStudiu.ToString()))
            {
                throw new AgendaException("Anul de studiu al clasei trebuie precizat.");
            }
            if (string.IsNullOrEmpty(Class.Grupa.ToString()))
            {
                throw new AgendaException("Grupa clasei trebuie precizata.");
            }
            ClassDAL.InserareClass(Class);
            ListaClase.Add(Class);
        }

        public void ActualizareClass(Class Class)
        {
            if (Class == null)
            {
                throw new AgendaException("Trebuie selectata o Class.");
            }
            if (string.IsNullOrEmpty(Class.AnStudiu.ToString()))
            {
                throw new AgendaException("Anul de studiu al clasei trebuie precizat.");
            }
            if (string.IsNullOrEmpty(Class.Grupa.ToString()))
            {
                throw new AgendaException("Grupa clasei trebuie precizata.");
            }
            ClassDAL.ActualizareClass(Class);
        }

        public void StergereClass(Class Class)
        {
            if (Class == null)
            {
                throw new AgendaException("Trebuie selectata o Class.");
            }
            else
            {
                StudentDAL StudentDAL = new StudentDAL();
                if (StudentDAL.ObtineTotiStudentiiDupaClass(Class).Count > 0)
                {
                    throw new AgendaException("Trebuie sa stergeti mai intai Studentii din Class cu ID-ul " + Class.IdClass);
                }
            }
            ClassDAL.StergereClass(Class);
            ListaClase.Remove(Class);
        }
    }
}
