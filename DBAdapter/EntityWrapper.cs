using KMA.APZRPMJ2018.NumberConverter.DBModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
namespace KMA.APZRPMJ2018.NumberConverter.DBAdapter
{
    public static class EntityWrapper
    {
        public static bool UserExists(string login)
        {
            using (var context = new ConversionDBContext())
            {
                return context.Users.Any(u => u.Login == login);
            }
        }
        public static User GetUserByLogin(string login)
        {
            using (var context = new ConversionDBContext())
            {
                return context.Users.Include(u => u.Conversions).FirstOrDefault(u => u.Login == login);
            }
        }
        public static User GetUserByGuid(Guid guid)
        {
            using (var context = new ConversionDBContext())
            {
                return context.Users.Include(u => u.Conversions).FirstOrDefault(u => u.Guid == guid);
            }
        }
        public static List<User> GetAllUsers(Guid conversionGuid)
        {
            using (var context = new ConversionDBContext())
            {
                return context.Users.Where(u => u.Conversions.All(r => r.Guid != conversionGuid)).ToList();
            }
        }
        public static void AddUser(User user)
        {
            using (var context = new ConversionDBContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
        public static void AddConversion(Conversion conversion)
        {
            using (var context = new ConversionDBContext())
            {
                conversion.DeleteDatabaseValues();
                context.Conversions.Add(conversion);
                context.SaveChanges();
            }
        }
        public static void SaveConversion(Conversion conversion)
        {
            using (var context = new ConversionDBContext())
            {
                context.Entry(conversion).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void DeleteConversion(Conversion selectedConversion)
        {
            using (var context = new ConversionDBContext())
            {
                selectedConversion.DeleteDatabaseValues();
                context.Conversions.Attach(selectedConversion);
                context.Conversions.Remove(selectedConversion);
                context.SaveChanges();
            }
        }
    }
}