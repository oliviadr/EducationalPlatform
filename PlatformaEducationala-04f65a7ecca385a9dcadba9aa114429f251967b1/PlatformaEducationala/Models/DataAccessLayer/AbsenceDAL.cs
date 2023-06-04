using PlatformaEducationala.Models.EntityLayer;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace PlatformaEducationala.Models.DataAccessLayer
{
    public class AbsenceDAL
    {
        public ObservableCollection<Absence> ObtineToateAbsentele()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ObtineToateAbsentele", con);
                ObservableCollection<Absence> rezultat = new ObservableCollection<Absence>();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Absence Absence = new Absence
                    {
                        IdAbsence = reader.GetInt32(0),
                        IdSubject = reader.GetInt32(1),
                        IdStudent = reader.GetInt32(2),
                        DataAbsence = reader.GetDateTime(3),
                        EsteMotivata = reader.GetBoolean(4)
                    };
                    rezultat.Add(Absence);
                }
                reader.Close();
                return rezultat;
            }
        }

        public void InserareAbsence(Absence Absence)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InserareAbsence", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruIdSubject = new SqlParameter("@id_Subject", Absence.IdSubject);
                SqlParameter parametruIdStudent = new SqlParameter("@id_Student", Absence.IdStudent);
                SqlParameter parametruDataAbsence = new SqlParameter("@data_Absence", Absence.DataAbsence);
                SqlParameter parametruEsteMotivata = new SqlParameter("@este_motiva", Absence.EsteMotivata);
                SqlParameter parametruAbsenceId = new SqlParameter("@Absence_id", System.Data.SqlDbType.Int);
                parametruAbsenceId.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(parametruIdSubject);
                cmd.Parameters.Add(parametruIdStudent);
                cmd.Parameters.Add(parametruDataAbsence);
                cmd.Parameters.Add(parametruEsteMotivata);
                cmd.Parameters.Add(parametruAbsenceId);
                con.Open();
                cmd.ExecuteNonQuery();
                Absence.IdAbsence = parametruAbsenceId.Value as int?;
            }
        }

        public void ActualizareAbsence(Absence Absence)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ActualizareAbsence", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruAbsenceId = new SqlParameter("@Absence_id", Absence.IdAbsence);
                SqlParameter parametruIdSubject = new SqlParameter("@id_Subject", Absence.IdSubject);
                SqlParameter parametruIdStudent = new SqlParameter("@id_Student", Absence.IdStudent);
                SqlParameter parametruDataAbsence = new SqlParameter("@data_Absence", Convert.ToDateTime(Absence.DataAbsence));
                SqlParameter parametruEsteMotivata = new SqlParameter("@este_motivata", Absence.EsteMotivata);
                cmd.Parameters.Add(parametruAbsenceId);
                cmd.Parameters.Add(parametruIdSubject);
                cmd.Parameters.Add(parametruIdStudent);
                cmd.Parameters.Add(parametruDataAbsence);
                cmd.Parameters.Add(parametruEsteMotivata);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void StergereAbsence(Absence Absence)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("StergereAbsence", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruAbsenceId = new SqlParameter("@Absence_id", Absence.IdAbsence);
                cmd.Parameters.Add(parametruAbsenceId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public ObservableCollection<Absence> ObtineToateAbsenteleDupaStudent(Student Student)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                ObservableCollection<Absence> rezultat = new ObservableCollection<Absence>();
                SqlCommand cmd = new SqlCommand("ObtineToateAbsenteleDupaStudent", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruStudentId = new SqlParameter("@Student_id", Student.IdStudent);
                cmd.Parameters.Add(parametruStudentId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rezultat.Add(new Absence()
                    {
                        IdAbsence = reader.GetInt32(0),
                        IdSubject = reader.GetInt32(1),
                        IdStudent = reader.GetInt32(2),
                        DataAbsence = reader.GetDateTime(3),
                        EsteMotivata = reader.GetBoolean(4)
                    });
                }
                return rezultat;
            }
        }

        public ObservableCollection<Absence> ObtineToateAbsenteleDupaSubject(Subject Subject)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                ObservableCollection<Absence> rezultat = new ObservableCollection<Absence>();
                SqlCommand cmd = new SqlCommand("ObtineToateAbsenteleDupaSubject", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruSubjectId = new SqlParameter("@Subject_id", Subject.IdSubject);
                cmd.Parameters.Add(parametruSubjectId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rezultat.Add(new Absence()
                    {
                        IdAbsence = reader.GetInt32(0),
                        IdSubject = reader.GetInt32(1),
                        IdStudent = reader.GetInt32(2),
                        DataAbsence = reader.GetDateTime(3),
                        EsteMotivata = reader.GetBoolean(4)
                    });
                }
                return rezultat;
            }
        }

        public ObservableCollection<Absence> ObtineToateAbsenteleDupaSubjectDupaTeacher(int TeacherId)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                ObservableCollection<Absence> rezultat = new ObservableCollection<Absence>();
                SqlCommand cmd = new SqlCommand("ObtineToateAbsenteleDupaSubjectDupaTeacher", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter parametruTeacherId = new SqlParameter("@Teacher_id", TeacherId);
                cmd.Parameters.Add(parametruTeacherId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rezultat.Add(new Absence()
                    {
                        IdAbsence = reader.GetInt32(0),
                        IdSubject = reader.GetInt32(1),
                        IdStudent = reader.GetInt32(2),
                        DataAbsence = reader.GetDateTime(3),
                        EsteMotivata = reader.GetBoolean(4)
                    });
                }
                return rezultat;
            }
        }
    }
}
