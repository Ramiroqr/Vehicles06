using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicles06.API.Data.Entities
{
    public class Detail
    {
        public int Id { get; set; }

        [Display(Name = "Historia")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public History History { get; set; }

        [Display(Name = "Procedimiento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Procedure Procedure { get; set; }

        [Display(Name = "Precio mano de obra")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal LaborPrice { get; set; }

        [Display(Name = "Precio de repuestos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal SparePartsPrice { get; set; }

        [Display(Name = "Total")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal TotalPrice => LaborPrice + SparePartsPrice;

        [Display(Name = "Observaciones")]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }
    }
}
