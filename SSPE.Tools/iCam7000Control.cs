using iCAM7000DeviceLib;
using SSPE.Tools.iCam7000Wrapper.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SSPE.Tools.iCam7000Wrapper
{
    public class iCam7000Control
    {
        #region Members
        private int connectionId;
        private short _volume;
        private static readonly iCamDeviceControl _cam = new iCamDeviceControl();
        #endregion

        #region Properties
        public string IPAddress { get; set; }

        public string SerialNumber { get; set; }

        public bool IsConnected { get; set; }

        public bool IsCapturing { get; set; }

        public CameraMode iCamMode { get; set; }

        public int TimeOut { get; set; }

        public bool AuditFace { get; set; }

        /// <summary>
        /// Range 0 - 10, lower or higher values will become 0 or 10 respectively
        /// </summary>
        public short Volume
        {
            get { return _volume; }
            set
            {
                if (value <= 0)
                    _volume = 0;
                else if (value >= 10)
                    _volume = 10;
                else
                    _volume = value;

                _cam.SetVolume(_volume);
            }
        }

        #endregion

        #region Constructors
        public iCam7000Control()
        {
            _cam.OnGetIrisImage += OnGetIrisImage;
        }

        public iCam7000Control(string serialNumber) : this()
        {
            SerialNumber = serialNumber;
        }

        public iCam7000Control(string serialNumber, string ipAddress) : this(serialNumber)
        {
            IPAddress = ipAddress;
        }
        #endregion

        #region Public Methods
        public void Connect()
        {
            if (!string.IsNullOrEmpty(IPAddress))
            {
                int conCode = _cam.Open(IPAddress, SerialNumber, out connectionId);
                if (conCode != 0)
                {
                    Disconnect();
                    ErrorCodeCheck(conCode);
                }
                SendMessage(Sound.OPERATION_SMART_BEEP, DisplayMessage.CONNECTED, LedNotification.SUCCESS);
                IsConnected = true;
            }
        }

        public void Connect(string ipAddress)
        {
            IPAddress = ipAddress;
            Connect();
        }

        public void Disconnect()
        {
            StopIrisCapture();
            SendMessage(Sound.OPERATION_SMART_BEEP, DisplayMessage.THANK_YOU, LedNotification.SUCCESS);
            int disCode = _cam.Close();
            if (disCode != 0)
            {
                ErrorCodeCheck(disCode);
            }
            IsConnected = false;
        }

        public void StartIrisCapture(CameraMode mode, Eyes eyes, CounterMeasure counterMeasureLevel, int timeout, bool auditFace)
        {
            iCamMode = mode;
            TimeOut = timeout;
            AuditFace = auditFace;
            StartIrisCapture(eyes, counterMeasureLevel);
        }

        public void StartIrisCapture(Eyes eyes, CounterMeasure counterMeasureLevel = CounterMeasure.Level1)
        {
            if (!IsCapturing)
            {
                Thread.Sleep(1000);
                SendMessage(Sound.CENTER_EYES_IN_MIRROR, DisplayMessage.LOOK_INTO_CAMERA, LedNotification.BUSY);
                int camResponse = _cam.StartIrisCapture((int)iCamMode, (int)eyes, (int)counterMeasureLevel, TimeOut * 1000, Convert.ToInt16(AuditFace));
                ErrorCodeCheck(camResponse);
                IsCapturing = true;
            }
        }

        public void StopIrisCapture()
        {
            if (IsCapturing)
                ErrorCodeCheck(_cam.StopIrisCapture());

            IsCapturing = false;
        }

        public void SendMessage(Sound sound, DisplayMessage message, LedNotification led)
        {
            _cam.ControlIndicator((int)sound, (int)message, (int)led);
        }

        #region Common Messages
        public void Identified()
        {
            SendMessage(Sound.IDENTIFIED, DisplayMessage.IDENTIFIED, LedNotification.SUCCESS);
        }

        public void NotIdentified()
        {
            SendMessage(Sound.NOT_IDENTIFIED, DisplayMessage.NOT_IDENTIFIED, LedNotification.FAILURE);
        }

        public void MoveCloser()
        {
            SendMessage(Sound.MOVE_FORWARD, DisplayMessage.MOVE_CLOSER, LedNotification.BUSY);
        }

        public void MoveBack()
        {
            SendMessage(Sound.MOVE_BACKWARD, DisplayMessage.MOVE_BACK, LedNotification.BUSY);
        }
        #endregion
        #endregion

        #region Private Methods
        private void ErrorCodeCheck(int errorCode)
        {
            switch ((ErrorCodes)errorCode)
            {
                case ErrorCodes.NONE:
                    return;
                case ErrorCodes.OPEN:
                    throw new Exception(Constants.OPEN_ERROR);
                case ErrorCodes.CLOSE:
                    throw new Exception(Constants.CLOSE_ERROR);
                case ErrorCodes.SOCKET:
                    throw new Exception(Constants.SOCKET_ERROR);
                case ErrorCodes.AUTHENTICATION:
                    throw new Exception(Constants.AUTHENTICATION_ERROR);
                case ErrorCodes.ICAM_FAILURE:
                    throw new Exception(Constants.ICAM_FAILURE);
                case ErrorCodes.PARAMETER:
                    throw new Exception(Constants.PARAMETER_ERROR);
                case ErrorCodes.IMP_VERSION:
                    throw new Exception(Constants.IMP_VERSION_ERROR);
                case ErrorCodes.LICENSE:
                    throw new Exception(Constants.LICENSE_ERROR);
                case ErrorCodes.TIME_OUT:
                    throw new Exception(Constants.TIMEOUT_ERROR);
                case ErrorCodes.WIEGAND_OUT_DISABLED:
                    throw new Exception(Constants.WIEGAND_OUT_DISABLED_ERROR);
                case ErrorCodes.RELAY_ALREADY_OPEN:
                    throw new Exception(Constants.RELAY_ALREADY_OPEN_ERROR);
                case ErrorCodes.LOW_ICAM_VERSION:
                    throw new Exception(Constants.LOW_ICAM_VERSION_ERROR);
                case ErrorCodes.UPGRADE_FAILED:
                    throw new Exception(Constants.UPGRADE_FAILED);
                case ErrorCodes.UPGRADE_ALREADY_OPEN:
                    throw new Exception(Constants.UPGRADE_ALREADY_OPEN_ERROR);
                case ErrorCodes.UPGRADE_OBSOLETE_DAT_FILES:
                    throw new Exception(Constants.UPGRADE_OBSOLETE_DAT_FILES_ERROR);
                case ErrorCodes.UPGRADE_NOT_REQUIRED:
                    throw new Exception(Constants.UPGRADE_NOT_REQUIRE);
                case ErrorCodes.API_UNSUPPORTED:
                    throw new Exception(Constants.API_UNSUPPORTED_ERROR);
                default:
                    throw new Exception(Constants.UNKNOWN_ERROR);
            }
        }
        #endregion

        #region Event Handlers
        private void OnGetIrisImage(int iConnectionID, int status, int rightImageStatus, object rightImage,
                                    int leftImageStatus, object leftImage, object auditFaceImage)
        {
            if (status == (int)ErrorCodes.TIME_OUT || status == (int)ErrorCodes.ICAM_FAILURE)
            {
                //DO SOMETHING
            }

            SendMessage(Sound.FINISH_IRIS_CAPTURE, DisplayMessage.CONNECTED, LedNotification.SUCCESS);
            bool leftOk = false, rightOk = false;
            

            if ((rightImage != null) && (((byte[])rightImage).Length != 0))
            {
                switch ((IrisImageStatus)rightImageStatus)
                {
                    case IrisImageStatus.Fake:

                        break;
                    case IrisImageStatus.Fail:

                        break;
                    case IrisImageStatus.None:
                        rightOk = true;
                        break;
                }
            }
            if ((leftImage != null) && (((byte[])leftImage).Length != 0))
            {
                switch ((IrisImageStatus)leftImageStatus)
                {
                    case IrisImageStatus.Fake:

                        break;
                    case IrisImageStatus.Fail:

                        break;
                    case IrisImageStatus.None:
                        leftOk = true;
                        break;
                }
            }

            if (OnIrisGotten != null && rightOk && leftOk)
                OnIrisGotten((byte[])leftImage, (byte[])rightImage);

            StopIrisCapture();
            Thread.Sleep(2000);
            StartIrisCapture(Eyes.Both);
        }
        #endregion

        #region Events
        public delegate void OnIrisAcquired(byte[] leftIris, byte[] rightIris);
        public event OnIrisAcquired OnIrisGotten;
        #endregion
    }
}
