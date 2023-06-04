using System;

namespace PlatformaEducationala.Models.EntityLayer
{
    public class Teacher : BasePropertyChanged
    {
        private int? idTeacher;
        private string nume;
        private string prenume;
        private DateTime dataNastere;
        private string email;
        private bool esteDiriginte;

        public int? IdTeacher
        {
            get
            {
                return idTeacher;
            }
            set
            {
                idTeacher = value;
                NotifyPropertyChanged("IdTeacher");
            }
        }

        public string Nume
        {
            get
            {
                return nume;
            }
            set
            {
                nume = value;
                NotifyPropertyChanged("Nume");
            }
        }

        public string Prenume
        {
            get
            {
                return prenume;
            }
            set
            {
                prenume = value;
                NotifyPropertyChanged("Prenume");
            }
        }

        public DateTime DataNastere
        {
            get
            {
                return dataNastere;
            }
            set
            {
                dataNastere = value;
                NotifyPropertyChanged("DataNastere");
            }
        }

      

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                NotifyPropertyChanged("Email");
            }
        }

        public bool EsteDiriginte
        {
            get
            {
                return esteDiriginte;
            }
            set
            {
                esteDiriginte = value;
                NotifyPropertyChanged("EsteDiriginte");
            }
        }
    }
}
