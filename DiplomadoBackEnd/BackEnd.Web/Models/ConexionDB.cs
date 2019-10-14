using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Web.Models
{
    public static class ConexionDB
    {
        //private static string cnnString = 
            
        public static string MiConexionString()
        {
            return @"Data Source=SERVER; 
            Initial Catalog=BASE DE DATOS; User ID=USUARIO; 
            pwd=CLAVE; Persist Security Info=false;";
        }
    }
}