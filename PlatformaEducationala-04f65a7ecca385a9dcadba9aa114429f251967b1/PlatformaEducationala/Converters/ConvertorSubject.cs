using PlatformaEducationala.Models.EntityLayer;
using System;
using System.Windows.Data;

namespace PlatformaEducationala.Converters
{
    class ConvertorSubject : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string Teacher = (string)values[1];
            int TeacherId = -1;
            int anStudiu;
            string[] parts = Teacher.Split(new char[] { '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length > 1)
            {
                string lastPart = parts[1].Trim();
                if (!int.TryParse(lastPart, out TeacherId))
                {
                    return null;
                }
            }
            if (!int.TryParse(values[3].ToString(), out anStudiu))
            {
                return null;
            }
            return new Subject()
            {
                Nume = values[0].ToString(),
                IdTeacher = TeacherId,
                AreTeza = System.Convert.ToBoolean(values[2].ToString()),
                AnStudiu = anStudiu
            };
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Subject Subject = value as Subject;
            object[] rezultat = new object[4] { Subject.Nume, Subject.IdTeacher, Subject.AreTeza, Subject.AnStudiu };
            return rezultat;
        }
    }
}
