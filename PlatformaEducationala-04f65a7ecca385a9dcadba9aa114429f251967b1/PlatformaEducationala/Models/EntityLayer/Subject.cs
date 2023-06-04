namespace PlatformaEducationala.Models.EntityLayer
{
    public class Subject : BasePropertyChanged
    {
        private int? idSubject;
        private string nume;
        private int? idTeacher;
        private bool areTeza;
        private int anStudiu;

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

        public bool AreTeza
        {
            get
            {
                return areTeza;
            }
            set
            {
                areTeza = value;
                NotifyPropertyChanged("AreTeza");
            }
        }

        public int AnStudiu
        {
            get
            {
                return anStudiu;
            }
            set
            { 
                anStudiu = value;
                NotifyPropertyChanged("AnStudiu");
            }
        }
    }
}
