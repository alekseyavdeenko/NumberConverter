using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using KMA.APZRPMJ2018.NumberConverter.DBModels;
using KMA.APZRPMJ2018.NumberConverter.Managers;
using KMA.APZRPMJ2018.NumberConverter.Models;
using KMA.APZRPMJ2018.NumberConverter.Properties;
using KMA.APZRPMJ2018.NumberConverter.Tools;

namespace KMA.APZRPMJ2018.NumberConverter.ViewModels
{
    internal class ConversionConfigurationViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string _userInput;
        private Conversion _currentConversion;
        #region Command
        private ICommand _convertCommand;
        #endregion
        #endregion

        #region Properties
        #region Command
        public ICommand ConvertCommand
        {
            get
            {
                return _convertCommand ?? (_convertCommand = new RelayCommand<object>(ConvertExecute));
            }
        }
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
        public ConversionConfigurationViewModel(Conversion conversion)
        {
            _currentConversion = conversion;
        }
        #endregion

        private void ConvertExecute(object obj)
        {
            try
            {
                if (!(Regex.IsMatch(_userInput, @"^\d+$")))
                {
                    MessageBox.Show(String.Format(Resources.Convert_ValueIsNotValid, ArabicValue));
                    return;
                }
                else
                {
                    // What happens when Convert button is clicked and input value is valid.
                    _currentConversion.UpdateConversion(_userInput);
                    RomanValue = _currentConversion.RomanNumeralValue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(Resources.Convert_UnableToConvert, Environment.NewLine,
                    ex.Message));
                return;
            }
        }

        #region EventsAndHandlers
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        internal virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            DBManager.UpdateUser(StationManager.CurrentUser);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #endregion
    }
}