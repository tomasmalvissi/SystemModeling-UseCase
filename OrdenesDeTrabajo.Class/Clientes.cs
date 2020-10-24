using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesDeTrabajo.Class
{
    public class Clientes
    {
        #region Atributos
        private int id;
        private int cuil;
        private string nombre;
        private string direccion;
        private string telefono;
        private string email;
        #endregion

        #region Propiedades
        public int Id
        {
            get{ return id; }
            //set{ id = value; }
        }
        public int Cuil
        {
            get { return cuil; }
            set { cuil = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        #endregion

        #region Constructor
        public Clientes()
        {
        }
        public Clientes(/*int id,*/ int cuil, string nom, string dir, string tel, string email)
        {
            //Metodo = variable por parametro;
            //Id = id;
            Cuil = cuil;
            Nombre = nom;
            Direccion = dir;
            Telefono = tel;
            Email = email;
        }
        #endregion
    }
}
