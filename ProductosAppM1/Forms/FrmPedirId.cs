using Domain.Entities;
using Infraestructura.Productos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductosAppM1.Forms
{
    public partial class FrmPedirId : Form
    {
        
        private ProductoModel productoModel;
        private string mode;
        public FrmPedirId(ProductoModel model, string mode)
        {
            //productoModel = new ProductoModel(); --> estoy creando un nuevo objeto que esta vacio XDD
            this.productoModel = model;
            this.mode = mode;
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int idf;
            int.TryParse(txtPedirId.Text, out idf);

            if (mode == "update")
            {

                FrmProductos frmProductos = new FrmProductos(idf);
                frmProductos.PModel = productoModel;

                if (idf <= 0)
                {
                    MessageBox.Show($"Error, el id es menor o igual a 0.",
                               "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    frmProductos.Show();
                    this.Dispose();
                }
            }
            if(mode == "delete")
            {
                
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
