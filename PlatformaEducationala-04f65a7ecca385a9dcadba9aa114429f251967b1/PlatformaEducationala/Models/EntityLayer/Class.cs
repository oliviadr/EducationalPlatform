namespace PlatformaEducationala.Models.EntityLayer
{
    public class Class : BasePropertyChanged
    {
        private int? idClass;
        private int? idSpecialization;
        private int? idDiriginte;
        private int anStudiu;
        private string grupa;

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

        public int? IdSpecialization
        {
            get
            {
                return idSpecialization;
            }
            set
            {
                idSpecialization = value;
                NotifyPropertyChanged("IdSpecialization");
            }
        }

        public int? IdDiriginte
        {
            get
            { 
                return idDiriginte;
            }
            set
            {
                idDiriginte = value;
                NotifyPropertyChanged("IdDiriginte");
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

        public string Grupa
        {
            get
            {
                return grupa;
            }
            set
            {
                grupa = value;
                NotifyPropertyChanged("Grupa");
            }
        }
    }
}
