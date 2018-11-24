using System;
using System.Collections.Generic;
using System.ServiceModel;
using KMA.APZRPMJ2018.NumberConverter.DBModels;
namespace KMA.APZRPMJ2018.NumberConverter.ServiceInterface
{
    public class ConversionServiceWrapper
    {
        public static bool UserExists(string login)
        {
            using (var myChannelFactory = new ChannelFactory<IConversionContract>("Server"))
            {
                IConversionContract client = myChannelFactory.CreateChannel();
                return client.UserExists(login);
            }
        }
        public static User GetUserByLogin(string login)
        {
            using (var myChannelFactory = new ChannelFactory<IConversionContract>("Server"))
            {
                IConversionContract client = myChannelFactory.CreateChannel();
                return client.GetUserByLogin(login);
            }
        }
        public static User GetUserByGuid(Guid guid)
        {
            using (var myChannelFactory = new ChannelFactory<IConversionContract>("Server"))
            {
                IConversionContract client = myChannelFactory.CreateChannel();
                return client.GetUserByGuid(guid);
            }
        }
        public static void AddUser(User user)
        {
            using (var myChannelFactory = new ChannelFactory<IConversionContract>("Server"))
            {
                IConversionContract client = myChannelFactory.CreateChannel();
                client.AddUser(user);
            }
        }
        public static void AddConversion(Conversion conversion)
        {
            using (var myChannelFactory = new ChannelFactory<IConversionContract>("Server"))
            {
                IConversionContract client = myChannelFactory.CreateChannel();
                client.AddConversion(conversion);
            }
        }
        public static void SaveConversion(Conversion conversion)
        {
            using (var myChannelFactory = new ChannelFactory<IConversionContract>("Server"))
            {
                IConversionContract client = myChannelFactory.CreateChannel();
                client.SaveConversion(conversion);
            }
        }
        public static List<User> GetAllUsers(Guid conversionGuid)
        {
            using (var myChannelFactory = new ChannelFactory<IConversionContract>("Server"))
            {
                IConversionContract client = myChannelFactory.CreateChannel();
                return client.GetAllUsers(conversionGuid);
            }
        }
        public static void DeleteConversion(Conversion selectedConversion)
        {
            using (var myChannelFactory = new ChannelFactory<IConversionContract>("Server"))
            {
                IConversionContract client = myChannelFactory.CreateChannel();
                client.DeleteConversion(selectedConversion);
            }
        }
    }
}