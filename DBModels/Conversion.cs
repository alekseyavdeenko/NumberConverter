using System;
using System.Data.Entity.ModelConfiguration;
using KMA.APZRPMJ2018.NumberConverter.Tools;
using System.Runtime.Serialization;
using System.Windows.Markup;

namespace KMA.APZRPMJ2018.NumberConverter.DBModels
{
    [DataContract(IsReference = true)]
    public class Conversion
    {
        #region Fields
        [DataMember]
        private Guid _guid;
        [DataMember]
        private string _arabicNumeralValue;
        [DataMember]
        private string _romanNumeralValue;
        [DataMember]
        private DateTime _conversionDate;
        [DataMember]
        private int _number;
        [DataMember]
        private Guid _userGuid;
        [DataMember]
        private User _user;
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

        public User User
        {
            get { return _user; }
            private set { _user = value; }
        }
        public Guid UserGuid
        {
            get { return _userGuid; }
            private set { _userGuid = value; }
        }

        #endregion

        #region Constructor
        public Conversion(User user) : this()
        {
            _guid = Guid.NewGuid();
            _arabicNumeralValue = "";
            _romanNumeralValue = "";
            _conversionDate = DateTime.Today.Date;
            if (user.Conversions.Count != 0)
            {
                _number = user.Conversions[user.Conversions.Count - 1].Number + 1;
            }
            else
            {
                _number = 1;
            }
            _user = user;
            _userGuid = user.Guid;
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

        #region EntityFrameworkConfiguration
        public class ConversionEntityConfiguration : EntityTypeConfiguration<Conversion>
        {
            public ConversionEntityConfiguration()
            {
                ToTable("Conversion");
                HasKey(s => s.Guid);
                Property(p => p.Guid)
                   .HasColumnName("Guid")
                   .IsRequired();
                Property(s => s.Number)
                    .HasColumnName("Number")
                    .IsRequired();
                Property(p => p.ArabicNumeralValue)
                    .HasColumnName("ArabicNumeralValue")
                    .IsRequired();
                Property(s => s.RomanNumeralValue)
                    .HasColumnName("RomanNumeralValue")
                    .IsRequired();
                Property(s => s.ConversionDate)
                    .HasColumnName("ConversionDate")
                    .IsRequired();

            }
        }
        #endregion
        public void DeleteDatabaseValues()
        {
            _user = null;
        }
    }
}

