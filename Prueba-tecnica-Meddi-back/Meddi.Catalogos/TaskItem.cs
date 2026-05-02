using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Prueba_tecnica_Meddi_back.Meddi.Catalogos
{
    
    public class TaskItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null;
        [BsonElement("titulo")]
        public string Titulo { get; set; }=null;
        [BsonElement("descripcion")]
        public string Descripcion { get; set; } = string.Empty;
        [BsonElement("prioridad")]
        public string Prioridad { get; set; } = "Media";
        [BsonElement("estado")]
        public string Estado { get; set; }= "Pendiente";
        [BsonElement("fechaVencimiento")]
        public DateTime FechaVencimiento { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
