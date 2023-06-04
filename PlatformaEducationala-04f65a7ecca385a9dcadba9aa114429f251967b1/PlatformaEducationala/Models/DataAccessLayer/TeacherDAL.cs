using PlatformaEducationala.Models.EntityLayer;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace PlatformaEducationala.Models.DataAccessLayer
{
    public class TeacherDAL
    {
        public ObservableCollection<Teacher> ObtineTotiTeacherii()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ObtineTotiTeacherii", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                ObservableCollection<Teacher> rezultat = new ObservableCollection<Teacher>();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Teacher Teacher = new Teacher
                    {
                        IdTeacher = (int)(reader[0]),
                        Nume = reader[1].ToString(),
                        Prenume = reader[2].ToString(),
                        DataNastere = reader.GetDateTime(3),
                        Email = reader[4].ToString(),
                        EsteDiriginte = Convert.ToBoolean(reader[5].ToString())
                    };
                    rezultat.Add(Teacher);
                }
                reader.Close();
                return rezultat;
            }
        }

        public ObservableCollection<Teacher> ObtineTotiDirigintii()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ObtineTotiDirigintii", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                ObservableCollection<Teacher> rezultat = new ObservableCollection<Teacher>();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Teacher teacher = new Teacher
                    {
                        IdTeacher = (int)reader[0],
                        Nume = reader[1].ToString(),
                        Prenume = reader[2].ToString(),
                        DataNastere = reader.GetDateTime(3),
                        Email = reader[4].ToString(),
                        EsteDiriginte = true // Setează variabila booleană "esteDiriginte" ca "true"
                    };
                    rezultat.Add(teacher);
                }
                reader.Close();
                return rezultat;
            }
        }


        public Teacher ObtineTeacherDupaId(int idTeacher)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                Teacher Teacher = new Teacher();
                SqlCommand cmd = new SqlCommand("ObtineTeacherDupaId", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruTeacherId = new SqlParameter("@Teacher_id", idTeacher);
                cmd.Parameters.Add(parametruTeacherId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Teacher.IdTeacher = (int)(reader[0]);
                    Teacher.Nume = reader[1].ToString();
                    Teacher.Prenume = reader[2].ToString();
                    Teacher.DataNastere = reader.GetDateTime(3);
               
                    Teacher.Email = reader[4].ToString();
                    Teacher.EsteDiriginte = Convert.ToBoolean(reader[5].ToString());
                }
                return Teacher;
            }
        }

        public void InserareTeacher(Teacher Teacher)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InserareTeacher", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruNume = new SqlParameter("@nume", Teacher.Nume);
                SqlParameter parametruPrenume = new SqlParameter("@prenume", Teacher.Prenume);
                SqlParameter parametruDataNastere = new SqlParameter("@data_nastere", Convert.ToDateTime(Teacher.DataNastere));
                SqlParameter parametruEmail = new SqlParameter("@email", Teacher.Email);
                SqlParameter parametruEsteDiriginte = new SqlParameter("@este_diriginte", Convert.ToBoolean(Teacher.EsteDiriginte));
                SqlParameter parametruTeacherId = new SqlParameter("@Teacher_id", System.Data.SqlDbType.Int);
                parametruTeacherId.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(parametruNume);
                cmd.Parameters.Add(parametruPrenume);
                cmd.Parameters.Add(parametruDataNastere);
                cmd.Parameters.Add(parametruEmail);
                cmd.Parameters.Add(parametruEsteDiriginte);
                cmd.Parameters.Add(parametruTeacherId);
                con.Open();
                cmd.ExecuteNonQuery();
                Teacher.IdTeacher = parametruTeacherId.Value as int?;
            }
        }

        public void StergereTeacher(Teacher Teacher)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("StergereTeacher", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruTeacherId = new SqlParameter("@Teacher_id", Teacher.IdTeacher);
                cmd.Parameters.Add(parametruTeacherId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        
        public void ActualizareTeacher(Teacher Teacher)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ActualizareTeacher", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruTeacherId = new SqlParameter("@Teacher_id", Teacher.IdTeacher);
                SqlParameter parametruNume = new SqlParameter("@nume", Teacher.Nume);
                SqlParameter parametruPrenume = new SqlParameter("@prenume", Teacher.Prenume);
                SqlParameter parametruDataNastere = new SqlParameter("@data_nastere", Teacher.DataNastere);
                SqlParameter parametruEmail = new SqlParameter("@email", Teacher.Email);
                SqlParameter parametruEsteDiriginte = new SqlParameter("@este_diriginte", Teacher.EsteDiriginte);
                cmd.Parameters.Add(parametruNume);
                cmd.Parameters.Add(parametruPrenume);
                cmd.Parameters.Add(parametruDataNastere);
                cmd.Parameters.Add(parametruEmail);
                cmd.Parameters.Add(parametruEsteDiriginte);
                cmd.Parameters.Add(parametruTeacherId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
