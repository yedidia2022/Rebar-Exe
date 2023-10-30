using RebarProject.Models;
using MongoDB.Driver;

namespace RebarProject.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMongoCollection<Shake> _shakes;

        public ShakeService(IShakeStoreDataBaseSettings settings,IMongoClient mongoClinet)
        {
           var database= mongoClinet.GetDatabase(settings.DatabaseName);
            _shakes = database.GetCollection<Shake>(settings.ShakeCollectionName);
        }
        public Shake Create(Shake shake)
        {
           _shakes.InsertOne(shake);
            return shake;
        }

        public List<Shake> Get()
        {
          return _shakes.Find(shake=>true).ToList() ;
        }

        public Shake Get(Guid id)
        {
            return _shakes.Find(shake =>shake.Id==id).FirstOrDefault();

        }

        public void Remove(string id)
        {
            _shakes.DeleteOne(shake => shake.Id == id);
        }
    

        public void Update(string id, Shake shake)
        {
            _shakes.ReplaceOne(shake => shake.Id == id,shake);

        }
    }
}
