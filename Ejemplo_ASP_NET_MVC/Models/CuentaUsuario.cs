using System.ComponentModel.DataAnnotations;

namespace Ejemplo_ASP_NET_MVC.Models
{
    public class CuentaUsuario
    {
        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string usuario { get; set; }
        //Continuar
    }
}
