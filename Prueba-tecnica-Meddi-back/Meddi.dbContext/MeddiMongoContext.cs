using MongoDB.Driver;
using Prueba_tecnica_Meddi_back.Meddi.Catalogos;
namespace Prueba_tecnica_Meddi_back.Meddi.dbContext
{
    // <summary>
    // Contexto de MongoDB para la aplicación Meddi
       
    public class MeddiMongoContext
    {
        private readonly IMongoDatabase _database;
        public MeddiMongoContext(MongoSettings settings)
        {
            var client = new MongoClient(settings.MongoDB);
            _database = client.GetDatabase(settings.DatabaseName);
        }
        /// Colección de TaskItems en MongoDB
        public IMongoCollection<TaskItem> TaskItems => _database.GetCollection<TaskItem>("TaskItems");
    }
}
