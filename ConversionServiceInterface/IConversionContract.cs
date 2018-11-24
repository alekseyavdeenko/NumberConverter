using System;
using System.Collections.Generic;
using System.ServiceModel;
using KMA.APZRPMJ2018.NumberConverter.DBModels;
namespace KMA.APZRPMJ2018.NumberConverter.ServiceInterface
{
    [ServiceContract]
    public interface IConversionContract
    {
        [OperationContract]
        bool UserExists(string login);
        [OperationContract]
        User GetUserByLogin(string login);
        [OperationContract]
        User GetUserByGuid(Guid guid);
        [OperationContract]
        List<User> GetAllUsers(Guid conversionGuid);
        [OperationContract]
        void AddUser(User user);
        [OperationContract]
        void AddConversion(Conversion conversion);
        [OperationContract]
        void SaveConversion(Conversion conversion);
        [OperationContract]
        void DeleteConversion(Conversion selectedConversion);
    }
}