﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;
namespace Manejador
{
    public class ManejadorProducto
    {
        Funciones f = new Funciones();
       
        public void Guardar(TextBox Nombre, TextBox Descripcion, TextBox Precio)
        {
            MessageBox.Show(f.Guardar($"call p_insertarProducto ('{Nombre.Text}','{Descripcion.Text}',{Precio.Text})"),
                "!Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void Borrar(int Id, string dato)
        {
            DialogResult rs = MessageBox.Show($"estas seguro de borrar {dato}",
                "!Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                f.Borrar($"call p_eliminarProducto({Id})");
                MessageBox.Show("Registro Eliminado", "!Atencion", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
        public void Modificar(TextBox Nombre, TextBox Descripcion, TextBox Precio, int Id)
        {
            MessageBox.Show(f.Modificar($"call p_modificarProducto ({Id}, '{Nombre.Text}', '{Descripcion.Text}', '{Precio.Text}') "),
                "Atencion!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        DataGridViewButtonColumn Boton(string t, Color co)
        {
            DataGridViewButtonColumn bo = new DataGridViewButtonColumn();
            bo.Text = t;
            bo.UseColumnTextForButtonValue = true;
            bo.FlatStyle = FlatStyle.Popup;
            bo.DefaultCellStyle.BackColor = co;
            bo.DefaultCellStyle.ForeColor = Color.White;
            return bo;
        }
        public void Mostrar(DataGridView tabla, string filtro)
        {
            tabla.Columns.Clear();
            tabla.DataSource = f.Mostrar($"Select * from producto where Nombre like '%{filtro}%'",
                "producto").Tables[0];
            tabla.Columns.Insert(4, Boton("Borrar", Color.Red));
            tabla.Columns.Insert(5, Boton("Modificar", Color.Green));
            tabla.AutoResizeColumns();
            tabla.AutoResizeRows();
        }


    }
}

    

