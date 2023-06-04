using PlatformaEducationala.Exceptions;
using PlatformaEducationala.Models.DataAccessLayer;
using PlatformaEducationala.Models.EntityLayer;
using System.Collections.ObjectModel;

namespace PlatformaEducationala.Models.BusinessLogicLayer
{
    public class MaterialBLL
    {
        public ObservableCollection<Material> ListaMateriale { get; set; }

        MaterialDAL materialDAL = new MaterialDAL();

        public MaterialBLL()
        {
            ListaMateriale = new ObservableCollection<Material>();
        }

        public ObservableCollection<Material> ObtineToateMaterialele()
        {
            return materialDAL.ObtineToateMaterialele();
        }

        public ObservableCollection<Material> ObtineToateMaterialeleDupaSubjectDupaTeacher(int TeacherId)
        {
            return materialDAL.ObtineToateMaterialeleDupaSubjectDupaTeacher(TeacherId);
        }

        public void InserareMaterial(Material material)
        {
            if (string.IsNullOrEmpty(material.IdSubject.ToString()))
            {
                throw new AgendaException("ID-ul Subjecti trebuie precizat.");
            }
            if (string.IsNullOrEmpty(material.Fisier.ToString()))
            {
                throw new AgendaException("Fisierul materialului trebuie precizat.");
            }
            materialDAL.InserareMaterial(material);
            ListaMateriale.Add(material);
        }

        public void ActualizareMaterial(Material material)
        {
            if (material == null)
            {
                throw new AgendaException("Trebuie selectat un material.");
            }
            if (string.IsNullOrEmpty(material.IdSubject.ToString()))
            {
                throw new AgendaException("ID-ul Subjecti trebuie precizat.");
            }
            if (string.IsNullOrEmpty(material.Fisier.ToString()))
            {
                throw new AgendaException("Fisierul materialului trebuie precizat.");
            }
            materialDAL.ActualizareMaterial(material);
        }

        public void StergereMaterial(Material material)
        {
            if (material == null)
            {
                throw new AgendaException("Trebuie selectat un material.");
            }
            materialDAL.StergereMaterial(material);
            ListaMateriale.Remove(material);
        }
    }
}
