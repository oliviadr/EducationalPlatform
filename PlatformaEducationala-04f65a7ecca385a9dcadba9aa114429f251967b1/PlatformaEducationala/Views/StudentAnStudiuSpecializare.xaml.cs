using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Windows;
using System.Windows.Controls;

namespace PlatformaEducationala.Views
{
    /// <summary>
    /// Interaction logic for ElevAnStudiuSpecializare.xaml
    /// </summary>
    public partial class StudentAnStudiuSpecializare : Window
    {
        public StudentAnStudiuSpecializare()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StudentAnStudiuSpecializareVM elevAnStudiuSpecializareVM = this.DataContext as StudentAnStudiuSpecializareVM;
            Tuple<string, int> pair = txtElev.SelectedItem as Tuple<string, int>;
            if (pair is Tuple<string, int> keyValue)
            {
                int id = keyValue.Item2;
                Student elevSelectat = elevAnStudiuSpecializareVM.StudentBLL.ObtineStudentDupaId(id);
                elevAnStudiuSpecializareVM.ObtineAnStudiuDupaClass((int)elevSelectat.IdClass);
                txtAnStudiu.Text = elevAnStudiuSpecializareVM.anStudiu.ToString();
                txtSpecializare.ItemsSource = elevAnStudiuSpecializareVM.ObtineToateDenumirileSpecializarilor(elevAnStudiuSpecializareVM.SpecializationBLL.ObtineToateSpecializarile());
                string itemSelectat = "";
                foreach (Class clasa in elevAnStudiuSpecializareVM.ClassBLL.ObtineToateClasele())
                {
                    if (clasa.IdClass == elevSelectat.IdClass)
                    {
                        foreach (Specialization specializare in elevAnStudiuSpecializareVM.SpecializationBLL.ObtineToateSpecializarile())
                        {
                            if (specializare.IdSpecialization == clasa.IdSpecialization)
                            {
                                itemSelectat = specializare.Denumire;
                                break;
                            }
                        }
                    }
                }
                txtSpecializare.SelectedItem = itemSelectat;
            }
        }

        private void Actualizare_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConStr"].ConnectionString);
            using (con)
            {
                SqlCommand command = new SqlCommand("ActualizareSpecializationSiAnStudiuDupaStudent", con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                Tuple<string, int> pair = txtElev.SelectedItem as Tuple<string, int>;
                if (pair is Tuple<string, int> kv)
                {
                    command.Parameters.AddWithValue("@student_id", kv.Item2);
                    int anStudiu;
                    if (int.TryParse(txtAnStudiu.Text, out anStudiu))
                    {
                        command.Parameters.AddWithValue("@studiu_an", anStudiu);
                        command.Parameters.AddWithValue("@denumire_Specialization", txtSpecializare.SelectedItem.ToString());
                        con.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
