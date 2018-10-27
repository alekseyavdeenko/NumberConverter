using KMA.APZRPMJ2018.NumberConverter.ViewModels;
using KMA.APZRPMJ2018.NumberConverter.ViewModels.Authentication;

namespace KMA.APZRPMJ2018.NumberConverter.Views.Authentication
{
    internal partial class SignUpView
    {
        #region Constructor
        internal SignUpView()
        {
            InitializeComponent();
            var signUpViewModel = new SignUpViewModel();
            DataContext = signUpViewModel;
        }
        #endregion
    }
}
