using PlatformaEducationala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace PlatformaEducationala.Converters
{
    class ConvertorClass : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string Specialization = (string)values[0];
            string diriginte = (string)values[1];
            int SpecializationId = -1;
            int diriginteId = -1;
            int anStudiu;
            string[] parts = Specialization.Split(new char[] { '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length > 1)
            {
                string lastPart = parts[1].Trim();
                if (!int.TryParse(lastPart, out SpecializationId))
                {
                    return null;
                }
            }
            parts = diriginte.Split(new char[] { '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length > 1)
            {
                string lastPart = parts[1].Trim();
                if (!int.TryParse(lastPart, out diriginteId))
                {
                    return null;
                }
            }
            if (!int.TryParse(values[2].ToString(), out anStudiu))
            {
                return null;
            }
            return new Class()
            {
                IdSpecialization = SpecializationId,
                IdDiriginte = diriginteId,
                AnStudiu = anStudiu,
                Grupa = values[3].ToString()
            };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            Class Class = value as Class;
            object[] rezultat = new object[4] { Class.IdSpecialization, Class.IdDiriginte, Class.AnStudiu, Class.Grupa };
            return rezultat;
        }
    }
}
