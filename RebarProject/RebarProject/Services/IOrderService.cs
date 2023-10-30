using RebarProject.Models;

namespace RebarProject.Services
{
    public interface IOrderService
    {
        List<Shake> Get();
        Shake Get(string id);
        Shake Create(Shake shake);
        void Update(string id,Shake shake);
        void Remove(string id);
    }
}
