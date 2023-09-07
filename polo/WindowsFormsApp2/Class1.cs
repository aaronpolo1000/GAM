using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
namespace WindowsFormsApp2
{
   
    public class Reproductor
    {





        [DllImport("winmm.dll")]
        public static extern int mciSendString(string lpstrCommand,
StringBuilder lpstrReturnString, int uReturnLengh, int hwndCallback);
        [DllImport("winmm.dll")]
        public static extern string mciGetErrorString(int fwdError, StringBuilder lpszErrorText,
int cchErrorText);
        [DllImport("winmm.dll")]
        public static extern int waveOutGetNumDevs();
        [DllImport("kernel32.dll")]
        public static extern int GetLongPathName(string
lpszShortPath, StringBuilder lpszLongPath, int cchBuffer);
        [DllImport("kernel32.dll")]
        public static extern int GetShortPathName(string lpszLongPath,
StringBuilder lpszShortPath, int cchBuffer);



        const int MAX_PATH = 260;
        const string Tipo = "MPEGVIDEO";
        const string sAlias = "ArchivoDeSoniido";
        private string fileName;
        public Reproductor() {

        }

        public delegate void ReproductorMessage(string Mag);
        public event ReproductorMessage ReproductorEstado;
        public string NombreDelArchivo
        {
            get { return fileName ; }
            set { fileName = value; }
        }

        private string NombreCorto(string NombreLargo)
        {
            StringBuilder sBuffer=new StringBuilder(MAX_PATH);
        
            if (GetShortPathName(NombreLargo, sBuffer, MAX_PATH) > 0)
                return sBuffer.ToString();
            else
                return "";
        }

        public string NombreLargo(string NombreCorto)
        {

            StringBuilder sbBuffer = new StringBuilder(MAX_PATH);

            if (GetLongPathName(NombreCorto, sbBuffer, MAX_PATH) > 0)
                return sbBuffer.ToString();
            else
                return "";
        }
        private string MciMensajesDeError(int ErrorCode)
        {
            StringBuilder sbBuffer = new StringBuilder(MAX_PATH);
            if (mciGetErrorString(ErrorCode, sbBuffer, MAX_PATH) != "0")
                return sbBuffer.ToString();
            else
                return "";
        }

        public int DispositivosDeSonido()
        {
            return waveOutGetNumDevs();
        }
        private bool Abrir()
        {
            if (!File.Exists(fileName))return false;
            string nombreCorto = NombreCorto(fileName);
            if (mciSendString("open " + nombreCorto + " type " + Tipo +
       " alias " + sAlias, null, 0, 0) == 0) return true; else return false;
        }

        public void Reproducir()
        {
            if (fileName != "")
            {
                if (Abrir())
                {
                    int mciResul = mciSendString("play " + sAlias, null, 0, 0);
                    if (mciResul == 0) { ReproductorEstado("OK"); } else ReproductorEstado(MciMensajesDeError(mciResul));
                }
                else ReproductorEstado("No se a logrado abrir el archivo");
            }
            else ReproductorEstado("No se a dado un nombre de archivo");
        }
        public void ReproducirDesde(long Desde)
        {
            int mciResul= mciSendString("play "+sAlias+" from "+ (Desde * 1000).ToString(), null, 0, 0);
            if (mciResul == 0)
                ReproductorEstado("Nueva Posición: " + Desde.ToString());
            else
                ReproductorEstado(MciMensajesDeError(mciResul));
        }
        public void Reposicionar(int NuevaPosicion)
        {
            int mciResul = mciSendString("seek " + sAlias + " to " +
            (NuevaPosicion * 1000).ToString(), null, 0, 0);
            if (mciResul == 0)
                ReproductorEstado("Nueva Posición: " + NuevaPosicion.ToString());
            else
                ReproductorEstado(MciMensajesDeError(mciResul));
        }
        public void  Velocidad(int Tramas)
        {
            int mciResul=mciSendString("set "+ sAlias+" tempo "+Tramas, null, 0, 0);
            if (mciResul == 0) ReproductorEstado("Velocidad modificada"); else ReproductorEstado(MciMensajesDeError(mciResul));
        } 
        public void Principio()
        {
            int mciResul = mciSendString("seek " + sAlias + " to start" , null, 0, 0);
            if (mciResul == 0)
                ReproductorEstado("Inicio de" + Path.GetFileNameWithoutExtension(fileName));
            else
                ReproductorEstado(MciMensajesDeError(mciResul));
        }
        public void Final()
        {
            int mciResul = mciSendString("seek " + sAlias + " to end ", null, 0, 0);
            if (mciResul == 0)
                ReproductorEstado("Final de" + Path.GetFileNameWithoutExtension(fileName));
            else
                ReproductorEstado(MciMensajesDeError(mciResul));
        }
        public void Pausar()
        {
            int mciResul = mciSendString("pause " + sAlias, null, 0, 0);
            if (mciResul == 0)
                ReproductorEstado("Pausada");
            else
                ReproductorEstado(MciMensajesDeError(mciResul));
        }
        public void Continuar()
        {
            int mciResul = mciSendString("resume " + sAlias, null, 0, 0);
            if (mciResul == 0)
        
                ReproductorEstado("Continuar");
            else 
                ReproductorEstado(MciMensajesDeError(mciResul));
        }
        public void Cerrar()
        {
            mciSendString("stop " + sAlias, null, 0, 0);
            mciSendString("close " + sAlias, null, 0, 0);
        }
        public void Detener()
        {
            mciSendString("stop " + sAlias, null, 0, 0);
        }
        public string Estado()
        {
            StringBuilder sbBuffer = new StringBuilder(MAX_PATH);
            mciSendString("status " + sAlias + " mode", sbBuffer, MAX_PATH, 0);
            return sbBuffer.ToString();
        }
        public bool EstadoReproduciendo()
        {
            return Estado() == "playing" ? true : false;
        }

        public bool EstadoPausado()
        {
            return Estado() == "paused" ? true : false;
        }
        public bool EstadoDetenido()
        {
            return Estado() == "stopped" ? true : false;
        }
        public bool EstadoAbierto()
        {
            return Estado() == "open" ? true : false;
        }
        public long CalcularPosicion()
        {
            StringBuilder sbBuffer = new StringBuilder(MAX_PATH);
            mciSendString("set " + sAlias + " time format milliseconds", null, 0, 0);
            mciSendString("status " + sAlias + " position", sbBuffer, MAX_PATH, 0);

            if (sbBuffer.ToString() != "")
                return long.Parse(sbBuffer.ToString()) / 1000;
            else 
                return 0L;
        }
        public string Posicion()
        {
            long sec = CalcularPosicion();
            long mins;

            if (sec < 60)
                return "0:" + String.Format("{0:D2}", sec);
            else if (sec > 59)
            {
                mins = (int)(sec / 60);
                sec = sec - (mins * 60);
                return String.Format("{0:D2}", mins) + ":" + String.Format("{0:D2}", sec);
            }
            else 
                return "";
        }
        public long CalcularTamaño()
        {
            StringBuilder sbBuffer = new StringBuilder(MAX_PATH);
            mciSendString("set " + sAlias + " time format milliseconds", null, 0, 0);
            mciSendString("status " + sAlias + " length", sbBuffer, MAX_PATH, 0);

            if (sbBuffer.ToString() != "")
                return long.Parse(sbBuffer.ToString()) / 1000;
            else 
                return 0L;
        }
        public string Tamaño()
        {
            long sec = CalcularTamaño();
            long mins;

            if (sec < 60)
                return "0:" + String.Format("{0:D2}", sec);
            else if (sec > 59)
            {
                mins = (int)(sec / 60);
                sec = sec - (mins * 60);
                return String.Format("{0:D2}", mins) + ":" + String.Format("{0:D2}", sec);
            }
            else
                return "";
        }
    }

}
