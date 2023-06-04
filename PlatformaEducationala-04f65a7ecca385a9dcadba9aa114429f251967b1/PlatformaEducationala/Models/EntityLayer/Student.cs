using System;

namespace PlatformaEducationala.Models.EntityLayer
{
    public class Student : BasePropertyChanged
    {
        private int? idStudent;
        private string nume;
        private string prenume;
        private DateTime dataNastere;
     
        
        private string email;
        private int? idClass;

        public int? IdStudent
        {
            get
            {
                return idStudent;
            }
            set
            {
                idStudent = value;
                NotifyPropertyChanged("IdStudent");
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

        public int? IdClass
        { 
            get
            { 
                return idClass; 
            }
            set
            {
                idClass = value;
                NotifyPropertyChanged("IdClass");
            }
        }
    }
}
