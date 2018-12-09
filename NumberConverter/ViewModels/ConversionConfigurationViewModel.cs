using System.ComponentModel;
using System.Runtime.CompilerServices;
using KMA.APZRPMJ2018.NumberConverter.Models;
using KMA.APZRPMJ2018.NumberConverter.Properties;

namespace KMA.APZRPMJ2018.NumberConverter.ViewModels
{
    internal class ConversionConfigurationViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string _userInput;
        private readonly ConversionUIModel _currentConversion;
        #endregion

        #region Properties
        #region Command
        //public ICommand ConvertCommand
        //{
        //    get
        //    {
        //        return _convertCommand ?? (_convertCommand = new RelayCommand<object>(ConvertExecute));
        //    }
        //}
        #endregion
        public string UserInput
        {
            get
            {
                if (!_currentConversion.RomanNumeralValue.Equals(""))
                {
                    return ArabicValue;
                }
                else
                {
                    return _userInput;
                }
            }
            set
            {
                _userInput = value;
                OnPropertyChanged("UserInput");
            }
        }
        public string ArabicValue
        {
            get
            {
                return _currentConversion.ArabicNumeralValue;
            }
            set
            {
                _currentConversion.ArabicNumeralValue = value;
                OnPropertyChanged("ArabicValue");
            }
        }
        public string RomanValue
        {
            get
            {
                return _currentConversion.RomanNumeralValue;
            }
            set
            {
                _currentConversion.RomanNumeralValue = value;
                OnPropertyChanged("RomanValue");
            }
        }
        public int Number
        {
            get
            {
                return _currentConversion.Number;
            }
            set
            {
                _currentConversion.Number = value;
                OnPropertyChanged("Number");
            }
        }
        #endregion

        #region Constructor
        public ConversionConfigurationViewModel(ConversionUIModel conversion)
        {
            _currentConversion = conversion;
        }
        #endregion

        //public async void ConvertExecute(object obj)
        //{
        //    var result = await Task.Run(() =>
        //    {
        //        try
        //        {
        //            if (!(Regex.IsMatch(_userInput, @"^\d+$")))
        //            {
        //                MessageBox.Show(String.Format(Resources.Convert_ValueIsNotValid, ArabicValue));
        //                return _currentConversion;
        //            }
        //            else
        //            {
        //                _currentConversion.UpdateConversion(_userInput);
        //                return _currentConversion;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(String.Format(Resources.Convert_UnableToConvert, Environment.NewLine,
        //            ex.Message));
        //            return _currentConversion;
        //        }
        //    });

        //    if (!result.RomanNumeralValue.Equals(""))
        //    {
        //        RomanValue = _currentConversion.RomanNumeralValue;
        //        EntityWrapper.SaveConversion(_currentConversion.Conversion);
        //    }
        //    else
        //    {
        //        RomanValue = "UNDEFINED";
        //    }
        //}
        
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
