#nullable disable

namespace ProyectoAscensor
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pnlEdificio = new Panel();
            lblDireccion = new Label();
            lblPisoActual = new Label();
            grpRango = new GroupBox();
            lblDesde = new Label();
            txtDesde = new TextBox();
            lblHasta = new Label();
            txtHasta = new TextBox();
            grpTipoPisos = new GroupBox();
            rdbPares = new RadioButton();
            rdbImpares = new RadioButton();
            rdbTodos = new RadioButton();
            grpEstado = new GroupBox();
            rdbEncendido = new RadioButton();
            rdbMantenimiento = new RadioButton();
            rdbApagado = new RadioButton();
            tmrAscensor = new System.Windows.Forms.Timer(components);
            tmrEspera = new System.Windows.Forms.Timer(components);
            grpRango.SuspendLayout();
            grpTipoPisos.SuspendLayout();
            grpEstado.SuspendLayout();
            SuspendLayout();
            // 
            // pnlEdificio
            // 
            pnlEdificio.BorderStyle = BorderStyle.FixedSingle;
            resources.ApplyResources(pnlEdificio, "pnlEdificio");
            pnlEdificio.Name = "pnlEdificio";
            // 
            // lblDireccion
            // 
            resources.ApplyResources(lblDireccion, "lblDireccion");
            lblDireccion.Name = "lblDireccion";
            // 
            // lblPisoActual
            // 
            resources.ApplyResources(lblPisoActual, "lblPisoActual");
            lblPisoActual.Name = "lblPisoActual";
            // 
            // grpRango
            // 
            grpRango.Controls.Add(lblDesde);
            grpRango.Controls.Add(txtDesde);
            grpRango.Controls.Add(lblHasta);
            grpRango.Controls.Add(txtHasta);
            resources.ApplyResources(grpRango, "grpRango");
            grpRango.Name = "grpRango";
            grpRango.TabStop = false;
            // 
            // lblDesde
            // 
            resources.ApplyResources(lblDesde, "lblDesde");
            lblDesde.Name = "lblDesde";
            // 
            // txtDesde
            // 
            resources.ApplyResources(txtDesde, "txtDesde");
            txtDesde.Name = "txtDesde";
            // 
            // lblHasta
            // 
            resources.ApplyResources(lblHasta, "lblHasta");
            lblHasta.Name = "lblHasta";
            // 
            // txtHasta
            // 
            resources.ApplyResources(txtHasta, "txtHasta");
            txtHasta.Name = "txtHasta";
            // 
            // grpTipoPisos
            // 
            grpTipoPisos.Controls.Add(rdbPares);
            grpTipoPisos.Controls.Add(rdbImpares);
            grpTipoPisos.Controls.Add(rdbTodos);
            resources.ApplyResources(grpTipoPisos, "grpTipoPisos");
            grpTipoPisos.Name = "grpTipoPisos";
            grpTipoPisos.TabStop = false;
            // 
            // rdbPares
            // 
            resources.ApplyResources(rdbPares, "rdbPares");
            rdbPares.Name = "rdbPares";
            rdbPares.UseVisualStyleBackColor = true;
            // 
            // rdbImpares
            // 
            resources.ApplyResources(rdbImpares, "rdbImpares");
            rdbImpares.Name = "rdbImpares";
            rdbImpares.UseVisualStyleBackColor = true;
            // 
            // rdbTodos
            // 
            resources.ApplyResources(rdbTodos, "rdbTodos");
            rdbTodos.Checked = true;
            rdbTodos.Name = "rdbTodos";
            rdbTodos.TabStop = true;
            rdbTodos.UseVisualStyleBackColor = true;
            // 
            // grpEstado
            // 
            grpEstado.Controls.Add(rdbEncendido);
            grpEstado.Controls.Add(rdbMantenimiento);
            grpEstado.Controls.Add(rdbApagado);
            resources.ApplyResources(grpEstado, "grpEstado");
            grpEstado.Name = "grpEstado";
            grpEstado.TabStop = false;
            // 
            // rdbEncendido
            // 
            resources.ApplyResources(rdbEncendido, "rdbEncendido");
            rdbEncendido.Checked = true;
            rdbEncendido.Name = "rdbEncendido";
            rdbEncendido.TabStop = true;
            rdbEncendido.UseVisualStyleBackColor = true;
            // 
            // rdbMantenimiento
            // 
            resources.ApplyResources(rdbMantenimiento, "rdbMantenimiento");
            rdbMantenimiento.Name = "rdbMantenimiento";
            rdbMantenimiento.UseVisualStyleBackColor = true;
            // 
            // rdbApagado
            // 
            resources.ApplyResources(rdbApagado, "rdbApagado");
            rdbApagado.Name = "rdbApagado";
            rdbApagado.UseVisualStyleBackColor = true;
            // 
            // tmrAscensor
            // 
            tmrAscensor.Interval = 500;
            // 
            // tmrEspera
            // 
            tmrEspera.Interval = 3000;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(grpEstado);
            Controls.Add(grpTipoPisos);
            Controls.Add(grpRango);
            Controls.Add(lblPisoActual);
            Controls.Add(lblDireccion);
            Controls.Add(pnlEdificio);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            grpRango.ResumeLayout(false);
            grpRango.PerformLayout();
            grpTipoPisos.ResumeLayout(false);
            grpTipoPisos.PerformLayout();
            grpEstado.ResumeLayout(false);
            grpEstado.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlEdificio;

        private Label lblDireccion;
        private Label lblPisoActual;

        private GroupBox grpRango;
        private Label lblDesde;
        private Label lblHasta;
        private TextBox txtDesde;
        private TextBox txtHasta;

        private GroupBox grpTipoPisos;
        private RadioButton rdbPares;
        private RadioButton rdbImpares;
        private RadioButton rdbTodos;

        private GroupBox grpEstado;
        private RadioButton rdbEncendido;
        private RadioButton rdbMantenimiento;
        private RadioButton rdbApagado;

        private System.Windows.Forms.Timer tmrAscensor;
        private System.Windows.Forms.Timer tmrEspera;
    }
}