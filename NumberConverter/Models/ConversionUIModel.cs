using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using KMA.APZRPMJ2018.NumberConverter.DBModels;
using KMA.APZRPMJ2018.NumberConverter.Properties;

namespace KMA.APZRPMJ2018.NumberConverter.Models
{
    public class ConversionUIModel : INotifyPropertyChanged
    {
        #region Fields
        private Conversion _conversion;
        #endregion

        #region Properties
        internal Conversion Conversion
        {
            get { return _conversion; }
            private set
            {
                _conversion = value;
                OnPropertyChanged();
            }
        }

        public string ArabicNumeralValue
        {
            get { return _conversion.ArabicNumeralValue; }
            set
            {
                _conversion.ArabicNumeralValue = value;
                OnPropertyChanged();
            }
        }
        public string RomanNumeralValue
        {
            get { return _conversion.RomanNumeralValue; }
            set
            {
                _conversion.RomanNumeralValue = value;
                OnPropertyChanged();
            }
        }
        public DateTime ConversionDate
        {
            get { return _conversion.ConversionDate; }
        }
        public int Number
        {
            get { return _conversion.Number; }
            set
            {
                _conversion.Number = value;
                OnPropertyChanged();
            }
        }

        public Guid Guid
        {
            get { return _conversion.Guid; }
        }

        #endregion

        public ConversionUIModel(Conversion conversion)
        {
            _conversion = conversion;
        }

        public void UpdateConversion(string value)
        {
            _conversion.UpdateConversion(value);
        }

        #region EventsAndHandlers
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        internal virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #endregion
    }
}
