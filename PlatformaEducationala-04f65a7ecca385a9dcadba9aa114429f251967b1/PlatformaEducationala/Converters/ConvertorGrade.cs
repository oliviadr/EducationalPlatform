using PlatformaEducationala.Models.EntityLayer;
using System;
using System.Windows.Data;

namespace PlatformaEducationala.Converters
{
    class ConvertorGrade : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string Subject = (string)values[0];
            string Student = (string)values[5];
            int SubjectId = -1;
            int valoare;
            int semestru;
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
            if (!int.TryParse(values[1].ToString(), out valoare))
            { 
                return null; 
            }
            if (!int.TryParse(values[3].ToString(), out semestru))
            {
                return null;
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
            return new Grade()
            {
                IdSubject = SubjectId,
                Valoare = valoare,
                EsteTeza = System.Convert.ToBoolean(values[2].ToString()),
                Semestru = semestru,
                AverageIncheiata = System.Convert.ToBoolean(values[4].ToString()),
                IdStudent = StudentId
            };
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Grade Grade = value as Grade;
            object[] rezultat = new object[6] { Grade.IdSubject, Grade.Valoare, Grade.EsteTeza, Grade.Semestru, Grade.AverageIncheiata, Grade.IdStudent };
            return rezultat;
        }
    }
}
