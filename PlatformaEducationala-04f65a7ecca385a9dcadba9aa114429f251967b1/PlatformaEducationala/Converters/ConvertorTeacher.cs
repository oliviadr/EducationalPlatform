using PlatformaEducationala.Models.EntityLayer;
using System;
using System.Windows.Data;

namespace PlatformaEducationala.Converters
{
    class ConvertorTeacher : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[1] != null && values[2] != null && values[3] != null  )
            {
                DateTime date;
                if (DateTime.TryParse(values[2].ToString(), out date))
                {
                    return new Teacher()
                    {
                        Nume = values[0].ToString(),
                        Prenume = values[1].ToString(),
                        DataNastere = date,
                        Email = values[3].ToString(),
                        EsteDiriginte = System.Convert.ToBoolean(values[4].ToString())
                    };
                }
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Teacher Teacher = value as Teacher;
            object[] rezultat = new object[5] { Teacher.Nume, Teacher.Prenume, Teacher.DataNastere,  Teacher.Email, Teacher.EsteDiriginte };
            return rezultat;
        }
    }
}
