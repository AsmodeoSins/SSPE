using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Administracion.Presentacion.Modelos
{
    public class Carousel
    {
        public double PosicionLeft { get; set; }

        public double PosicionTop { get; set; }

        public double Opacidad { get; set; }

        public double PosicionZIndex { get; set; }

        public ScaleTransform Escalamiento { get; set; }

        public string Titulo { get; set; }

        public string Subtitulo { get; set; }

        public ImageSource Imagen { get; set; }
    }
}
