using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Administracion.Utilidades.ClasesAuxiliares
{
    public static class ManejoDeVentanas
    {
        #region Miembros privados
        [DllImport("user32.dll")]
        private static extern
           bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern
            bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern
            bool IsIconic(IntPtr hWnd);
        #endregion

        public static bool EstaEjecutandose(string nombreProceso)
        {
            /*
            const int SW_HIDE = 0;
            const int SW_SHOWNORMAL = 1;
            const int SW_SHOWMINIMIZED = 2;
            const int SW_SHOWMAXIMIZED = 3;
            const int SW_SHOWNOACTIVATE = 4;
            const int SW_RESTORE = 9;
            const int SW_SHOWDEFAULT = 10;
            */
            const int swRestore = 9;


            var procesos = Process.GetProcessesByName(nombreProceso);

            if (procesos.Any())
            {

                // get the window handle
                IntPtr hWnd = procesos.First().MainWindowHandle;

                // if iconic, we need to restore the window
                if (IsIconic(hWnd))
                {
                    ShowWindowAsync(hWnd, swRestore);
                }

                // bring it to the foreground
                SetForegroundWindow(hWnd);
                return true;
            }

            return false;
        }
    }
}
