namespace PlatformaEducationala.Models.EntityLayer
{
    public class Grade : BasePropertyChanged
    {
        private int? idGrade;
        private int? idSubject;
        private int valoare;
        private bool esteTeza;
        private int semestru;
        private bool averageIncheiata;
        private int? idStudent;

        public int? IdGrade
        {
            get
            {
                return idGrade;
            }
            set
            {
                idGrade = value;
                NotifyPropertyChanged("IdGrade");
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

        public int Valoare
        {
            get
            { 
                return valoare; 
            }
            set
            {
                valoare = value;
                NotifyPropertyChanged("Valoare");
            }
        }

        public bool EsteTeza
        {
            get
            {
                return esteTeza;
            }
            set
            {
                esteTeza = value;
                NotifyPropertyChanged("EsteTeza");
            }
        }

        public int Semestru
        {
            get
            {
                return semestru;
            }
            set
            {
                semestru = value;
                NotifyPropertyChanged("Semestru");
            }
        }

        public bool AverageIncheiata
        {
            get
            {
                return averageIncheiata;
            }
            set
            {
                averageIncheiata = value;
                NotifyPropertyChanged("AverageIncheiata");
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
    }
}
