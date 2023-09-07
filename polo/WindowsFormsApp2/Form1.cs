using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private Reproductor Sonido = new Reproductor();
        private Hashtable hashMusica = new Hashtable();
        private bool trackBarClick = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            stTiempos.Panels[0].Text = "Listo";
            Sonido.ReproductorEstado += new Reproductor.ReproductorMessage( this.MensajesDelReproductor);
            openFileDialog1.Multiselect = true;
            int numDevs = Sonido.DispositivosDeSonido();
            if (numDevs == 0)
                MessageBox.Show("No se han encontrado dispositivos de salida de audio \n presentes en el sistema", "Dispositivos no encontrados",
        
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void MensajesDelReproductor(string Msg)
        {
            // Sí el mensaje es diferente de Ok, 
            if (Msg != "Ok")
            {
                // se muestra en el panel de mensajes.
                stMensajes.Text = Msg;
                // y detenemos el reloj.
                timer1.Stop();
                timer1.Enabled = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Visible == true)
            {
                Sonido.Continuar();
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
                timer1.Start();
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Visible == true)
            {
                Sonido.Pausar();
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
                timer1.Stop();
            }
        }

        private void Form1_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
                e.Effect = DragDropEffects.Copy;
        }

        private void Form1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string[] archivos = (string[])(e.Data.GetData(DataFormats.FileDrop));
            for (int i = 0; i < archivos.Length; i++)
            {
                if (Path.GetExtension(archivos[i]) == ".mp3")
                    AgregarArchivos(Sonido.NombreLargo(archivos[i]));
            }
        }
        private void linkLabel2_LinkClicked(object sender,
System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                listBox1.Items.Clear();
                hashMusica.Clear();
            }
        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            // Cerramos la aplicación.
            Close();
        }
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            // Cada tick de nuestro reloj de control, nos permitirá
            // actualizar el panel de tiempos, con el total de tiempo y
            // tiempo transcurrido y el progreso
            stTiempos.Panels[0].Text = "Tiempo Total: " + Sonido.Tamaño();
            stTiempos.Panels[1].Text = "Tiempo Tracurrido: " + Sonido.Posicion();
            stMensajes.Text = "Estado del Reproductor:" + Sonido.Estado();

            if (!trackBarClick)
                trackBar1.Value = (int)Sonido.CalcularPosicion();

            if (Sonido.EstadoDetenido())
            {
                DetenerReproduccion();
                if ((listBox1.SelectedIndex < listBox1.Items.Count - 1) && checkBox1.Checked)
                {
                    listBox1.SelectedIndex = listBox1.SelectedIndex + 1;
                    IniciarReproduccion();
                }
            }
        }


        private void Form1_Closing(object sender,
System.ComponentModel.CancelEventArgs e)
        {
            if (Sonido.EstadoReproduciendo() || Sonido.EstadoPausado() ||
            Sonido.EstadoAbierto())
                Sonido.Cerrar();
        }
        private void AgregarArchivos(string NombreArchivoLargo)
        {
            string nombreArchivo = Path.GetFileNameWithoutExtension(NombreArchivoLargo);
            if (!hashMusica.ContainsKey(nombreArchivo))
            {
                hashMusica.Add(nombreArchivo, NombreArchivoLargo);
                listBox1.Items.Add(nombreArchivo);
            }
        }

        private string ObtenerNombreLargo(string ArchivoBuscado)
        {
            foreach (DictionaryEntry entry in hashMusica)
            {
                if (entry.Key.ToString() == ArchivoBuscado)
                    return entry.Value.ToString();
            } 
            return "";
        }


        private void IniciarReproduccion()
        {
            if (listBox1.SelectedIndex > -1)
            {
                if (Sonido.EstadoReproduciendo()) DetenerReproduccion();
                Sonido.NombreDelArchivo = ObtenerNombreLargo(
                listBox1.SelectedItem.ToString());
                Sonido.Reproducir();
                trackBar1.Minimum = 0;
                trackBar1.Maximum = (int)Sonido.CalcularTamaño();
                timer1.Enabled = true;
                timer1.Start();
            }
        }












        private void pictureBox1_LocationChanged(object sender, EventArgs e)
        {

        }

       
        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void statusBar1_PanelClick(object sender, StatusBarPanelClickEventArgs e)
        {

        }

        private void statusBar1_PanelClick_1(object sender, StatusBarPanelClickEventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void statusBar1_PanelClick_2(object sender, StatusBarPanelClickEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            IniciarReproduccion();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DetenerReproduccion();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Archivos de mp3 (*.mp3) | *.mp3";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] archivos = openFileDialog1.FileNames;
                for (int i = 0; i < archivos.Length; i++)
                    AgregarArchivos(archivos[i]);
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            IniciarReproduccion();
        }

        private void trackBar1_MouseDown(object sender, MouseEventArgs e)
        {
            trackBarClick = true;
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            trackBarClick = false;
            Sonido.Detener();
            Sonido.Reposicionar(trackBar1.Value);
            Sonido.ReproducirDesde(trackBar1.Value);
            timer1.Start();
        }
        private void DetenerReproduccion()
        {
            // Cerramos el archivo actual en reproducción,detenemos el reloj de control
            // e reiniciamos los recursos utilizados.
            Sonido.Cerrar();
            timer1.Enabled = false;
            timer1.Stop();
            trackBar1.Value = 0;
            stTiempos.Panels[0].Text = "Tiempo Total:";
            stTiempos.Panels[1].Text = "Tiempo Transcurrido:";
            stMensajes.Text = "Listo";
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }
    }
}
