using PlatformaEducationala.Models.EntityLayer;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace PlatformaEducationala.Models.DataAccessLayer
{
    public class MaterialDAL
    {
        public ObservableCollection<Material> ObtineToateMaterialele()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ObtineToateMaterialele", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                ObservableCollection<Material> rezultat = new ObservableCollection<Material>();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Material material = new Material
                    {
                        IdMaterial = reader.GetInt32(0),
                        IdSubject = reader.GetInt32(1),
                        Fisier = (byte[])reader[2]
                    };
                    rezultat.Add(material);
                }
                reader.Close();
                return rezultat;
            }
        }

        public void InserareMaterial(Material material)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InserareMaterial", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruIdSubject = new SqlParameter("@id_Subject", material.IdSubject);
                SqlParameter parametruFisier = new SqlParameter("@fisier", material.Fisier);
                SqlParameter parametruMaterialId = new SqlParameter("@material_id", System.Data.SqlDbType.Int);
                parametruMaterialId.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(parametruIdSubject);
                cmd.Parameters.Add(parametruFisier);
                cmd.Parameters.Add(parametruMaterialId);
                con.Open();
                cmd.ExecuteNonQuery();
                material.IdMaterial = parametruMaterialId.Value as int?;
            }
        }

        public void StergereMaterial(Material material)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("StergereMaterial", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruIdMaterial = new SqlParameter("@material_id", material.IdMaterial);
                cmd.Parameters.Add(parametruIdMaterial);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizareMaterial(Material material)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ActualizareMaterial", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruMaterialId = new SqlParameter("@material_id", material.IdMaterial);
                SqlParameter parametruIdSubject = new SqlParameter("@id_Subject", material.IdSubject);
                SqlParameter parametruFisier = new SqlParameter("@fisier", material.Fisier);
                cmd.Parameters.Add(parametruMaterialId);
                cmd.Parameters.Add(parametruIdSubject);
                cmd.Parameters.Add(parametruFisier);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public ObservableCollection<Material> ObtineToateMaterialeleDupaSubject(Subject Subject)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                ObservableCollection<Material> rezultat = new ObservableCollection<Material>();
                SqlCommand cmd = new SqlCommand("ObtineToateMaterialeleDupaSubject", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruSubjectId = new SqlParameter("@Subject_id", Subject.IdSubject);
                cmd.Parameters.Add(parametruSubjectId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rezultat.Add(new Material()
                    {
                        IdMaterial = reader.GetInt32(0),
                        IdSubject = reader.GetInt32(1),
                        Fisier = (byte[])reader[2]
                    });
                }
                return rezultat;
            }
        }

        public ObservableCollection<Material> ObtineToateMaterialeleDupaSubjectDupaTeacher(int TeacherId)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                ObservableCollection<Material> rezultat = new ObservableCollection<Material>();
                SqlCommand cmd = new SqlCommand("ObtineToateMaterialeleDupaSubjectDupaTeacher", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruTeacherId = new SqlParameter("@Teacher_id", TeacherId);
                cmd.Parameters.Add(parametruTeacherId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rezultat.Add(new Material()
                    {
                        IdMaterial = reader.GetInt32(0),
                        IdSubject = reader.GetInt32(1),
                        Fisier = (byte[])reader[2]
                    });
                }
                return rezultat;
            }
        }
    }
}
