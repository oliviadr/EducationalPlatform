using PlatformaEducationala.Models.EntityLayer;
using System;
using System.Windows.Data;

namespace PlatformaEducationala.Converters
{
    class ConvertorStudent : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[1] != null && values[2] != null && values[3] != null && values[4] != null  )
            {
                string Class = values[4].ToString();
                int idClass = -1;
                string[] parts = Class.Split(new char[] { '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length > 1)
                {
                    string lastPart = parts[2].Trim();
                    if (!int.TryParse(lastPart, out idClass))
                    {
                        return null;
                    }
                }
                DateTime date;
                if (DateTime.TryParse(values[2].ToString(), out date))
                {
                    return new Student()
                    {
                        Nume = values[0].ToString(),
                        Prenume = values[1].ToString(),
                        DataNastere = date,
                        Email = values[3].ToString(),
                        IdClass = idClass
                    };
                }
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Student Student = value as Student;
            object[] rezultat = new object[5] { Student.Nume, Student.Prenume, Student.DataNastere,  Student.Email, Student.IdClass };
            return rezultat;
        }
    }
}
