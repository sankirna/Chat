using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;

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
        public static String SendSMS(string mobile, String Message)
        {
            String userid = ConfigurationManager.AppSettings["SMSuid"];
            String pwd = ConfigurationManager.AppSettings["SMSpwd"];
            String GCM = ConfigurationManager.AppSettings["GSM"];
            var data1 = string.Format("Userid={0}&UserPassword={1}&PhoneNumber={2}&Text={3}&GSM={4}", userid, pwd, mobile, Message, GCM);
            string url = "http://ip.shreesms.net/smsserver/SMS10N.aspx" ;

            var client = new WebClient();
            string html = client.DownloadString(url+"?" + data1);
            //Console.WriteLine(html);

           
            return html.ToString();
        }
        public static String SendGCM(string[] Regid,String message,String Ntype,string title,string senderid,string sendername,string logintype,string chattyep,string messagetype)
        {

           // string RegId = "APA91bEYM1DC5eVKJBiIf6gity7HTntxrxsBX4tQiEUEKkHRJ2KqdWBmF9usqODOCqWHXdfdZrPh3ba_s_NRwKvY1Bd-7dvb63luXxQFHU0TTRcrLSHEqS62Mx54O-hzOCb8XX0lCxNX";
          string ApplicationID = "AIzaSyD1P8vn0oUeFc8TDh68s0Cs35T4d0B2AFg";
          string SENDER_ID = "522613911593";
          

            WebRequest tRequest;
            tRequest = WebRequest.Create("https://android.googleapis.com/gcm/send"); tRequest.Method = "post";
            tRequest.ContentType = "application/json";
            tRequest.Headers.Add(string.Format("Authorization: key={0}", ApplicationID)); tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
            //Data post to the Server
            string postData;
          String  RegArr = string.Join("\",\"", Regid);
         
            if (Ntype == "C")// Send Single Notification For all messages of a
            	// regid if Device is not active by setting Collapse_Key value
            	// same for a particular regid each time
            {
                postData = "{ \"registration_ids\": [ \"" + RegArr + "\" ] ,\"data\": {\"message\": \"" + message + "\", \"collapse_key\":\"" + Ntype + "\",\"title\":\"" + title + "\",\"senderid\":\"" + senderid + "\",\"sender_name\":\"" + sendername + "\",\"logintype\":\"" + logintype + "\",\"chattype\":\"" + chattyep + "\",,\"msgtype\":\"" + messagetype + "\"}}";
            }
            else
            {
                postData = "{ \"registration_ids\": [ \"" + RegArr + "\" ] , \"data\": {\"message\": \"" + message + "\",\"collapse_key\":\"" + message + "\",\"title\":\"" + title + "\",\"senderid\":\"" + senderid + "\",\"sender_name\":\"" + sendername + "\",\"logintype\":\"" + logintype + "\",\"chattype\":\"" + chattyep + "\",,\"msgtype\":\"" + messagetype + "\"}}";
            }


            Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            tRequest.ContentLength = byteArray.Length;
            Stream dataStream = tRequest.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse tResponse = tRequest.GetResponse(); dataStream = tResponse.GetResponseStream();
            StreamReader tReader = new StreamReader(dataStream);
            String sResponseFromServer = tReader.ReadToEnd();  //Get response from GCM server  
           
            tReader.Close(); dataStream.Close();
            tResponse.Close();
           
            return "sux";
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