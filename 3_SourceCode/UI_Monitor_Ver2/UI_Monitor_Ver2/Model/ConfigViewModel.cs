
using ITD.Monitor.Common.DBHelper;
using ITD.Monitor.Common.NLogHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace UI_Monitor_Ver2.Model
{
    public class ConfigViewModel : ViewModelBase
    {
        #region Fields
        private ConfigModel _mConfig;
        #endregion



        private string _databaseServerName = string.Empty;
        public string DatabaseServerName
        {
            get { return _databaseServerName; }
            set
            {
                if (_databaseServerName != value)
                {
                    _databaseServerName = value;
                    OnPropertyChanged("DatabaseServerName");
                }
            }
        }

        private string _databaseName = string.Empty;
        public string DatabaseName
        {
            get { return _databaseName; }
            set
            {
                if (_databaseName != value)
                {
                    _databaseName = value;
                    OnPropertyChanged("DatabaseName");
                }
            }
        }

        private string _databaseUser = string.Empty;
        public string DatabaseUser
        {
            get { return _databaseUser; }
            set
            {
                if (_databaseUser != value)
                {
                    _databaseUser = value;
                    OnPropertyChanged("DatabaseUser");
                }
            }
        }

        private string _databaseUserPassword = string.Empty;
        public string DatabaseUserPassword
        {
            get { return _databaseUserPassword; }
            set
            {
                if (_databaseUserPassword != value)
                {
                    _databaseUserPassword = value;
                    OnPropertyChanged("DatabasePass");
                }
            }
        }

        private int _databaseTimeout;
        public int DatabaseTimeout
        {
            get { return _databaseTimeout; }
            set
            {
                if (_databaseTimeout != value)
                {
                    _databaseTimeout = value;
                    OnPropertyChanged("DatabaseTimeout");
                }
            }
        }







        private ICommand _clickCheckDatabase;

        public ICommand ClickCheckDatabase
        {
            get
            {
                return _clickCheckDatabase ?? (_clickCheckDatabase = new RelayCommand(param => { CheckDatabase(); }, param => CanCheckDatabase()));
            }
        }

        private bool CanCheckDatabase()
        {
            return true;
        }

        private void CheckDatabase()
        {
            try
            {
                string connectionString = DataBaseHelper.GetConnectionString(_databaseServerName, DatabaseName, DatabaseUser,
                    DatabaseUserPassword, _databaseTimeout.ToString());

                DataBaseHelper data = new DataBaseHelper(connectionString);
                bool ret = data.CheckOpenConnection();

                if (ret)
                {
                    MessageBox.Show("Kết nối thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Kết nối không thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            catch (Exception ex)
            {
                NLogHelper.Error(ex);
                MessageBox.Show("Kết nối không thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private ICommand _clickSaveButton;
        public ICommand ClickSaveButton
        {
            get
            {
                return _clickSaveButton ?? (_clickSaveButton = new RelayCommand(param => { SaveChangeConfig(); }, param => CanSaveConfig()));
            }
        }

        private bool CanSaveConfig()
        {
            return true;
        }

        private void SaveChangeConfig()
        {
            SaveConfigValue();
            //MessageBox.Show("Lưu thành công!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private ICommand _cancelChangeConfig;

        public ICommand CancelChangeConfigCommand
        {
            get
            {
                return _cancelChangeConfig ?? (_cancelChangeConfig = new RelayCommandP<Window>(CancelChangeConfig, param => CanCancelConfig()));

            }
        }

        private bool CanCancelConfig()
        {
            return true;
        }

        private void CancelChangeConfig(Window configView)
        {
            // Close View
            if (configView != null)
            {
                configView.Close();
            }
        }
        public ConfigViewModel()
        {


            LoadConfigValue();
        }



        private void LoadConfigValue()
        {
            _mConfig = ConfigModel.LoadConfig();

            getConfigValue();
        }

        private void getConfigValue()
        {
            if (_mConfig != null)
            {
                // Database
                _databaseServerName = _mConfig.DataBaseServer;
                _databaseName = _mConfig.DatabaseName;
                _databaseUser = _mConfig.DatabaseUser;
                _databaseUserPassword = _mConfig.DatabaseUserPassword;
                _databaseTimeout = _mConfig.DatabaseTimeOut;


            }
        }

        private void SaveConfigValue()
        {
            if (_mConfig == null)
            {
                _mConfig = new ConfigModel();
            }

            updateConfigValue();



            if (ConfigModel.SaveConfig(_mConfig))
            {
                MessageBox.Show("Lưu file thành công!", "Sync FE", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Lưu file không thành công!", "Sync FE", MessageBoxButton.OK, MessageBoxImage.Error);
            }



        }

        private void updateConfigValue()
        {
            _mConfig.DataBaseServer = _databaseServerName;
            _mConfig.DatabaseName = _databaseName;
            _mConfig.DatabaseUser = _databaseUser;
            _mConfig.DatabaseUserPassword = _databaseUserPassword;
            _mConfig.DatabaseTimeOut = _databaseTimeout;




        }





    }
}
