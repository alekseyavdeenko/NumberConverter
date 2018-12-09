
using KMA.APZRPMJ2018.NumberConverter.ViewModels.Authentication;

namespace KMA.APZRPMJ2018.NumberConverter.Views.Authentication
{
    /// <summary>
    /// Interaction logic for SignInView.xaml
    /// </summary>
    internal partial class SignInView
    {
        #region Constructor
        internal SignInView()
        {
            InitializeComponent();
            var signInViewModel = new SignInViewModel();
            DataContext = signInViewModel;
        }
        #endregion
    }
}
