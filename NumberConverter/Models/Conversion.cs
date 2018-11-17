using System;
using KMA.APZRPMJ2018.NumberConverter.Managers;
using KMA.APZRPMJ2018.NumberConverter.Tools;

namespace KMA.APZRPMJ2018.NumberConverter.Models
{
    [Serializable]
    public class Conversion
    {
        #region Fields
        private Guid _guid;
        private string _arabicNumeralValue;
        private string _romanNumeralValue;
        private DateTime _conversionDate;
        private int _number;
        #endregion

        #region Properties
        public Guid Guid
        {
            get { return _guid; }
            private set { _guid = value; }
        }
        public string ArabicNumeralValue
        {
            get { return _arabicNumeralValue; }
            set { _arabicNumeralValue = value; }
        }
        public string RomanNumeralValue
        {
            get { return _romanNumeralValue; }
            set { _romanNumeralValue = value; }
        }
        public DateTime ConversionDate
        {
            get { return _conversionDate; }
            private set { _conversionDate = value; }
        }
        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }
        #endregion

        #region Constructor
        public Conversion(User user) : this()
        {
            _guid = Guid.NewGuid();
            _arabicNumeralValue = "";
            _romanNumeralValue = "";
            _conversionDate = DateTime.Today.Date;
            _number = StationManager.CurrentUser.Conversions.Count+1;
            user.Conversions.Add(this);
        }
        private Conversion()
        {
        }
        #endregion

        // Add information about arabic and roman values (after Convert button is clicked).
        public void UpdateConversion(string value)
        {
            _arabicNumeralValue = value;
            _romanNumeralValue = Calculation.CalculateRoman(ArabicNumeralValue);
        }

        public override string ToString()
        {
            return ArabicNumeralValue + " -> " + RomanNumeralValue;
        }
    }
}
