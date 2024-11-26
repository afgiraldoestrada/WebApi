using System.ComponentModel.DataAnnotations;

namespace WebApi.DAL.Entities
{
    public class Country : AuditBase
    {
        [Display(Name = "País")] //Para identificar el nombre mas fácil
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")] // Longitud máxima
        [Required(ErrorMessage = "El campo {0} es obligatorio.")] //Campo obligatorio
        public string Name { get; set; }

        [Display(Name = "Estados/Departamentos")]
        public ICollection<State>? States { get; set; }
    }
}
