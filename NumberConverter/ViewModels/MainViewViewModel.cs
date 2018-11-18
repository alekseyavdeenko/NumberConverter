using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using KMA.APZRPMJ2018.NumberConverter.DBModels;
using KMA.APZRPMJ2018.NumberConverter.Managers;
using KMA.APZRPMJ2018.NumberConverter.Models;
using KMA.APZRPMJ2018.NumberConverter.Properties;
using KMA.APZRPMJ2018.NumberConverter.Tools;

namespace KMA.APZRPMJ2018.NumberConverter.ViewModels
{
    public class MainViewViewModel : INotifyPropertyChanged
    {
        #region Fields
        private Conversion _selectedConversion;
        private ObservableCollection<Conversion> _conversions;
        #region Commands
        private ICommand _addConversionCommand;
        private ICommand _logOutCommand;
        #endregion
        #endregion

        #region Properties
        public ObservableCollection<Conversion> Conversions
        {
            get { return _conversions; }
        }
        public Conversion SelectedConversion
        {
            get { return _selectedConversion; }
            set
            {
                _selectedConversion = value;
                OnPropertyChanged("SelectedConversion");
            }
        }
        #region Commands
        public ICommand AddConversionCommand
        {
            get
            {
                return _addConversionCommand ?? (_addConversionCommand = new RelayCommand<object>(AddConversionExecute));
            }
        }

        public ICommand LogOutCommand
        {
            get
            {
                return _logOutCommand ?? (_logOutCommand = new RelayCommand<object>(LogOutExecute));
            }
        }
        #endregion
        #endregion

        #region Constructor
        public MainViewViewModel()
        {
            FillConversions();
            PropertyChanged += OnPropertyChanged;
        }
        #endregion

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == "SelectedConversion")
                OnConversionChanged(_selectedConversion);
        }

        private void FillConversions()
        {
            _conversions = new ObservableCollection<Conversion>();
            foreach (var conv in StationManager.CurrentUser.Conversions)
            {
                _conversions.Add(conv);
            }
            if (_conversions.Count > 0)
            {
                _selectedConversion = Conversions[0];
            }
        }

        public void AddConversionExecute(object o)
        {
            Conversion conversion = new Conversion(StationManager.CurrentUser);
            _conversions.Add(conversion);
            _selectedConversion = conversion;
        }

        public void LogOutExecute(object o)
        {
            StationManager.CurrentUser = null;
            NavigationManager.Instance.Navigate(ModesEnum.SignIn);
        }

        #region EventsAndHandlers
        #region Loader
        internal event ConversionChangedHandler ConversionChanged;
        internal delegate void ConversionChangedHandler(Conversion conversion);

        internal virtual void OnConversionChanged(Conversion conversion)
        {
            ConversionChanged?.Invoke(conversion);
        }
        #endregion
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #endregion
    }
}