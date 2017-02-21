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
            StandardServiceSoapClient fbfClient = new StandardServiceSoapClient();

            FbFRecord current = new FbFRecord();
            current.taxonomy = "78248:0:0:0:0:0:0:0";
            current.location = FbFBioLocations.UnknownIris;
            current.templates = new FbFBioTemplate[2];
            current.templates[0] = new FbFBioTemplate() { template = Convert.ToBase64String(leftIris) };
            current.templates[1] = new FbFBioTemplate() { template = Convert.ToBase64String(rightIris) };

            FbFResponseStatuses res;
            FbFException ex;

            FbFBioResult[] results = fbfClient.IdentifyBiometric(new FbFRecord[] { current }, out res, out ex);

            if (results != null && results.Length > 0)
            {
                if (string.IsNullOrEmpty(results[0].personid))
                    _cam.NotIdentified();
                else
                    _cam.Identified();
                Thread.Sleep(1000);
            }

            string directory = ConfigurationManager.AppSettings["Directory"];
            string fileName = "{0}-{1}.bmp";
            string dateFormat = "ddMMyyyyhhmmss";
            SaveImage(directory, string.Format(fileName, DateTime.Now.ToString(dateFormat), "left iris"), leftIris);
            SaveImage(directory, string.Format(fileName, DateTime.Now.ToString(dateFormat), "right iris"), rightIris);
        }

        private static Image Raw8BitByteArrayToImage(byte[] byteArray, int width, int height)
        {
            if ((byteArray == null) || (width <= 0) || (height <= 0))
                return null;

            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
            ColorPalette palette = bmp.Palette;

            for (int index = 0; index < palette.Entries.Length; index++)
                palette.Entries[index] = Color.FromArgb(index, index, index);

            bmp.Palette = palette;

            BitmapData bData = bmp.LockBits(new Rectangle(new Point(), bmp.Size),
                                            ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);

            // Copy the bytes to the bitmap object
            Marshal.Copy(byteArray, 0, bData.Scan0, byteArray.Length);

            bmp.UnlockBits(bData);

            return bmp;
        }

        private static void SaveImage(string directory, string filename, byte[] data)
        {
            string path = Path.Combine(directory, filename);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            Image img = Raw8BitByteArrayToImage(data, 640, 480);

            img.Save(path, ImageFormat.Bmp);
        }
    }
}
