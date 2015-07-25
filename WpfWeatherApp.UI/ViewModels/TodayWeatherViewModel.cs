using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfWeatherApp.UI.ViewModels
{
    public class TodayWeatherViewModel : INotifyPropertyChanged
    {
        private string _dateLabel;
        private string _date;
        private string _telop;
        private string _temperatureMax;
        private string _temperatureMin;

        public string DateLabel
        {
            get
            {
                return _dateLabel;
            }
            set
            {
                if (_dateLabel != value)
                {
                    _dateLabel = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("DateLabel"));
                }
            }
        }
        public string Date
        {
            get
            {
                return _date;
            }
            set
            {
                if (_date != value)
                {
                    _date = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Date"));
                }
            }
        }
        public string Telop
        {
            get
            {
                return _telop;
            }
            set
            {
                if (_telop != value)
                {
                    _telop = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Telop"));
                }
            }
        }
        public string TemperatureMax
        {
            get
            {
                return _temperatureMax;
            }
            set
            {
                if (_temperatureMax != value)
                {
                    _temperatureMax = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("TemperatureMax"));
                }
            }
        }
        public string TemperatureMin
        {
            get
            {
                return _temperatureMin;
            }
            set
            {
                if (_temperatureMin != value)
                {
                    _temperatureMin = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("TemperatureMin"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
