using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Занятие6
{
    enum Fallout
    {
        sunny, 
        cloudy, 
        raining, 
        snowing
    }


     class WeatherControl : DependencyObject
    {

        public string winddirection;
        public int windspeed;
        public Fallout fallout;

        public WeatherControl(string winddirection, int windspeed, Fallout fallout)
        {
            this.winddirection = winddirection;
            this.windspeed = windspeed;
            this.fallout = fallout;
        }

        public static readonly DependencyProperty TempProperty;
        public int Temp
        {
            get => (int)GetValue(TempProperty);
            set => SetValue(TempProperty, value);
        }

        static WeatherControl()
        {
            ValidateValueCallback ValidateTemp = null;
            CoerceValueCallback CoerceTemp = null;
            TempProperty = DependencyProperty.Register(
                nameof(Temp),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemp)),
                new ValidateValueCallback(ValidateTemp));
        }

        private static bool ValidateTemp(object value)
        {
            int v = (int)value;
            if (v >= -50 && v <= 50)
                return true;
            else
                return false;
        }

        private static object CoerceTemp(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v >= 0)
                return v;
            else
                return 0;
        }
    }

}
