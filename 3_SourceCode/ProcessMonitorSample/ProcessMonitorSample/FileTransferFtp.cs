using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinSCP;
using System.IO;

namespace ProcessMonitorSample
{
    public class FileTransferFtp
    {
        #region Fields
        /// <summary>
        /// mỗi đối tượng FileTransferFtp có thuộc tính _sessionOptions
        /// </summary>
        private SessionOptions _sessionOptions;
        public SessionOptions SessionOptions
        {
            get { return _sessionOptions; }
            set { _sessionOptions = value; }
        }
        #endregion
        #region Constructor
        public FileTransferFtp()
        {
            _sessionOptions = new SessionOptions
            {
                Protocol = Protocol.Ftp,
                HostName = "10.0.4.255",
                PortNumber = 21,
                UserName = "vietphan",
                Password = "vietphan",
                TimeoutInMilliseconds = 60000
            };
        }
        public FileTransferFtp(string address, int portNumber, string userName, string password, int timeOut)
        {
            _sessionOptions = new SessionOptions
            {
                Protocol = Protocol.Ftp,
                HostName = address,
                PortNumber = portNumber,
                UserName = userName,
                Password = password,
                TimeoutInMilliseconds = timeOut
            };
        }
        #endregion

        #region Download
        public List<string> DownloadDirectory(string localPath, string remotePath)
        {
            List<string> downloadList = new List<string>();
            try
            {
                using (Session session = new Session())
                {
                    session.Open(_sessionOptions);

                    TransferOptions transferOptions = new TransferOptions();
                    transferOptions.TransferMode = TransferMode.Binary;
                    if (!Directory.Exists(localPath))
                    {
                        Directory.CreateDirectory(localPath);
                    }
                    SynchronizationResult synchronizationResult = session.SynchronizeDirectories(SynchronizationMode.Local, localPath,
                            remotePath, false, false, SynchronizationCriteria.Time, transferOptions);
                    synchronizationResult.Check();
                    TransferEventArgsCollection transferCollection = synchronizationResult.Downloads;

                    foreach (TransferEventArgs transfer in transferCollection)
                    {
                        downloadList.Add(transfer.Destination);
                        //NLogHelper.Info("Successful " + transfer.Destination);
                    }

                }
            }
            catch (Exception ex)
            {
                //NLogHelper.Error(ex);
                ex.ToString();
            }
            return downloadList;
        }
        #endregion
        #region Upload
        public List<string> UploadDirectory(string localPath, string remotePath)
        {
            List<string> uploadList = new List<string>();
            try
            {
                using (Session session = new Session())
                {
                    session.Open(_sessionOptions);

                    TransferOptions transferOptions = new TransferOptions();
                    transferOptions.TransferMode = TransferMode.Binary;
                    if (!session.FileExists(remotePath))
                    {
                        session.CreateDirectory(remotePath);
                    }
                    SynchronizationResult synchronizationResult = session.SynchronizeDirectories(SynchronizationMode.Remote, localPath,
                            remotePath, false, false, SynchronizationCriteria.Time, transferOptions);
                    synchronizationResult.Check();
                    TransferEventArgsCollection transferCollection = synchronizationResult.Uploads;

                    foreach (TransferEventArgs transfer in transferCollection)
                    {
                        uploadList.Add(transfer.FileName);
                        //NLogHelper.Info("Successful " + transfer.FileName);
                    }
                    return uploadList;
                }
            }
            catch (Exception ex)
            {
                //NLogHelper.Error(ex);
                ex.ToString();
            }
            return uploadList;
        }
        #endregion
        #region Check
        #endregion
    }
}
