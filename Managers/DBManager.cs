using KMA.APZRPMJ2018.NumberConverter.DBModels;
using KMA.APZRPMJ2018.NumberConverter.ServiceInterface;

namespace KMA.APZRPMJ2018.NumberConverter.Managers
{
    public class DBManager
    {
        public static bool UserExists(string login)
        {
            return ConversionServiceWrapper.UserExists(login);
        }
        public static User GetUserByLogin(string login)
        {
            return ConversionServiceWrapper.GetUserByLogin(login);

        }
        public static void AddUser(User user)
        {
            ConversionServiceWrapper.AddUser(user);
        }
        internal static User CheckCachedUser(User userCandidate)
        {
            var userInStorage = ConversionServiceWrapper.GetUserByGuid(userCandidate.Guid);
            if (userInStorage != null && userInStorage.CheckPassword(userCandidate))
                return userInStorage;
            return null;
        }
       
        public static void DeleteConversion(Conversion selectedConversion)
        {
            ConversionServiceWrapper.DeleteConversion(selectedConversion);
        }
        public static void AddConversion(Conversion conversion)
        {
            ConversionServiceWrapper.AddConversion(conversion);
        }


    }
}
