using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackEndWithLogin.CF.Models
{
    public class Municipio
    {
        [Key]
        public int IDMunicipio { get; set; }      
        public string Nombre { get; set; }
        public int IDProvincia { get; set; }
    }
}