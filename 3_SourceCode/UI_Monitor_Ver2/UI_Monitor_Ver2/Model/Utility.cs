using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using ITD.Monitor.Common.NLogHelper;

namespace UI_Monitor_Ver2.Model
{
    public class Utility
    {
        #region Xml

        public static string SerializeXml<T>(T obj)
        {
            string xmlString = null;
            DataContractSerializer serializer = new DataContractSerializer(obj.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, obj);
                xmlString = Encoding.UTF8.GetString(ms.ToArray());
                return xmlString;
            }
        }

        public static T DeserialiseXmlLocal<T>(string xmlString)
        {
            if (xmlString.Length > 0)
            {
                xmlString = xmlString.Replace("NULL", "");
            }
            T obj = Activator.CreateInstance<T>();
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(xmlString)))
            {
                DataContractSerializer serializer = new DataContractSerializer(obj.GetType());
                obj = (T)serializer.ReadObject(ms);
                return obj;
            }
        }

        #endregion Xml

        public static string[] ReadFile(string pathToRead)
        {
            try
            {
                using (StreamReader sr = new StreamReader(pathToRead))
                {
                    string line = sr.ReadToEnd();
                    char[] key = { ',', ';' };
                    string[] words = line.Split(key);
                    return words;
                }
            }
            catch (Exception ex)
            {
                NLogHelper.Error(ex);
                return null;
            }
        }
    }
}