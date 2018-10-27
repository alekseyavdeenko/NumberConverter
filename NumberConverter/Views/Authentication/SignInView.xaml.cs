using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using KMA.APZRPMJ2018.NumberConverter.ViewModels;
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
