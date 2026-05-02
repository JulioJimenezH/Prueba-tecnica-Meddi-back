using System.ComponentModel.DataAnnotations;
namespace Prueba_tecnica_Meddi_back.Meddi.Dtos
{
    public class CreateTaskDto
    {
        [Required(ErrorMessage = "El título es obligatorio.")]
        [StringLength(50, ErrorMessage ="El titulo no debe de tener mas de 50 caracteres")]
        public string Titulo { get; set; } = null!;

        public string Descripcion { get; set; } =string.Empty;
        [Required(ErrorMessage = "La prioridad es obligatoria.")]
        public string Prioridad { get; set; } = "Media";
        public DateTime FechaVencimiento { get; set; }
    }
}
