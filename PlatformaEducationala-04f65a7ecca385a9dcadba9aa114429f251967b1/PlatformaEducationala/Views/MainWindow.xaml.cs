using System.Collections.Generic;
using System.Windows;

namespace PlatformaEducationala.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void AdministratorMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Open the administrator window
            Administrator adminWindow = new Administrator();
            adminWindow.Show();
        }
        private void TeacherMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Open the administrator window
            TeacherWindow teacherWindow = new TeacherWindow();
            teacherWindow.Show();
        }

        private void StudentMenuItem_Click(object sender, RoutedEventArgs e)
        {
            StudentWindow studentWindow = new StudentWindow();
            studentWindow.Show();
        }
    }
}
