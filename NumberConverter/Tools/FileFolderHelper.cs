using System;
using System.IO;

namespace KMA.APZRPMJ2018.NumberConverter.Tools
{
    internal static class FileFolderHelper
    {
        private static readonly string AppDataPath =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        internal static readonly string ClientFolderPath =
            Path.Combine(AppDataPath, "NumberConverter");

        internal static readonly string LogFolderPath =
            Path.Combine(ClientFolderPath, "Log");

        internal static readonly string LogFilepath = Path.Combine(LogFolderPath,
            "App_" + DateTime.Now.ToString("YYYY_MM_DD") + ".txt");

        internal static readonly string StorageFilePath =
            Path.Combine(ClientFolderPath, "Storage.numcon");

        internal static readonly string LastUserFilePath =
            Path.Combine(ClientFolderPath, "LastUser.numcon");

        internal static void CheckAndCreateFile(string filePath)
        {
            try
            {
                FileInfo file = new FileInfo(filePath);
                if (!file.Directory.Exists)
                {
                    file.Directory.Create();
                }
                if (!file.Exists)
                {
                    file.Create().Close();
                }
                //Console.WriteLine(filePath);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}