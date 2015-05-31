using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Chat.Service.Helpers
{
    public static class CommonHelper
    {
        /// <summary>
        /// for Common Current date time 
        /// </summary>
        /// <returns></returns>
        public static DateTime GetCurrentDate()
        {
            return System.DateTime.Now; ;
        }

        /// <summary>
        /// Set Common Date Formate
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string GetFormateDate(this DateTime date)
        {
            return date.ToString("MM.dd.yyyy");
        }

        public static string GetFormateDateToMMddyyyy(this DateTime date)
        {
            return date.ToString("MM'/'dd'/'yyyy");
        }

        /// <summary>
        /// get Citra full date formate for Display
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string GetFullDateFormate(this DateTime date)
        {
            return date.ToString("MM.dd.yyyy HH:mm:ss");
        }

        /// <summary>
        /// Convert String To Int 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ToIntFromString(this string value)
        {
            try
            {
                return Convert.ToInt16(value);
            }
            catch (Exception)
            {
                throw; // TODO Set Here
            }
        }

        /// <summary>
        /// Convert Int To String
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToStringFromint(this int value)
        {
            try
            {
                return Convert.ToString(value);
            }
            catch (Exception)
            {
                throw; // TODO Set Here
            }
        }

        /// Trims the object passed
        /// </summary>
        /// <param name="model"></param>
        /// <param name="isWantToEncodeStrings"> </param>
        /// <returns></returns>
        public static T GetTrimmedObject<T>(T model) where T : class
        {
            try
            {
                var propertiesInfoCollection = model.GetType().GetProperties();
                foreach (PropertyInfo item in propertiesInfoCollection)
                {
                    Type type = item.PropertyType;
                    if (type == typeof(String))
                    {
                        dynamic value = item.GetValue(model, null);
                        if (!String.IsNullOrWhiteSpace(value))
                        {
                            item.SetValue(model, value.Trim());
                        }
                    }

                }
                return model;
            }
            catch (Exception)
            {
                return model;
            }
        }

        /// <summary>
        /// Display formate name for User
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public static string ToUseDisplayName(string firstName, string lastName)
        {
            if (!string.IsNullOrEmpty(lastName))
            {
                return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(string.Format("{0} {1}.", firstName, lastName.FirstOrDefault()));
            }
            else
            {
                return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(string.Format("{0}", firstName));
            }
        }

        /// <summary>
        /// Capitalize Letter after symbol
        /// </summary>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static string ToCapilizeDisplayName(this string displayName)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(displayName);
        }

        /// <summary>
        /// Get First charater from string 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static char? ToFirstCharater(this string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                return str.ToUpper().FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public static DateTime ToDateTime(this string str)
        {
            DateTime myDateTime = new DateTime();
            try
            {
                myDateTime = DateTime.ParseExact(str, "MM-dd-yyyy",
                                                 null);
            }
            catch (Exception)
            {
            }
            return myDateTime;
        }

        public static string GetRandomKey(int len)
        {
            int maxSize = len;
            char[] chars = new char[30];
            string a;
            a = "1234567890";
            chars = a.ToCharArray();
            int size = maxSize;
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            size = maxSize;
            data = new byte[size];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data) { result.Append(chars[b % (chars.Length)]); }
            return result.ToString();
        }
    }
}