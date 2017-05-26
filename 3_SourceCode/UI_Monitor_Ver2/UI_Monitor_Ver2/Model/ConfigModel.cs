using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using ITD.Monitor.Common.NLogHelper;
using UI_Monitor_Ver2.View;

namespace UI_Monitor_Ver2.Model
{
    public class ConfigModel
    {
        private static string configFile = "config.xml";

        #region Property

        #region Database

        [DataMember(EmitDefaultValue = false)]
        public string DataBaseServer { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string DatabaseName { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string DatabaseUser { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string DatabaseUserPassword { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int DatabaseTimeOut { get; set; }

        #endregion Database

        #endregion Property

        #region Method

        /// <summary>
        /// Load config infor from XML file
        /// </summary>
        /// <returns></returns>
        public static ConfigModel LoadConfig()
        {
            ConfigModel _mConfig = null;
            try
            {
                if (File.Exists(configFile))
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(configFile);
                    string xml = xmlDoc.InnerXml;
                    _mConfig = Utility.DeserialiseXmlLocal<ConfigModel>(xml);
                }
            }
            catch (Exception ex)
            {
                NLogHelper.Error(ex);
            }
            return _mConfig;
        }

        /// <summary>
        /// Save config infor to XML file
        /// </summary>
        /// <param name="pConfigModel"></param>
        /// <returns></returns>
        public static bool SaveConfig(ConfigModel pConfigModel)
        {
            try
            {
                // Save Xml file
                //encryptionConfig(pConfigModel);
                string xml = Utility.SerializeXml<ConfigModel>(pConfigModel);
                XmlDocument xmlDoc = new XmlDocument();
                //xmlDoc.CreateComment(xml);
                xmlDoc.LoadXml(xml);
                xmlDoc.Save(configFile);
                //_mGlobal.MyConfig = _mConfig;
                //MessageBox.Show("Lưu file thành công!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return true;
            }
            catch (Exception ex)
            {
                NLogHelper.Error(ex);
                // MessageBox.Show("Lưu file không thành công!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        #endregion Method
    }
}