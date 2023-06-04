using System;

namespace PlatformaEducationala.Models.EntityLayer
{
    public class Absence : BasePropertyChanged
    {
        private int? idAbsence;
        private int? idSubject;
        private int? idStudent;
        private DateTime dataAbsence;
        private bool esteMotivata;

        public int? IdAbsence
        {
            get
            { 
                return idAbsence; 
            }
            set
            {
                idAbsence = value;
                NotifyPropertyChanged("IdAbsence");
            }
        }

        public int? IdSubject
        { 
            get 
            { 
                return idSubject;
            } 
            set
            {
                idSubject = value;
                NotifyPropertyChanged("IdSubject");
            }
        }

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

        public DateTime DataAbsence
        {
            get
            {
                return dataAbsence;
            }
            set
            {
                dataAbsence = value;
                NotifyPropertyChanged("DataAbsence");
            }
        }

        public bool EsteMotivata
        {
            get
            {
                return esteMotivata;
            }
            set
            {
                esteMotivata = value;
                NotifyPropertyChanged("EsteMotivata");
            }
        }
    }
}
