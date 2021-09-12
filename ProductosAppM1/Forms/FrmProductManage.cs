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
    public partial class FrmProductManage : Form
    {
        private ProductoModel productoModel;
        public FrmProductManage()
        {
            productoModel = new ProductoModel();
            InitializeComponent();
        }

        private void CmbFinder_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbFinder.SelectedIndex)
            {
                case 0:
                    pnlFindById.Visible = true;
                    pnlCaducity.Visible = false;
                    pnlMeasureUnit.Visible = false;
                    pnlRangePrice.Visible = false;
                    break;

                case 1:
                    pnlFindById.Visible = false;
                    pnlCaducity.Visible = false;
                    pnlMeasureUnit.Visible = true;
                    pnlRangePrice.Visible = false;
                    break;

                case 2:
                    pnlFindById.Visible = false;
                    pnlCaducity.Visible = false;
                    pnlMeasureUnit.Visible = false;
                    pnlRangePrice.Visible = true;
                    break;

                case 3:
                    pnlFindById.Visible = false;
                    pnlCaducity.Visible = true;
                    pnlMeasureUnit.Visible = false;
                    pnlRangePrice.Visible = false;
                    break;
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FrmProductos frmProductos = new FrmProductos();
            frmProductos.PModel = productoModel;
            //MessageBox(${frmProductos.PModel.});
            frmProductos.ShowDialog();

            rtbProductView.Text = productoModel.GetProductosAsJson();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            FrmPedirId frmPedirId = new FrmPedirId(productoModel, "update");
            frmPedirId.ShowDialog();

            rtbProductView.Text = productoModel.GetProductosAsJson();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            FrmPedirId frmPedirId = new FrmPedirId(productoModel, "delete");
            frmPedirId.ShowDialog();

            rtbProductView.Text = productoModel.GetProductosAsJson();
        }
    }
}
