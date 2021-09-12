using Domain.Entities;
using Domain.Enums;
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
    public partial class FrmProductos : Form
    {
        public ProductoModel PModel { get; set; }
        private int id;
        private Producto producto;
        public FrmProductos()
        {
            InitializeComponent();
        }

        public FrmProductos(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void VtnAccept_Click(object sender, EventArgs e)
        {

            if (this.id > 0)
            {
                this.producto.Nombres = txtNames.Text;
                this.producto.Descripcion = txtDescription.Text;
                this.producto.Existencia = (int)nudExist.Value;
                this.producto.Precio = nudPrice.Value;
                this.producto.FechaDeVencimiento = dtpCaducity.Value;
                this.producto.UnidadMedida = (UnidadMedida)cmbMeasureUnit.SelectedIndex;

                PModel.Update(this.producto);
            }
            else
            {
                Producto p = new Producto()
                {
                    Id = PModel.GetLastProductoId() + 1,
                    Nombres = txtNames.Text,
                    Descripcion = txtDescription.Text,
                    Existencia = (int)nudExist.Value,
                    Precio = nudPrice.Value,
                    FechaDeVencimiento = dtpCaducity.Value,
                    UnidadMedida = (UnidadMedida)cmbMeasureUnit.SelectedIndex
                };

                PModel.Add(p);
            }

            Dispose();//lo que hace es cerrar la ventana
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            cmbMeasureUnit.Items.AddRange(Enum.GetValues(typeof(UnidadMedida))
                                              .Cast<object>()
                                              .ToArray());

            if(this.id != 0)
            {
                this.producto = this.PModel.GetProductoById(this.id);

                txtNames.Text = this.producto.Nombres;
                txtDescription.Text = this.producto.Descripcion;
                nudExist.Value = this.producto.Existencia;
                nudPrice.Value = this.producto.Precio;
                dtpCaducity.Value = this.producto.FechaDeVencimiento;
                cmbMeasureUnit.SelectedItem = this.producto.UnidadMedida;

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
