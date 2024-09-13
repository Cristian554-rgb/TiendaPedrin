using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manejador;
namespace Tienda
{
    public partial class FrmProducto : Form
    {
        ManejadorProducto mp;
        public FrmProducto()
        {
            InitializeComponent();
            mp = new ManejadorProducto();   
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (FrmBuscarProducto.Id > 0)
            {
                mp.Modificar(txtNombre, txtDescripcion, txtPrecio, FrmBuscarProducto.Id);
            }
            else
            {
                mp.Guardar(txtNombre, txtDescripcion, txtPrecio);
            }
            Close();
        }
    }
}
