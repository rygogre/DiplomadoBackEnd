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
            return @"Data Source=RYGOGREGROUP\SQLEXPRESS; 
            Initial Catalog=DiplomadoCurneDB; User ID=rygogre; 
            pwd=d56; Persist Security Info=false;";
        }
    }
}