using PlatformaEducationala.Models.EntityLayer;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace PlatformaEducationala.Models.DataAccessLayer
{
    public class StudentDAL
    {
        public ObservableCollection<Student> ObtineTotiStudentii()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ObtineTotiStudentii", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                ObservableCollection<Student> rezultat = new ObservableCollection<Student>();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student Student = new Student
                    {
                        IdStudent = (int)(reader[0]),
                        Nume = reader[1].ToString(),
                        Prenume = reader[2].ToString(),
                        DataNastere = reader.GetDateTime(3),
                        Email = reader[4].ToString(),
                        IdClass = (int)(reader[5])
                    };
                    rezultat.Add(Student);
                }
                reader.Close();
                return rezultat;
            }
        }

        public ObservableCollection<Student> ObtineTotiStudentiiDupaSubjectDupaTeacher(int id)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ObtineTotiStudentiiDupaSubjectDupaTeacher", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                ObservableCollection<Student> rezultat = new ObservableCollection<Student>();
                SqlParameter parametruTeacherId = new SqlParameter("@Teacher_id", id);
                cmd.Parameters.Add(parametruTeacherId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student Student = new Student
                    {
                        IdStudent = (int)(reader[0]),
                        Nume = reader[1].ToString(),
                        Prenume = reader[2].ToString(),
                        DataNastere = reader.GetDateTime(3),
                        
                       
                        Email = reader[4].ToString(),
                        IdClass = (int)(reader[5])
                    };
                    rezultat.Add(Student);
                }
                reader.Close();
                return rezultat;
            }
        }

        public Student ObtineStudentDupaId(int StudentId)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                Student rezultat = new Student();
                SqlCommand cmd = new SqlCommand("ObtineStudentDupaId", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruStudentId = new SqlParameter("@Student_id", StudentId);
                cmd.Parameters.Add(parametruStudentId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rezultat.IdStudent = (int)reader[0];
                    rezultat.Nume = reader[1].ToString();
                    rezultat.Prenume = reader[2].ToString();    
                    rezultat.DataNastere = (DateTime)reader[3];
                    
                   
                    rezultat.Email = reader[4].ToString();
                    rezultat.IdClass = (int)reader[5];
                }
                return rezultat;
            }
        }

        public ObservableCollection<Student> ObtineTotiStudentiiDupaClass(Class Class)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                ObservableCollection<Student> rezultat = new ObservableCollection<Student>();
                SqlCommand cmd = new SqlCommand("ObtineTotiStudentiiDupaClass", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruClassId = new SqlParameter("@Class_id", Class.IdClass);
                cmd.Parameters.Add(parametruClassId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rezultat.Add(new Student()
                    {
                        IdStudent = reader.GetInt32(0),
                        Nume = reader.GetString(1),
                        Prenume = reader.GetString(2),
                        DataNastere = reader.GetDateTime(3),
                       
                     
                        Email = reader.GetString(4),
                        IdClass = reader.GetInt32(5)
                    });
                }
                return rezultat;
            }
        }

        public void InserareStudent(Student Student)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InserareStudent", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruNume = new SqlParameter("@nume", Student.Nume);
                SqlParameter parametruPrenume = new SqlParameter("@prenume", Student.Prenume);
                SqlParameter parametruDataNastere = new SqlParameter("@data_nastere", Convert.ToDateTime(Student.DataNastere));
               
               
                SqlParameter parametruEmail = new SqlParameter("@email", Student.Email);
                SqlParameter parametruIdClass = new SqlParameter("@id_Class", Student.IdClass);
                SqlParameter parametruStudentId = new SqlParameter("@Student_id", System.Data.SqlDbType.Int);
                parametruStudentId.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(parametruNume);
                cmd.Parameters.Add(parametruPrenume);
                cmd.Parameters.Add(parametruDataNastere);
              
               
                cmd.Parameters.Add(parametruEmail);
                cmd.Parameters.Add(parametruIdClass);
                cmd.Parameters.Add(parametruStudentId);
                con.Open();
                cmd.ExecuteNonQuery();
                Student.IdStudent = parametruStudentId.Value as int?;
            }
        }

        public void StergereStudent(Student Student)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("StergereStudent", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruStudentId = new SqlParameter("@Student_id", Student.IdStudent);
                cmd.Parameters.Add(parametruStudentId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizareStudent(Student Student)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ActualizareStudent", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruStudentId = new SqlParameter("@Student_id", Student.IdStudent);
                SqlParameter parametruNume = new SqlParameter("@nume", Student.Nume);
                SqlParameter parametruPrenume = new SqlParameter("@prenume", Student.Prenume);
                SqlParameter parametruDataNastere = new SqlParameter("@data_nastere", Convert.ToDateTime(Student.DataNastere));
               
                
                SqlParameter parametruEmail = new SqlParameter("@email", Student.Email);
                SqlParameter parametruIdClass = new SqlParameter("@id_Class", Student.IdClass);
                cmd.Parameters.Add(parametruStudentId);
                cmd.Parameters.Add(parametruNume);
                cmd.Parameters.Add(parametruPrenume);
                cmd.Parameters.Add(parametruDataNastere);
                
               
                cmd.Parameters.Add(parametruEmail);
                cmd.Parameters.Add(parametruIdClass);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
