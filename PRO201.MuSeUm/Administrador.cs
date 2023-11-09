using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRO201.MuSeUm
{
    class Administrador : Empleado
    {
        //Constructor
        public Administrador(int id, String usuario, String nombre, String apellido, String password)
        {
            Id = id;
            Usuario = usuario;
            Nombre = nombre;
            Apellido = apellido;
            Password = password;
        }


    }
}
