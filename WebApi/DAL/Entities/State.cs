using System.ComponentModel.DataAnnotations;

namespace WebApi.DAL.Entities
{
    public class State : AuditBase
    {
        [Display(Name = "Estado/Departamento")] //Para identificar el nombre mas fácil
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")] // Longitud máxima
        [Required(ErrorMessage = "El campo {0} es obligatorio.")] //Campo obligatorio
        public string Name { get; set; }

        //Asi es como relaciono 2 tablas con EF Core:
        [Display(Name = "País")]
        public Country? Country { get; set; }

        //FK
        [Display(Name = "Id País")]
        public Guid CountryId { get; set; }
    }
}
