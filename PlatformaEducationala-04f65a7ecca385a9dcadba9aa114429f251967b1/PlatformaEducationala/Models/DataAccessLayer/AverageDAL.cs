using PlatformaEducationala.Models.EntityLayer;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace PlatformaEducationala.Models.DataAccessLayer
{
    public class AverageDAL
    {
        public ObservableCollection<Average> ObtineToateMediile()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ObtineToateMediile", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                ObservableCollection<Average> rezultat = new ObservableCollection<Average>();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Average Average = new Average
                    {
                        IdAverage = reader.GetInt32(0),
                        IdStudent = reader.GetInt32(1),
                        IdSubject = reader.GetInt32(2),
                        Grade = reader.GetDecimal(3)
                    };
                    rezultat.Add(Average);
                }
                reader.Close();
                return rezultat;
            }
        }

        public void InserareAverage(Average Average)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InserareAverage", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruIdStudent = new SqlParameter("@id_Student", Average.IdStudent);
                SqlParameter parametruIdSubject = new SqlParameter("@id_Subject", Average.IdSubject);
                SqlParameter parametruGrade = new SqlParameter("@Grade", Average.Grade);
                SqlParameter parametruAverageId = new SqlParameter("@Average_id", System.Data.SqlDbType.Int);
                parametruAverageId.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(parametruIdStudent);
                cmd.Parameters.Add(parametruIdSubject);
                cmd.Parameters.Add(parametruGrade);
                cmd.Parameters.Add(parametruAverageId);
                con.Open();
                cmd.ExecuteNonQuery();
                Average.IdAverage = parametruAverageId.Value as int?;
            }
        }

        public void StergereAverage(Average Average)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("StergereAverage", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruIdAverage = new SqlParameter("@Average_id", Average.IdAverage);
                cmd.Parameters.Add(parametruIdAverage);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizareAverage(Average Average)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ActualizareAverage", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruAverageId = new SqlParameter("@Average_id", Average.IdAverage);
                SqlParameter parametruIdStudent = new SqlParameter("@id_Student", Average.IdStudent);
                SqlParameter parametruIdSubject = new SqlParameter("@id_Subject", Average.IdSubject);
                SqlParameter parametruGrade = new SqlParameter("@Grade", Average.Grade);
                cmd.Parameters.Add(parametruAverageId);
                cmd.Parameters.Add(parametruIdStudent);
                cmd.Parameters.Add(parametruIdSubject);
                cmd.Parameters.Add(parametruGrade);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public ObservableCollection<Average> ObtineToateMediileDupaStudent(Student Student)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                ObservableCollection<Average> rezultat = new ObservableCollection<Average>();
                SqlCommand cmd = new SqlCommand("ObtineToateMediileDupaStudent", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruSubjectId = new SqlParameter("@Student_id", Student.IdStudent);
                cmd.Parameters.Add(parametruSubjectId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rezultat.Add(new Average()
                    {
                        IdAverage = reader.GetInt32(0),
                        IdStudent = reader.GetInt32(1),
                        IdSubject = reader.GetInt32(2),
                        Grade = reader.GetDecimal(3)
                    });
                }
                return rezultat;
            }    
        }

        public ObservableCollection<Average> ObtineToateMediileDupaSubject(Subject Subject)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                ObservableCollection<Average> rezultat = new ObservableCollection<Average>();
                SqlCommand cmd = new SqlCommand("ObtineToateMediileDupaSubject", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruSubjectId = new SqlParameter("@Subject_id", Subject.IdSubject);
                cmd.Parameters.Add(parametruSubjectId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rezultat.Add(new Average()
                    {
                        IdAverage = reader.GetInt32(0),
                        IdStudent = reader.GetInt32(1),
                        IdSubject = reader.GetInt32(2),
                        Grade = reader.GetDecimal(3)
                    });
                }
                return rezultat;
            }
        }
    }
}
