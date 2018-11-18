
using KMA.APZRPMJ2018.NumberConverter.DBAdapter;
using KMA.APZRPMJ2018.NumberConverter.DBModels;
using KMA.APZRPMJ2018.NumberConverter.Tools;

namespace KMA.APZRPMJ2018.NumberConverter.Managers
{
    public class DBManager
    {
        public static bool UserExists(string login)
        {
            return EntityWrapper.UserExists(login);
        }
        public static User GetUserByLogin(string login)
        {
            return EntityWrapper.GetUserByLogin(login);
        }
        public static void AddUser(User user)
        {
            EntityWrapper.AddUser(user);
        }
        internal static User CheckCachedUser(User userCandidate)
        {
            var userInStorage = EntityWrapper.GetUserByGuid(userCandidate.Guid);
            if (userInStorage != null && userInStorage.CheckPassword(userCandidate))
                return userInStorage;
            return null;
        }
        private static void SaveChanges()
        {
            SerializationManager.Serialize(Users, FileFolderHelper.StorageFilePath);
        }
        public static void DeleteConversion(Conversion selectedConversion)
        {
            EntityWrapper.DeleteConversion(selectedConversion);
        }
        public static void AddConversion(Conversion conversion)
        {
            EntityWrapper.AddConversion(conversion);
        }

        public static void UpdateUser(User currentUser)
        {
            SaveChanges();
        }
    }
}
