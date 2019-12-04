using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackEndWithLogin.CF.Models
{
    public class Provincia
    {
        [Key]
        public int IDProvincia { get; set; }
        public string Nombre { get; set; }
    }
}