using PlatformaEducationala.Models.EntityLayer;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace PlatformaEducationala.Models.DataAccessLayer
{
    public class SpecializationDAL
    {
        public ObservableCollection<Specialization> ObtineToateSpecializarile()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ObtineToateSpecializarile", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                ObservableCollection<Specialization> rezultat = new ObservableCollection<Specialization>();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Specialization Specialization = new Specialization();
                    Specialization.IdSpecialization = (int)(reader[0]);
                    Specialization.Denumire = reader.GetString(1);
                    rezultat.Add(Specialization);
                }
                reader.Close();
                return rezultat;
            }
        }

        public void InserareSpecialization(Specialization Specialization)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InserareSpecialization", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruDenumire = new SqlParameter("@denumire", Specialization.Denumire);
                SqlParameter parametruIdSpecialization = new SqlParameter("@Specialization_id", System.Data.SqlDbType.Int)
                {
                    Direction = System.Data.ParameterDirection.Output
                };
                cmd.Parameters.Add(parametruDenumire);
                cmd.Parameters.Add(parametruIdSpecialization);
                con.Open();
                cmd.ExecuteNonQuery();
                Specialization.IdSpecialization = parametruIdSpecialization.Value as int?;
            }
        }

        public void StergereSpecialization(Specialization Specialization)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("StergereSpecialization", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruIdSpecialization = new SqlParameter("@Specialization_id", Specialization.IdSpecialization);
                cmd.Parameters.Add(parametruIdSpecialization);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizareSpecialization(Specialization Specialization)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ActualizareSpecialization", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruIdSpecialization = new SqlParameter("@Specialization_id", Specialization.IdSpecialization);
                SqlParameter parametruDenumire = new SqlParameter("@denumire", Specialization.Denumire);
                cmd.Parameters.Add(parametruIdSpecialization);
                cmd.Parameters.Add(parametruDenumire);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
