using System;
using System.IO;
using System.Windows.Forms;
using KMA.APZRPMJ2018.NumberConverter.DBModels;
using KMA.APZRPMJ2018.NumberConverter.Tools;


namespace KMA.APZRPMJ2018.NumberConverter.Managers
{
    public static class StationManager
    {
        public static User CurrentUser { get; set; }

        static StationManager()
        {

            DeserializeLastUser();
        }

        private static void DeserializeLastUser()
        {
            User userCandidate;
            try
            {
                userCandidate = SerializationManager.Deserialize<User>(Path.Combine(FileFolderHelper.LastUserFilePath));
            }
            catch (Exception ex)
            {
                userCandidate = null;
                Logger.Log("Failed to Deserialize last user", ex);
            }
            if (userCandidate == null)
            {
                Logger.Log("User was not deserialized");
                return;
            }
            userCandidate = DBManager.CheckCachedUser(userCandidate);
            if (userCandidate == null)
                Logger.Log("Failed to relogin last user");
            else
                CurrentUser = userCandidate;
        }
        public static void DeleteLastSerializedUsed()
        {
            try
            {
                SerializationManager.Serialize<User>(null, Path.Combine(FileFolderHelper.LastUserFilePath));
            }
            catch (Exception ex)
            {
                Logger.Log("Failed to Delete last serialized user", ex);
            }
        }

        public static void CloseApp()
        {
            MessageBox.Show("Shut Down");
            Environment.Exit(1);
        }
    }
}