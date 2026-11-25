using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoAscensor
{
    public partial class Form1 : Form
    {
        int ultimoPiso = 10;
        int altoPiso = 50;
        int margenSuperior = 25;

        int pisoActual = 0;
        int pisoDestino = 0;
        int pulsaciones = 0;

        bool atendiendoSubida = true;
        bool esperando = false;
        bool recorriendoSubida = false;
        bool recorriendoBajada = false;

        Label[] etiquetasInformacion = Array.Empty<Label>();
        Label[] etiquetasPisos = Array.Empty<Label>();

        Button[] botonesSubir = Array.Empty<Button>();
        Button[] botonesBajar = Array.Empty<Button>();

        bool[] llamadasSubir = Array.Empty<bool>();
        bool[] llamadasBajar = Array.Empty<bool>();

        Button btnAscensor = new Button();

        public Form1()
        {
            InitializeComponent();

            Load += Form1_Load;

            tmrAscensor.Tick += TmrAscensor_Tick;
            tmrEspera.Tick += TmrEspera_Tick;

            rdbEncendido.CheckedChanged += EstadoAscensor_Cambiado;
            rdbMantenimiento.CheckedChanged += EstadoAscensor_Cambiado;
            rdbApagado.CheckedChanged += EstadoAscensor_Cambiado;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            txtDesde.Text = "0";
            txtHasta.Text = ultimoPiso.ToString();

            rdbTodos.Checked = true;
            rdbEncendido.Checked = true;

            lblDireccion.Text = "Detenido";
            lblPisoActual.Text = "Piso actual: 0";

            tmrAscensor.Interval = 500;
            tmrEspera.Interval = 3000;

            CrearEtiquetasInformacion();
            CrearEdificio();
            CrearAscensor();

            CambiarColorAscensor();
        }

        private void CrearEtiquetasInformacion()
        {
            string[] textosInformacion =
            {
                "Universidad Tecnológica de Panamá",
                "Facultad de Ingeniería en Sistemas Computacionales",
                "Carrera: Desarrollo de Software",
                "Asignatura: Desarrollo de Software IV",
                "Profesor: Ricardo Chan",
                "Estudiante: Angel Ortega",
                "Cédula: 8-993-798",
                "Grupo: 1GS221",
                "Fecha de entrega: domingo 18 de octubre de 2026"
            };

            etiquetasInformacion = new Label[textosInformacion.Length];

            for (int indice = 0; indice < textosInformacion.Length; indice++)
            {
                etiquetasInformacion[indice] = new Label();

                etiquetasInformacion[indice].Name =
                    "lblInformacion" + indice;

                etiquetasInformacion[indice].Text =
                    textosInformacion[indice];

                etiquetasInformacion[indice].AutoSize = true;
                etiquetasInformacion[indice].Left = 20;
                etiquetasInformacion[indice].Top = 45 + (indice * 35);
                etiquetasInformacion[indice].Font =
                    new Font("Arial", 10, FontStyle.Regular);

                if (indice == 0 || indice == 1)
                {
                    etiquetasInformacion[indice].Font =
                        new Font("Arial", 10, FontStyle.Bold);
                }

                Controls.Add(etiquetasInformacion[indice]);
            }
        }

        private int CalcularPosicionY(int piso)
        {
            return margenSuperior + ((ultimoPiso - piso) * altoPiso);
        }

        private void CrearEdificio()
        {
            etiquetasPisos = new Label[ultimoPiso + 1];
            botonesSubir = new Button[ultimoPiso + 1];
            botonesBajar = new Button[ultimoPiso + 1];

            llamadasSubir = new bool[ultimoPiso + 1];
            llamadasBajar = new bool[ultimoPiso + 1];

            for (int piso = 0; piso <= ultimoPiso; piso++)
            {
                int posicionY = CalcularPosicionY(piso);

                etiquetasPisos[piso] = new Label();
                etiquetasPisos[piso].Name = "lblPiso" + piso;
                etiquetasPisos[piso].Text = piso.ToString();
                etiquetasPisos[piso].Width = 35;
                etiquetasPisos[piso].Height = 30;
                etiquetasPisos[piso].Left = 185;
                etiquetasPisos[piso].Top = posicionY;
                etiquetasPisos[piso].TextAlign =
                    ContentAlignment.MiddleCenter;

                etiquetasPisos[piso].Font =
                    new Font("Arial", 10, FontStyle.Bold);

                pnlEdificio.Controls.Add(etiquetasPisos[piso]);

                if (piso < ultimoPiso)
                {
                    botonesSubir[piso] = new Button();
                    botonesSubir[piso].Name = "btnSubir" + piso;
                    botonesSubir[piso].Text = "Subir";
                    botonesSubir[piso].Width = 70;
                    botonesSubir[piso].Height = 30;
                    botonesSubir[piso].Left = 100;
                    botonesSubir[piso].Top = posicionY;

                    int pisoSeleccionado = piso;

                    botonesSubir[piso].Click +=
                        (sender, e) =>
                        RegistrarLlamada(pisoSeleccionado, true);

                    pnlEdificio.Controls.Add(botonesSubir[piso]);
                }

                if (piso > 0)
                {
                    botonesBajar[piso] = new Button();
                    botonesBajar[piso].Name = "btnBajar" + piso;
                    botonesBajar[piso].Text = "Bajar";
                    botonesBajar[piso].Width = 70;
                    botonesBajar[piso].Height = 30;
                    botonesBajar[piso].Left = 225;
                    botonesBajar[piso].Top = posicionY;

                    int pisoSeleccionado = piso;

                    botonesBajar[piso].Click +=
                        (sender, e) =>
                        RegistrarLlamada(pisoSeleccionado, false);

                    pnlEdificio.Controls.Add(botonesBajar[piso]);
                }
            }
        }

        private void CrearAscensor()
        {
            btnAscensor.Name = "btnAscensor";
            btnAscensor.Text = pisoActual.ToString();
            btnAscensor.Width = 60;
            btnAscensor.Height = 35;
            btnAscensor.Left = 305;
            btnAscensor.Top = CalcularPosicionY(pisoActual);
            btnAscensor.BackColor = Color.Gold;

            btnAscensor.Font =
                new Font("Arial", 12, FontStyle.Bold);

            pnlEdificio.Controls.Add(btnAscensor);
        }

        private void RegistrarLlamada(int piso, bool esSubida)
        {
            if (!rdbEncendido.Checked)
            {
                MessageBox.Show(
                    "El ascensor está apagado o en mantenimiento.");

                return;
            }

            if (!PisoPermitido(piso))
            {
                MessageBox.Show(
                    "Ese piso no está permitido por el rango o filtro.");

                return;
            }

            pulsaciones++;

            if (pulsaciones >= 20)
            {
                ascehnsarn();
                return;
            }

            if (esSubida)
            {
                llamadasSubir[piso] = true;
                botonesSubir[piso].BackColor = Color.LightGreen;
            }
            else
            {
                llamadasBajar[piso] = true;
                botonesBajar[piso].BackColor = Color.LightBlue;
            }

            IniciarAtencionSiEstaLibre();
        }

        private bool PisoPermitido(int piso)
        {
            if (!int.TryParse(txtDesde.Text, out int desde) ||
                !int.TryParse(txtHasta.Text, out int hasta))
            {
                MessageBox.Show(
                    "Ingrese números válidos en Desde y Hasta.");

                return false;
            }

            if (desde >= hasta)
            {
                MessageBox.Show(
                    "El piso Desde debe ser menor que Hasta.");

                return false;
            }

            if (piso < desde || piso > hasta)
            {
                return false;
            }

            if (rdbPares.Checked && piso % 2 != 0)
            {
                return false;
            }

            if (rdbImpares.Checked && piso % 2 == 0)
            {
                return false;
            }

            return true;
        }

        private void IniciarAtencionSiEstaLibre()
        {
            if (tmrAscensor.Enabled || esperando)
            {
                return;
            }

            if (!HayLlamadasSubida() && !HayLlamadasBajada())
            {
                return;
            }

            if (atendiendoSubida && HayLlamadasSubida())
            {
                PrepararAtencionSubidas();
                return;
            }

            if (!atendiendoSubida && HayLlamadasBajada())
            {
                PrepararAtencionBajadas();
                return;
            }

            if (HayLlamadasSubida())
            {
                atendiendoSubida = true;
                PrepararAtencionSubidas();
            }
            else
            {
                atendiendoSubida = false;
                PrepararAtencionBajadas();
            }
        }

        private void PrepararAtencionSubidas()
        {
            recorriendoSubida = false;
            recorriendoBajada = false;

            pisoDestino = BuscarPisoSubidaMasBajo();

            if (pisoActual > pisoDestino)
            {
                lblDireccion.Text = "Bajando a buscar subida";
            }
            else if (pisoActual < pisoDestino)
            {
                lblDireccion.Text = "Subiendo a buscar subida";
            }
            else
            {
                recorriendoSubida = true;
                lblDireccion.Text = "Subiendo";
            }

            btnAscensor.BackColor = Color.LimeGreen;
            tmrAscensor.Start();
        }

        private void PrepararAtencionBajadas()
        {
            recorriendoSubida = false;
            recorriendoBajada = false;

            pisoDestino = BuscarPisoBajadaMasAlto();

            if (pisoActual < pisoDestino)
            {
                lblDireccion.Text = "Subiendo a buscar bajada";
            }
            else if (pisoActual > pisoDestino)
            {
                lblDireccion.Text = "Bajando a buscar bajada";
            }
            else
            {
                recorriendoBajada = true;
                lblDireccion.Text = "Bajando";
            }

            btnAscensor.BackColor = Color.LimeGreen;
            tmrAscensor.Start();
        }

        private void TmrAscensor_Tick(object? sender, EventArgs e)
        {
            if (!rdbEncendido.Checked)
            {
                tmrAscensor.Stop();
                CambiarColorAscensor();
                lblDireccion.Text = "Detenido";

                return;
            }

            if (pisoActual < pisoDestino)
            {
                pisoActual++;
            }
            else if (pisoActual > pisoDestino)
            {
                pisoActual--;
            }

            ActualizarAscensor();

            if (pisoActual == pisoDestino)
            {
                tmrAscensor.Stop();

                if (atendiendoSubida && !recorriendoSubida)
                {
                    recorriendoSubida = true;
                    AtenderLlamadaSubidaActual();

                    return;
                }

                if (!atendiendoSubida && !recorriendoBajada)
                {
                    recorriendoBajada = true;
                    AtenderLlamadaBajadaActual();

                    return;
                }

                if (atendiendoSubida)
                {
                    AtenderLlamadaSubidaActual();
                }
                else
                {
                    AtenderLlamadaBajadaActual();
                }
            }
        }

        private void AtenderLlamadaSubidaActual()
        {
            if (llamadasSubir[pisoActual])
            {
                llamadasSubir[pisoActual] = false;

                botonesSubir[pisoActual].BackColor =
                    SystemColors.Control;

                DetenerTresSegundos();

                return;
            }

            ContinuarSubiendo();
        }

        private void AtenderLlamadaBajadaActual()
        {
            if (llamadasBajar[pisoActual])
            {
                llamadasBajar[pisoActual] = false;

                botonesBajar[pisoActual].BackColor =
                    SystemColors.Control;

                DetenerTresSegundos();

                return;
            }

            ContinuarBajando();
        }

        private void DetenerTresSegundos()
        {
            btnAscensor.BackColor = Color.Gold;
            lblDireccion.Text = "Detenido";

            esperando = true;
            tmrEspera.Start();
        }

        private void TmrEspera_Tick(object? sender, EventArgs e)
        {
            tmrEspera.Stop();
            esperando = false;

            if (atendiendoSubida)
            {
                ContinuarSubiendo();
            }
            else
            {
                ContinuarBajando();
            }
        }

        private void ContinuarSubiendo()
        {
            int siguientePiso = BuscarSiguienteSubidaArriba();

            if (siguientePiso != -1)
            {
                pisoDestino = siguientePiso;
                lblDireccion.Text = "Subiendo";
                btnAscensor.BackColor = Color.LimeGreen;

                tmrAscensor.Start();

                return;
            }

            recorriendoSubida = false;
            atendiendoSubida = false;

            IniciarAtencionSiEstaLibre();
        }

        private void ContinuarBajando()
        {
            int siguientePiso = BuscarSiguienteBajadaAbajo();

            if (siguientePiso != -1)
            {
                pisoDestino = siguientePiso;
                lblDireccion.Text = "Bajando";
                btnAscensor.BackColor = Color.LimeGreen;

                tmrAscensor.Start();

                return;
            }

            recorriendoBajada = false;
            atendiendoSubida = true;

            IniciarAtencionSiEstaLibre();
        }

        private int BuscarSiguienteSubidaArriba()
        {
            for (int piso = pisoActual + 1; piso <= ultimoPiso; piso++)
            {
                if (llamadasSubir[piso])
                {
                    return piso;
                }
            }

            return -1;
        }

        private int BuscarSiguienteBajadaAbajo()
        {
            for (int piso = pisoActual - 1; piso >= 0; piso--)
            {
                if (llamadasBajar[piso])
                {
                    return piso;
                }
            }

            return -1;
        }

        private int BuscarPisoSubidaMasBajo()
        {
            for (int piso = 0; piso <= ultimoPiso; piso++)
            {
                if (llamadasSubir[piso])
                {
                    return piso;
                }
            }

            return pisoActual;
        }

        private int BuscarPisoBajadaMasAlto()
        {
            for (int piso = ultimoPiso; piso >= 0; piso--)
            {
                if (llamadasBajar[piso])
                {
                    return piso;
                }
            }

            return pisoActual;
        }

        private bool HayLlamadasSubida()
        {
            for (int piso = 0; piso <= ultimoPiso; piso++)
            {
                if (llamadasSubir[piso])
                {
                    return true;
                }
            }

            return false;
        }

        private bool HayLlamadasBajada()
        {
            for (int piso = 0; piso <= ultimoPiso; piso++)
            {
                if (llamadasBajar[piso])
                {
                    return true;
                }
            }

            return false;
        }

        private void ActualizarAscensor()
        {
            btnAscensor.Top = CalcularPosicionY(pisoActual);
            btnAscensor.Text = pisoActual.ToString();

            lblPisoActual.Text =
                "Piso actual: " + pisoActual;
        }

        private void EstadoAscensor_Cambiado(
            object? sender,
            EventArgs e)
        {
            if (rdbEncendido.Checked)
            {
                btnAscensor.BackColor = Color.Gold;
                lblDireccion.Text = "Detenido";

                IniciarAtencionSiEstaLibre();
            }
            else
            {
                tmrAscensor.Stop();
                tmrEspera.Stop();

                esperando = false;
                recorriendoSubida = false;
                recorriendoBajada = false;

                btnAscensor.BackColor = Color.Red;

                if (rdbApagado.Checked)
                {
                    lblDireccion.Text = "Apagado";
                }
                else if (rdbMantenimiento.Checked)
                {
                    lblDireccion.Text = "Mantenimiento";
                }
            }
        }

        private void CambiarColorAscensor()
        {
            if (rdbEncendido.Checked)
            {
                btnAscensor.BackColor = Color.Gold;
            }
            else
            {
                btnAscensor.BackColor = Color.Red;
            }
        }

        private void ascehnsarn()
        {
            MessageBox.Show(
                "Desbordamiento del vector",
                "Advertencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            pulsaciones = 0;
        }
    }
}