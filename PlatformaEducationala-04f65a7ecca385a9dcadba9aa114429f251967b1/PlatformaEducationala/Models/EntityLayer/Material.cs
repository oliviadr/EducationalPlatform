namespace PlatformaEducationala.Models.EntityLayer
{
    public class Material : BasePropertyChanged
    {
        private int? idMaterial;
        private int? idSubject;
        private byte[] fisier;

        public int? IdMaterial
        {
            get
            {
                return idMaterial;
            }
            set
            {
                idMaterial = value;
                NotifyPropertyChanged("IdMaterial");
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

        public byte[] Fisier
        {
            get
            {
                return fisier;
            }
            set
            {
                fisier = value;
                NotifyPropertyChanged("Fisier");
            }
        }
    }
}
