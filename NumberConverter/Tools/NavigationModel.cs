using System;
using KMA.APZRPMJ2018.NumberConverter.Views;
using KMA.APZRPMJ2018.NumberConverter.Views.Authentication;

namespace KMA.APZRPMJ2018.NumberConverter.Tools
{
    internal enum ModesEnum
    {
        SignIn,
        SignUp,
        Main
    }

    internal class NavigationModel
    {
        private readonly IContentWindow _contentWindow;
        private SignInView _signInView;
        private SignUpView _signUpView;
        private MainView _mainView;

        internal NavigationModel(IContentWindow contentWindow)
        {
            _contentWindow = contentWindow;
        }

        internal void Navigate(ModesEnum mode)
        {
            switch (mode)
            {
                case ModesEnum.SignIn:
                    _signInView = new SignInView();
                    _contentWindow.ContentControl.Content = _signInView;
                    break;
                case ModesEnum.SignUp:
                    _signUpView = new SignUpView();
                    _contentWindow.ContentControl.Content = _signUpView;
                    break;
                case ModesEnum.Main:
                    _mainView = new MainView();
                    _contentWindow.ContentControl.Content = _mainView;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }
    }
}
