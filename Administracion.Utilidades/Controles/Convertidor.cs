using System;
using Drawing=System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows.Threading;

namespace Administracion.Utilidades.Controles
{
    public static class Convertidor
    {
        public static BitmapImage ConvertirBinarioImagen(byte[] imagenBinaria)
        {
            if (imagenBinaria == null || imagenBinaria.Length == 0)
            {
                return null;
            }

            var imagenBitmap = new BitmapImage();

            using (var stream = new MemoryStream(imagenBinaria))
            {
                stream.Position = 0;
                imagenBitmap.BeginInit();
                imagenBitmap.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                imagenBitmap.CacheOption = BitmapCacheOption.OnLoad;
                imagenBitmap.UriSource = null;
                imagenBitmap.StreamSource = stream;
                imagenBitmap.EndInit();
            }

            imagenBitmap.Freeze();

            return imagenBitmap;
        }

        public static Label ConvertirTextoLabel(string texto)
        {
            var label = new Label();
            label.Content = texto;

            return label;
        }

        public static BitmapSource CovertirBinarioBitMap(byte[] imagenBinaria, int ancho, int alto)
        {
            Drawing.Bitmap bitMap;

            bitMap = new Drawing.Bitmap(ancho, alto, PixelFormat.Format8bppIndexed);
            ColorPalette pal = bitMap.Palette;

            for (int i = 0; i < pal.Entries.Length; i++)
            {
                pal.Entries[i] = System.Drawing.Color.FromArgb(i, i, i);
            }

            bitMap.Palette = pal;

            BitmapData bitMapDatos = bitMap.LockBits(new Drawing.Rectangle(new Drawing.Point(), bitMap.Size), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);

            Marshal.Copy(imagenBinaria, 0, bitMapDatos.Scan0, imagenBinaria.Length);
            bitMap.UnlockBits(bitMapDatos);

            if (bitMap != null)
            {
                return Imaging.CreateBitmapSourceFromHBitmap(bitMap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }

            return null;
        }

        /// <summary>
        /// Covierte una lista generica a UIColeccion o crea una nueva.
        /// </summary>
        /// <typeparam name="T">Tipo de Lista</typeparam>
        /// <param name="lista">Lista de objectos. Si la lista es Null se creara una nueva instancia del tipo dado</param>
        /// <returns></returns>
        public static UIColeccion<T> ConvertirLista<T>(IEnumerable<T> lista)
        {
            return lista != null ? new UIColeccion<T>(lista) : new UIColeccion<T>();
        }

        public static byte[] GetRandomImage()
        {
            Random rnd = new Random();
            int id = rnd.Next(1, 14);
            var url= string.Format(@"C:\images\reo{0}.jpg",id);

            System.Drawing.Image img = System.Drawing.Image.FromFile(url);

            byte[] arr;
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr = ms.ToArray();
            }

            return arr;
        }
    }
}