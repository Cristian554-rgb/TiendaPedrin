using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Manejador;
namespace Tienda
{
    public partial class FrmBuscarProducto : Form
    {
        ManejadorProducto mp;
        int fila = 0, columna = 0;
        public static int Id = 0;
        public static string Nombre = "", Descripcion = "", Precio = "";



        private void dtgvProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex; columna = e.ColumnIndex;
            switch (columna)
            {
                case 4:
                    {
                        Id = int.Parse(dtgvProducto.Rows[fila].Cells[0].Value.ToString());
                        mp.Borrar(Id, dtgvProducto.Rows[fila].Cells[1].Value.ToString()); dtgvProducto.Visible = false;
                    }
                    break;
                case 5:
                    {
                        Id = int.Parse(dtgvProducto.Rows[fila].Cells[0].Value.ToString());
                        Nombre = dtgvProducto.Rows[fila].Cells[1].Value.ToString();
                        Descripcion = dtgvProducto.Rows[fila].Cells[2].Value.ToString();
                        Precio = dtgvProducto.Rows[fila].Cells[3].Value.ToString();



                        FrmProducto fp = new FrmProducto();
                        fp.ShowDialog();
                        dtgvProducto.Visible = false;
                    }
                    break;
            }

        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            Id = 0; Nombre = ""; Descripcion = ""; Precio = "";
            FrmProducto fu = new FrmProducto();
            fu.ShowDialog();
            txtNombre.Focus();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            dtgvProducto.Visible = true;
            mp.Mostrar(dtgvProducto, txtNombre.Text);
        }
        public FrmBuscarProducto()
        {
            mp = new ManejadorProducto();
            InitializeComponent();
              
        }

       
    }
}
