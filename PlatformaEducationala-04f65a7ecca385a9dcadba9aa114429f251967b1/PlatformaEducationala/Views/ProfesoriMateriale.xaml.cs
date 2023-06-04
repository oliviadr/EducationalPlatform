using Microsoft.Win32;
using PlatformaEducationala.Models.EntityLayer;
using PlatformaEducationala.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PlatformaEducationala.Views
{
    /// <summary>
    /// Interaction logic for TeacheriMateriale.xaml
    /// </summary>
    public partial class ProfesoriMateriale : Window
    {
        private int TeacherId;
        MaterialVM materialVM;
        private ObservableCollection<Material> materiale = new ObservableCollection<Material>();

        public ProfesoriMateriale()
        {
            InitializeComponent();
        }

        public ProfesoriMateriale(int TeacherId)
        {
            InitializeComponent();
            this.TeacherId = TeacherId;
            materialVM = DataContext as MaterialVM;
            materiale = materialVM.GetListaMaterialeTeacheri(TeacherId);
            gridMateriale.ItemsSource = materiale;
            Teacher Teacher = materialVM.TeacherBLL.ObtineTeacherDupaId(TeacherId);
            materialVM.SubjectBLL.ObtineToateMateriileDupaTeacher(Teacher);
            ObservableCollection<Tuple<string, int>> materii = new ObservableCollection<Tuple<string, int>>();
            foreach (Subject Subject in materialVM.SubjectBLL.ListaMaterii)
            {
                Tuple<string, int> pair = new Tuple<string, int>(Subject.Nume, (int)Subject.IdSubject);
                if (!materii.Contains(pair))
                {
                    materii.Add(pair);
                }
            }
            txtIdSubject.ItemsSource = materii;
        }

        private void IncarcaFisier_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            ofd.Filter = "txt files (*.txt)|*txt|All files (*.*)|*.*";
            ofd.DefaultExt = ".txt";
            if (ofd.ShowDialog() == true)
            {
                string filePath = ofd.FileName;
                byte[] fileContent = File.ReadAllBytes(filePath);
                txtFisier.Text = System.IO.Path.GetFileName(filePath);
            }
        }

        private void InsertButtonClick(object sender, RoutedEventArgs e)
        {
            materiale = materialVM.GetListaMaterialeTeacheri(TeacherId);
            gridMateriale.ItemsSource = materiale;
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
