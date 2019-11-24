using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackEnd.CF.Models
{
   [Table("Productos")] //No tendra la tabla e la base de datos.
    public class Producto : IValidatableObject //Implementados esta interfaz para tener un conjunto de validaciones personalizadas.
    {        
        public int ProductoID { get; set; }
        [Required]  //Campo requerido....
        [StringLength(30)] //Cantidad de carateres permitidos.
        [Remote("ValidaDescripcion", "Productos", ErrorMessage = "Debe tener menos palabras.")] //Valida personalizada,solo funciona que el navegador permite script.
        public string Descripcion { get; set; }
     [Required]
        public decimal Precio { get; set; }
        [Required]
        [DataType(DataType.Date)] //Definimos el tipo de dato.
        [Display(Name = "Fecha Venc.")]
        public DateTime FechaVencimiento { get; set; }
     [Required]
     [DataType(DataType.Currency)]
     //[Compare("Precio", ErrorMessage = "No coincide.")] //Compara dos propiedad tenga el mismo valor... Ejemplo> Email, claves, etc.
        public decimal Costo { get; set; }
      [Required]
        public bool Estatus { get; set; }
        [Required]
        public int Disponible { get; set; }

        public int CategoriaID { get; set; }

        [ForeignKey("CategoriaID")] //Llave foranea.
        public virtual Categoria Categoria { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var misErrores = new List<ValidationResult>(); //Lista de errores vamos a retornar.

            if (Precio < Costo) //Validacion deseamos
            {
                misErrores.Add(new ValidationResult("El precio debe ser mayor",
                    new string[] { "Precio", "Costo" })); //Agregar el mensaje de error y la propiedades afectadas.
            }

            return misErrores; //Si la lista de error se retonar en blanco, todo estuvo BIEN.
            
        }
    }
}