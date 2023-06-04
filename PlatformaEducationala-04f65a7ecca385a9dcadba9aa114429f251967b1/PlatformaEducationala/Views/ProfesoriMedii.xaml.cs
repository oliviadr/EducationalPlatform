using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PlatformaEducationala.Views
{
    /// <summary>
    /// Interaction logic for TeacheriMedii.xaml
    /// </summary>
    public partial class ProfesoriMedii : Window
    {
        private int TeacherId;
        AverageVM AverageVM;

        public ProfesoriMedii()
        {
            InitializeComponent();
        }

        public ProfesoriMedii(int TeacherId)
        {
            InitializeComponent();
            this.TeacherId = TeacherId;
            AverageVM = DataContext as AverageVM;
            mediiDG.ItemsSource = AverageVM.ListaAverage;
            Teacher Teacher = AverageVM.TeacherBLL.ObtineTeacherDupaId(TeacherId);
            AverageVM.SubjectBLL.ObtineToateMateriileDupaTeacher(Teacher);
            txtIdSubject.ItemsSource = AverageVM.GetListaIdMateriiTeacher(Teacher);
        }

        private void CalculareMedieButton(object sender, RoutedEventArgs e)
        {
            if (txtIdStudent.SelectedItem != null)
            {
                if (txtIdSubject.SelectedItem != null)
                {
                    string[] parts2 = txtIdSubject.SelectedItem.ToString().Split(new char[] { '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    string[] parts = txtIdStudent.SelectedItem.ToString().Split(new char[] { '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts2.Length > 1)
                    {
                        string lastPart2 = parts2[1].Trim();
                        if (int.TryParse(lastPart2, out int idSubject))
                        {
                            if (parts.Length > 1)
                            {
                                string lastPart = parts[1].Trim();
                                if (int.TryParse(lastPart, out int idStudent))
                                {
                                    int sumaNote = 0;
                                    int numarNote = 0;
                                    int teza = 0;
                                    foreach (Grade Grade in AverageVM.GradeBLL.ObtineToateNotele())
                                    {
                                        if (Grade.IdStudent == idStudent && !Grade.EsteTeza && Grade.IdSubject == idSubject)
                                        {
                                            sumaNote += Grade.Valoare;
                                            numarNote++;
                                        }
                                        if (Grade.IdStudent == idStudent && Grade.EsteTeza && Grade.IdSubject == idSubject)
                                        {
                                            teza = Grade.Valoare;
                                        }
                                    }
                                    if (numarNote > 2 && teza != 0)
                                    {
                                        double AverageNote = (double)sumaNote / numarNote;
                                        double AverageStudent = (double)((AverageNote * 3.0) + teza) / 4.0;
                                        int idUltimaAverage = (int)AverageVM.ListaAverage[AverageVM.ListaAverage.Count - 1].IdAverage;
                                        Average Average = new Average
                                        {
                                            Grade = (decimal)AverageStudent,
                                            IdStudent = idStudent,
                                            IdAverage = idUltimaAverage + 1,
                                            IdSubject = idSubject
                                        };
                                        AverageVM.AverageBLL.InserareAverage(Average);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Studentul nu are cel putin 3 note sau nu are Grade la teza.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Te rog selecteaza o Subject pentru a ii calcula media.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Te rog selecteaza un Student pentru a ii calcula media.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void InsertButtonClick(object sender, RoutedEventArgs e)
        {
            mediiDG.ItemsSource = AverageVM.ListaAverage;
        }

        private void InsertButtonPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.Command != null && button.Command.CanExecute(button.CommandParameter))
                {
                    button.Command.Execute(button.CommandParameter);
                }
            }
            InsertButtonClick(sender, e);
        }
    }
}
