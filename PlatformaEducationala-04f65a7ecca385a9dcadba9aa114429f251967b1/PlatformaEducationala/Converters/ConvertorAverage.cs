using PlatformaEducationala.Models.EntityLayer;
using System;
using System.Windows.Data;

namespace PlatformaEducationala.Converters
{
    class ConvertorAverage : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string Student = values[0].ToString();
            string Subject = values[1].ToString();
            int StudentId = -1;
            int SubjectId = -1;
            decimal Grade;
            string[] parts = Student.Split(new char[] { '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length > 1)
            {
                string lastPart = parts[1].Trim();
                if (!int.TryParse(lastPart, out StudentId))
                {
                    return null;
                }
            }
            parts = Subject.Split(new char[] { '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length > 1)
            {
                string lastPart = parts[1].Trim();
                if (!int.TryParse(lastPart, out SubjectId))
                {
                    return null;
                }
            }
            if (!decimal.TryParse(values[2].ToString(), out Grade))
            {
                return null;
            }
            return new Average()
            {
                IdStudent = StudentId,
                IdSubject = SubjectId,
                Grade = Grade
            };
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Average Average = value as Average;
            object[] rezultat = new object[3] { Average.IdStudent, Average.IdSubject, Average.Grade };
            return rezultat;
        }
    }
}
