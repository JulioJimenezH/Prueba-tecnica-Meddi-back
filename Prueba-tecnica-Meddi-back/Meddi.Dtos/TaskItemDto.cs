namespace Prueba_tecnica_Meddi_back.Meddi.Dtos
{
    public class TaskItemDto
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Prioridad { get; set; }
        public string Estado { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
