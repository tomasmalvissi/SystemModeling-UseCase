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
        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarCliente();
            LimpiarTxt();
        }

        private void btnModif_Click(object sender, EventArgs e)
        {

        }

        private void btnElim_Click(object sender, EventArgs e)
        {

        }
    }
}
