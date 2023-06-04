using PlatformaEducationala.Models.EntityLayer;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace PlatformaEducationala.Models.DataAccessLayer
{
    public class ClassDAL
    {
        public ObservableCollection<Class> ObtineToateClasele()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("ObtineToateClasele", con);
                ObservableCollection<Class> rezultat = new ObservableCollection<Class>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Class Class = new Class
                    {
                        IdClass = (int)reader[0],
                        IdSpecialization = (int)reader[1],
                        IdDiriginte = (int)reader[2],
                        AnStudiu = (int)reader[3],
                        Grupa = reader[4].ToString()
                    };
                    rezultat.Add(Class);
                }
                reader.Close();
                return rezultat;
            }
            finally
            { 
                con.Close(); 
            }
        }

        public int ObtineAnStudiuDupaClass(int Class)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                int rezultat = 0;
                SqlCommand cmd = new SqlCommand("ObtineAnStudiuDupaClass", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruClassId = new SqlParameter("@Class_id", Class);
                cmd.Parameters.Add(parametruClassId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rezultat = (int)reader[0];
                    break;
                }
                return rezultat;
            }
        }

        public void InserareClass(Class Class)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InserareClass", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruIdSpecialization = new SqlParameter("@id_Specialization", Class.IdSpecialization);
                SqlParameter parametruIdDiriginte = new SqlParameter("@id_diriginte", Class.IdDiriginte);
                SqlParameter parametruAnStudiu = new SqlParameter("@an_studiu", Class.AnStudiu);
                SqlParameter parametruGrupa = new SqlParameter("@grupa", Class.Grupa);
                SqlParameter parametruClassId = new SqlParameter("@Class_id", System.Data.SqlDbType.Int);
                parametruClassId.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(parametruIdSpecialization);
                cmd.Parameters.Add(parametruIdDiriginte);
                cmd.Parameters.Add(parametruAnStudiu);
                cmd.Parameters.Add(parametruGrupa);
                cmd.Parameters.Add(parametruClassId);
                con.Open();
                cmd.ExecuteNonQuery();
                Class.IdClass = parametruClassId.Value as int?;
            }
        }

        public void StergereClass(Class Class)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("StergereClass", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruClassId = new SqlParameter("@Class_id", Class.IdClass);
                cmd.Parameters.Add(parametruClassId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizareClass(Class Class)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ActualizareClass", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruClassId = new SqlParameter("@Class_id", Class.IdClass);
                SqlParameter parametruIdSpecialization = new SqlParameter("@id_Specialization", Class.IdSpecialization);
                SqlParameter parametruIdDiriginte = new SqlParameter("@id_diriginte", Class.IdDiriginte);
                SqlParameter parametruAnStudiu = new SqlParameter("@an_studiu", Class.AnStudiu);
                SqlParameter parametruGrupa = new SqlParameter("@grupa", Class.Grupa);
                cmd.Parameters.Add(parametruClassId);
                cmd.Parameters.Add(parametruIdSpecialization);
                cmd.Parameters.Add(parametruIdDiriginte);
                cmd.Parameters.Add(parametruAnStudiu);
                cmd.Parameters.Add(parametruGrupa);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public ObservableCollection<Class> ObtineToateClaseleDupaSpecialization(Specialization Specialization)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                ObservableCollection<Class> rezultat = new ObservableCollection<Class>();
                SqlCommand cmd = new SqlCommand("ObtineToateClaseleDupaSpecialization", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruIdSpecialization = new SqlParameter("@Specialization_id", Specialization.IdSpecialization);
                cmd.Parameters.Add(parametruIdSpecialization);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rezultat.Add(new Class()
                    {
                        IdClass = reader.GetInt32(0),
                        IdSpecialization = reader.GetInt32(1),
                        IdDiriginte = reader.GetInt32(2),
                        AnStudiu = reader.GetInt32(3),
                        Grupa = reader[4].ToString()
                    });
                }
                return rezultat;
            }
        }

        public ObservableCollection<Class> ObtineToateClaseleDupaTeacher(Teacher Teacher)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                ObservableCollection<Class> rezultat = new ObservableCollection<Class>();
                SqlCommand cmd = new SqlCommand("ObtineToateClaseleDupaTeacher", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruIdSpecialization = new SqlParameter("@Teacher_id", Teacher.IdTeacher);
                cmd.Parameters.Add(parametruIdSpecialization);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rezultat.Add(new Class()
                    {
                        IdClass = reader.GetInt32(0),
                        IdSpecialization = reader.GetInt32(1),
                        IdDiriginte = reader.GetInt32(2),
                        AnStudiu = reader.GetInt32(3),
                        Grupa = reader[4].ToString()
                    });
                }
                return rezultat;
            }
        }
    }
}
