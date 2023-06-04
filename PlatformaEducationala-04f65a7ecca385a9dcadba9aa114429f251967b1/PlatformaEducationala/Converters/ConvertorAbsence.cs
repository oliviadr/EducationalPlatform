using PlatformaEducationala.Models.EntityLayer;
using System;
using System.Windows;
using System.Windows.Data;

namespace PlatformaEducationala.Converters
{
    class ConvertorAbsence : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string Subject = values[0].ToString();
            string Student = values[1].ToString();
            int SubjectId = -1;
          
            int StudentId = -1;
            string[] parts = Subject.Split(new char[] { '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length > 1)
            {
                string lastPart = parts[1].Trim();
                if (!int.TryParse(lastPart, out SubjectId))
                {
                    return null;
                }
            }
            parts = Student.Split(new char[] { '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length > 1)
            {
                string lastPart = parts[1].Trim();
                if (!int.TryParse(lastPart, out StudentId))
                {
                    return null;
                }
            }
            DateTime date;
            if (DateTime.TryParse(values[2].ToString(), out date))
            {
                return new Absence()
                {
                    IdSubject = SubjectId,
                    IdStudent = StudentId,
                    DataAbsence = date,
                    EsteMotivata = System.Convert.ToBoolean(values[3].ToString())
                };
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Absence Absence = value as Absence;
            object[] rezultat = new object[4] { Absence.IdSubject, Absence.IdStudent, Absence.DataAbsence, Absence.EsteMotivata };
            return rezultat;
        }
    }
}
