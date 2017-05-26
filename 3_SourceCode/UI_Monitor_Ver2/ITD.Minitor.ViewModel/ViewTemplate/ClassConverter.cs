using System;
using System.Windows.Data;

namespace ITD.Minitor.ViewModel.ViewTemplate
{
    public class ClassConverter
    {
        #region ClassConverter

        public class StatusConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                int sale = System.Convert.ToInt32(value);
                int target = System.Convert.ToInt32(parameter);

                if (sale > target)
                    return true;
                else
                    return false;
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        public class ChangeIndexConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (values == null || values.Length != 2)
                    return null;

                int? idx = values[0] as int?;
                object[] ThietBi = values[1] as object[];

                if (!idx.HasValue || ThietBi == null)
                    return null;

                //return ThietBi[idx.Value];

                return ThietBi[1];
            }

            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        #endregion ClassConverter
    }
}