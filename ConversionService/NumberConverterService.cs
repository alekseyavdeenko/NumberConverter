using System;
using System.Collections.Generic;
using KMA.APZRPMJ2018.NumberConverter.DBAdapter;
using KMA.APZRPMJ2018.NumberConverter.DBModels;
using KMA.APZRPMJ2018.NumberConverter.ServiceInterface;
namespace KMA.APZRPMJ2018.NumberConverter.ConversionService
{
    class NumberConverterService : IConversionContract
    {
        public bool UserExists(string login)
        {
            return EntityWrapper.UserExists(login);
        }
        public User GetUserByLogin(string login)
        {
            return EntityWrapper.GetUserByLogin(login);
        }
        public User GetUserByGuid(Guid guid)
        {
            return EntityWrapper.GetUserByGuid(guid);
        }
        public void AddUser(User user)
        {
            EntityWrapper.AddUser(user);
        }
        public void AddConversion(Conversion conversion)
        {
            EntityWrapper.AddConversion(conversion);
        }

        public List<User> GetAllUsers(Guid conversionGuid)
        {
            return EntityWrapper.GetAllUsers(conversionGuid);
        }

        public void DeleteConversion(Conversion selectedConversion)
        {
            EntityWrapper.DeleteConversion(selectedConversion);
        }
        public void SaveConversion(Conversion conversion)
        {
            EntityWrapper.SaveConversion(conversion);
        }
    }
}