using PlatformaEducationala.Models.EntityLayer;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace PlatformaEducationala.Models.DataAccessLayer
{
    public class GradeDAL
    {
        public ObservableCollection<Grade> ObtineToateNotele()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ObtineToateNotele", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                ObservableCollection<Grade> rezultat = new ObservableCollection<Grade>();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Grade Grade = new Grade
                    {
                        IdGrade = (int)reader[0],
                        IdSubject = (int)reader[1],
                        Valoare = (int)reader[2],
                        EsteTeza = Convert.ToBoolean(reader[3]),
                        Semestru = (int)reader[4],
                        AverageIncheiata = Convert.ToBoolean(reader[5]),
                        IdStudent = (int)reader[6]
                    };
                    rezultat.Add(Grade);
                }
                reader.Close();
                return rezultat;
            }
        }

        public ObservableCollection<Grade> ObtineToateNoteleDupaSubject(Subject Subject)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                ObservableCollection<Grade> rezultat = new ObservableCollection<Grade>();
                SqlCommand cmd = new SqlCommand("ObtineToateNoteleDupaSubject", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruSubjectId = new SqlParameter("@Subject_id", Subject.IdSubject);
                cmd.Parameters.Add(parametruSubjectId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rezultat.Add(new Grade()
                    {
                        IdGrade = reader.GetInt32(0),
                        IdSubject = reader.GetInt32(1),
                        Valoare = reader.GetInt32(2),
                        EsteTeza = reader.GetBoolean(3),
                        Semestru = reader.GetInt32(4),
                        AverageIncheiata = reader.GetBoolean(5),
                        IdStudent = reader.GetInt32(6)
                    });
                }
                return rezultat;
            }
        }

        public void InserareGrade(Grade Grade)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InserareGrade", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruIdSubject = new SqlParameter("@id_Subject", Grade.IdSubject);
                SqlParameter parametruValoare = new SqlParameter("@valoare", Grade.Valoare);
                SqlParameter parametruEsteTeza = new SqlParameter("@este_teza", Convert.ToBoolean(Grade.EsteTeza));
                SqlParameter parametruSemestru = new SqlParameter("@semestru", Grade.Semestru);
                SqlParameter parametruAverageIncheiata = new SqlParameter("@Average_incheiata", Convert.ToBoolean(Grade.AverageIncheiata));
                SqlParameter parametruIdStudent = new SqlParameter("@id_Student", Grade.IdStudent);
                SqlParameter parametruGradeId = new SqlParameter("@Grade_id", System.Data.SqlDbType.Int);
                parametruGradeId.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(parametruIdSubject);
                cmd.Parameters.Add(parametruValoare);
                cmd.Parameters.Add(parametruEsteTeza);
                cmd.Parameters.Add(parametruSemestru);
                cmd.Parameters.Add(parametruAverageIncheiata);
                cmd.Parameters.Add(parametruIdStudent);
                cmd.Parameters.Add(parametruGradeId);
                con.Open();
                cmd.ExecuteNonQuery();
                Grade.IdGrade = parametruGradeId.Value as int?;
            }
        }

        public void StergereGrade(Grade Grade)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("StergereGrade", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruGradeId = new SqlParameter("@Grade_id", Grade.IdGrade);
                cmd.Parameters.Add(parametruGradeId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizareGrade(Grade Grade)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ActualizareGrade", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruGradeId = new SqlParameter("@Grade_id", Grade.IdGrade);
                SqlParameter parametruIdSubject = new SqlParameter("@id_Subject", Grade.IdSubject);
                SqlParameter parametruValoare = new SqlParameter("@valoare", Grade.Valoare);
                SqlParameter parametruEsteTeza = new SqlParameter("@este_teza", Convert.ToBoolean(Grade.EsteTeza));
                SqlParameter parametruSemestru = new SqlParameter("@semestru", Grade.Semestru);
                SqlParameter parametruAverageIncheiata = new SqlParameter("@Average_incheiata", Convert.ToBoolean(Grade.AverageIncheiata));
                SqlParameter parametruIdStudent = new SqlParameter("@id_Student", Grade.IdStudent);
                cmd.Parameters.Add(parametruGradeId);
                cmd.Parameters.Add(parametruIdSubject);
                cmd.Parameters.Add(parametruValoare);
                cmd.Parameters.Add(parametruEsteTeza);
                cmd.Parameters.Add(parametruSemestru);
                cmd.Parameters.Add(parametruAverageIncheiata);
                cmd.Parameters.Add(parametruIdStudent);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public ObservableCollection<Grade> ObtineToateAbsenteleDupaSubjectDupaTeacher(int TeacherId)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                ObservableCollection<Grade> rezultat = new ObservableCollection<Grade>();
                SqlCommand cmd = new SqlCommand("ObtineToateNoteleDupaSubjectDupaTeacher", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruTeacherId = new SqlParameter("@Teacher_id", TeacherId);
                cmd.Parameters.Add(parametruTeacherId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rezultat.Add(new Grade()
                    {
                        IdGrade = reader.GetInt32(0),
                        IdSubject = reader.GetInt32(1),
                        Valoare = reader.GetInt32(2),
                        EsteTeza = reader.GetBoolean(3),
                        Semestru = reader.GetInt32(4),
                        AverageIncheiata = reader.GetBoolean(5),
                        IdStudent = reader.GetInt32(6)
                    });
                }
                return rezultat;
            }
        }
    }
}
