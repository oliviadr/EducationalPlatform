using PlatformaEducationala.Models.EntityLayer;
using System;
using System.Windows.Data;

namespace PlatformaEducationala.Converters
{
    class ConvertorMaterial : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string Subject = (string)values[0];
            int SubjectId = -1;
            string[] parts = Subject.Split(new char[] { '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length > 1)
            {
                string lastPart = parts[1].Trim();
                if (!int.TryParse(lastPart, out SubjectId))
                {
                    return null;
                }
            }
            return new Material()
            {
                IdSubject = SubjectId,
                Fisier = (byte[])values[1]
            };
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Material material = value as Material;
            object[] rezultat = new object[2] { material.IdSubject, material.Fisier };
            return rezultat;
        }
    }
}
