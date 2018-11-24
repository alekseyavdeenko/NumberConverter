using System.Windows;
using System.Windows.Controls;
using KMA.APZRPMJ2018.NumberConverter.Models;
using KMA.APZRPMJ2018.NumberConverter.ViewModels;
using KMA.APZRPMJ2018.NumberConverter.Views.Conversion;

namespace KMA.APZRPMJ2018.NumberConverter.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView
    {
        private MainViewViewModel _mainWindowViewModel;
        private ConversionConfigurationView _currentConversionConfigurationView;
        
        public MainView()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Visibility = Visibility.Visible;
            _mainWindowViewModel = new MainViewViewModel();
            _mainWindowViewModel.ConversionChanged += OnConversionChanged;
            DataContext = _mainWindowViewModel;
        }

        private void OnConversionChanged(ConversionUIModel conversion)
        {
            if (_currentConversionConfigurationView == null)
            {
                _currentConversionConfigurationView = new ConversionConfigurationView(conversion);
                MainGrid.Children.Add(_currentConversionConfigurationView);
                Grid.SetColumn(_currentConversionConfigurationView, 1);
                Grid.SetRowSpan(_currentConversionConfigurationView, 3);
                Grid.SetRow(_currentConversionConfigurationView, 0);
            }
            else
            {
                _currentConversionConfigurationView.DataContext = new ConversionConfigurationViewModel(conversion);
            }
        }
    }
}
