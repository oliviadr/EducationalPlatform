using PlatformaEducationala.Models.EntityLayer;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace PlatformaEducationala.Models.DataAccessLayer
{
    public class SubjectDAL
    {
        public ObservableCollection<Subject> ObtineToateMateriile()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ObtineToateMateriile", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                ObservableCollection<Subject> rezultat = new ObservableCollection<Subject>();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Subject Subject = new Subject
                    {
                        IdSubject = (int)(reader[0]),
                        Nume = reader[1].ToString(),
                        IdTeacher = (int)(reader[2]),
                        AreTeza = Convert.ToBoolean(reader[3]),
                        AnStudiu = (int)(reader[4])
                    };
                    rezultat.Add(Subject);
                }
                reader.Close();
                return rezultat;
            }
        }

        public ObservableCollection<Subject> ObtineToateMateriileDupaTeacher(Teacher Teacher)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                ObservableCollection<Subject> rezultat = new ObservableCollection<Subject>();
                SqlCommand cmd = new SqlCommand("ObtineToateMateriileDupaTeacher", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruTeacherId = new SqlParameter("@Teacher_id", Teacher.IdTeacher);
                cmd.Parameters.Add(parametruTeacherId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) 
                {
                    rezultat.Add(new Subject()
                    {
                        IdSubject = reader.GetInt32(0),
                        Nume = reader.GetString(1),
                        IdTeacher = reader.GetInt32(2),
                        AreTeza = reader.GetBoolean(3),
                        AnStudiu = reader.GetInt32(4)
                    });
                }
                return rezultat;
            }
        }

        public void InserareSubject(Subject Subject)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InserareSubject", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruNume = new SqlParameter("@nume", Subject.Nume);
                SqlParameter parametruIdTeacher = new SqlParameter("@id_Teacher", Subject.IdTeacher);
                SqlParameter parametruAreTeza = new SqlParameter("@are_teza", Convert.ToBoolean(Subject.AreTeza));
                SqlParameter parametruAnStudiu = new SqlParameter("@an_studiu", Subject.AnStudiu);
                SqlParameter parametruSubjectId = new SqlParameter("@Subject_id", System.Data.SqlDbType.Int);
                parametruSubjectId.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(parametruNume);
                cmd.Parameters.Add(parametruIdTeacher);
                cmd.Parameters.Add(parametruAreTeza);
                cmd.Parameters.Add(parametruAnStudiu);
                cmd.Parameters.Add(parametruSubjectId);
                con.Open();
                cmd.ExecuteNonQuery();
                Subject.IdSubject = parametruSubjectId.Value as int?;
            }
        }

        public void StergereSubject(Subject Subject)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("StergereSubject", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruSubjectId = new SqlParameter("@Subject_id", Subject.IdSubject);
                cmd.Parameters.Add(parametruSubjectId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizareSubject(Subject Subject)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ActualizareSubject", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruSubjectId = new SqlParameter("@Subject_id", Subject.IdSubject);
                SqlParameter parametruNume = new SqlParameter("@nume", Subject.Nume);
                SqlParameter parametruIdTeacher = new SqlParameter("@id_Teacher", Subject.IdTeacher);
                SqlParameter parametruAnStudiu = new SqlParameter("@an_studiu", Subject.AnStudiu);
                SqlParameter parametruAreTeza = new SqlParameter("@are_teza", Subject.AreTeza);
                cmd.Parameters.Add(parametruSubjectId);
                cmd.Parameters.Add(parametruNume);
                cmd.Parameters.Add(parametruIdTeacher);
                cmd.Parameters.Add(parametruAnStudiu);
                cmd.Parameters.Add(parametruAreTeza);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
