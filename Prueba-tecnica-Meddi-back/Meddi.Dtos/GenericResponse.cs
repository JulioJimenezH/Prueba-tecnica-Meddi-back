namespace Prueba_tecnica_Meddi_back.Meddi.Dtos
{
    public class GenericResponse : GenericResponse<object>
    {
    }
    public class GenericResponse<T>
    {        
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public GenericResponse()
        {
            Success = true;
            Message = string.Empty;
            Data = default(T);
        }        
    }
}
