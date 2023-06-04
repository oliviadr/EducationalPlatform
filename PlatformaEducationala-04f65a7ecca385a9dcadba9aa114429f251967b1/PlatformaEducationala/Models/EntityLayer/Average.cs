using System;

namespace PlatformaEducationala.Models.EntityLayer
{
    public class Average : BasePropertyChanged
    {
        private int? idAverage;
        private int? idStudent;
        private int? idSubject;
        private decimal grade;

        public int? IdAverage
        {
            get
            {
                return idAverage;
            }
            set
            {
                idAverage = value;
                NotifyPropertyChanged("IdAverage");
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

        public decimal Grade
        {
            get
            {
                return grade;
            }
            set
            {
                grade = value;
                NotifyPropertyChanged("Grade");
            }
        }

        public static implicit operator int(Average v)
        {
            throw new NotImplementedException();
        }
    }
}
