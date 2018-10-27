using System;
using System.Windows;
using KMA.APZRPMJ2018.NumberConverter.Models;
using KMA.APZRPMJ2018.NumberConverter.ViewModels;

namespace KMA.APZRPMJ2018.NumberConverter.Managers
{
    public static class StationManager
    {
        public static User CurrentUser { get; set; }

        public static int LastNumber { get; set; }

        public static void Initialize()
        {

        }

        internal static void CloseApp()
        {
            MessageBox.Show("Shut Down");
            Environment.Exit(1);
        }
    }
}
