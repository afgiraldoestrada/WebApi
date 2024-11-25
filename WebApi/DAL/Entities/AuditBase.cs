using System.ComponentModel.DataAnnotations;

namespace WebApi.DAL.Entities
{
    public class AuditBase
    {
        [Key] //PK
        [Required] //Significa que este campo es obligatorio

        //GUID altamente seguro, representa hexadecimales.
        public virtual Guid Id { get; set; } //Esta será el PK de todas las tablas
        public virtual DateTime? CreatedDate { get; set; } //Para guardar todo registro nuevo con su fecha
        public virtual DateTime? ModifiedDate { get; set; } //Para guardar todo registro que se modificó con su fecha

        //Poner ese signo de interrogacion al final del tipo de dato es para señalar que el dato no es obligatorio (nulleable)
    }
}
