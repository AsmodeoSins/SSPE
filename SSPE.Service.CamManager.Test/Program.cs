using SSPE.Service.CamManager.Test.FbFWebService;
using SSPE.Tools.iCam7000Wrapper;
using SSPE.Tools.iCam7000Wrapper.Enums;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SSPE.Service.CamManager.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRemote = false;
            string path = string.Empty;


            if (isRemote)
            {
                byte[] leftiris = Convert.FromBase64String(File.ReadAllText(Path.Combine(path, "leftiris.txt")));
                byte[] rightiris = Convert.FromBase64String(File.ReadAllText(Path.Combine(path, "rightiris.txt")));
                Cam_OnIrisGotten(leftiris, rightiris);
            }
            else
            {
                _cam.iCamMode = CameraMode.Recognition;
                _cam.OnIrisGotten += Cam_OnIrisGotten;

                _cam.Connect("172.20.4.200");
                _cam.Volume = 8;
                _cam.StartIrisCapture(Eyes.Both);
                Console.Read();
                _cam.Disconnect();
            }
        }

        private static iCam7000Control _cam = new iCam7000Control();

        private static void Cam_OnIrisGotten(byte[] leftIris, byte[] rightIris)
        {
            string personId = GetIdentity(leftIris, rightIris);

            if (string.IsNullOrEmpty(personId))
                _cam.NotIdentified();
            else
                _cam.Identified();
            Thread.Sleep(1000);

            string directory = ConfigurationManager.AppSettings["Directory"];
            string fileName = "{0}-{1}.bmp";
            string dateFormat = "ddMMyyyyhhmmss";
            SaveImage(directory, string.Format(fileName, DateTime.Now.ToString(dateFormat), "left iris"), leftIris);
            SaveImage(directory, string.Format(fileName, DateTime.Now.ToString(dateFormat), "right iris"), rightIris);
        }

        private static string GetIdentity(byte[] leftIris, byte[] rightIris)
        {
            StandardServiceSoapClient fbfClient = new StandardServiceSoapClient();

            byte[] leftIrisTemplate = fbfClient.ExtractTemplate(leftIris, (int)FbFBioLocations.LeftIris, (int)FbFTemplateTypes.MMStandard);
            byte[] rightIrisTemplate = fbfClient.ExtractTemplate(rightIris, (int)FbFBioLocations.RightIris, (int)FbFTemplateTypes.MMStandard);

            if (leftIrisTemplate != null && rightIrisTemplate != null)
            {
                FbFRecord current = new FbFRecord();
                current.location = FbFBioLocations.UnknownIris;
                current.templates = new FbFBioTemplate[2];
                current.templates[0] = new FbFBioTemplate() { template = Convert.ToBase64String(leftIrisTemplate) };
                current.templates[1] = new FbFBioTemplate() { template = Convert.ToBase64String(rightIrisTemplate) };

                FbFResponseStatuses res;
                FbFException ex;

                FbFBioResult[] results = fbfClient.IdentifyBiometric(new FbFRecord[] { current }, out res, out ex);

                if (results.Length == 2)
                    if (results[0].personid.Equals(results[1].personid))
                        return results[0].personid;
            }

            return null;
        }

        private static void SaveImage(string directory, string filename, byte[] data)
        {
            string path = Path.Combine(directory, filename);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            using (Stream ms = new MemoryStream(data))
            {
                Image img = Image.FromStream(ms);
                img.Save(path, ImageFormat.Bmp);
            }
        }
    }
}