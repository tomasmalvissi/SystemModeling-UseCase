using OrdenesDeTrabajo.Class;
using OT.Conex;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdenesDeTrabajo.WF
{
    public partial class FClientes : Form
    {
        #region Variables
        private int cuil;
        private string nom;
        private string dir;
        private string tel;
        private string email;
        private string accion;
        #endregion
        public FClientes()
        {
            InitializeComponent();
            DgvClientes();
        }
        #region Instancias
        Clientes cliente = new Clientes();
        DatosClientes datcli = new DatosClientes();
        #endregion
        #region Metodos
        private void InitVariables()
        {
            cuil = Convert.ToInt32(txtCuil.Text);
            nom = txtNom.Text;
            dir = txtDir.Text;
            tel = txtTel.Text;
            email = txtmail.Text;
        }
        private void LimpiarTxt()
        {
            txtCuil.Clear();
            txtNom.Clear();
            txtDir.Clear();
            txtTel.Clear();
            txtmail.Clear();
        }
        private void CargarCliente()
        {
            InitVariables();
            cliente.Cuil = cuil;
            cliente.Nombre = nom;
            cliente.Direccion = dir;
            cliente.Telefono = tel;
            cliente.Email = email;
            accion = "Alta";
            DgvClientes();
            datcli.ABMClientes(accion, cliente);        
        }
        private void DgvClientes()
        {
            dgv.Rows.Clear();
            DataSet ds = new DataSet();
            ds = datcli.MostrarClientes("Todos");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dgv.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
                }
            }
        }
        #endregion
        #region Botones
        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarCliente();
            LimpiarTxt();
            DgvClientes();
        }

        private void btnModif_Click(object sender, EventArgs e)
        {
            DialogResult avisomodif = MessageBox.Show("¿Quiere modificar el registro seleccionado?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (avisomodif == DialogResult.Yes)
            {
                InitVariables();
                cliente.Cuil = cuil;
                cliente.Nombre = nom;
                cliente.Direccion = dir;
                cliente.Telefono = tel;
                cliente.Email = email;
                accion = "Modificar";
                datcli.ABMClientes(accion, cliente);
                LimpiarTxt();
            }
            DgvClientes();
        }

        private void btnElim_Click(object sender, EventArgs e)
        {
            DialogResult avisoelimina = MessageBox.Show("¿Quiere eliminar el registro seleccionado?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (avisoelimina == DialogResult.Yes)
            {
                string accion = "Eliminar";
                cliente.Id = Convert.ToInt32(dgv.CurrentRow.Cells[0].Value.ToString());
                datcli.ABMClientes(accion, cliente);
            }
            DgvClientes();
        }

        private void txtCuil_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                foreach (DataGridViewRow dr in dgv.Rows)
                {
                    if (txtCuil.Text == dr.Cells[1].Value.ToString())
                    {
                        txtNom.Text = dr.Cells[2].Value.ToString();
                        txtDir.Text = dr.Cells[3].Value.ToString();
                        txtTel.Text = dr.Cells[4].Value.ToString();
                        txtmail.Text = dr.Cells[5].Value.ToString();
                        break;
                    }
                }
            }
        }
        #endregion
    }
}
