namespace PlatformaEducationala.Models.EntityLayer
{
    public class Specialization : BasePropertyChanged
    {
        private int? idSpecialization;
        private string denumire;

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

        public string Denumire
        {
            get
            { 
                return denumire;
            }
            set
            {
                denumire = value;
                NotifyPropertyChanged("Denumire");
            }
        }
    }
}
