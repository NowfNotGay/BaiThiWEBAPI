using BaiThiWEBAPI.Models;
using BaiThiWEBAPI.Service.Interface;

namespace BaiThiWEBAPI.Service.ClassImplement
{
    public class ServiceOrderCRUD : IServiceCRUD<Order>
    {
        private readonly DatabaseContext _databaseContext;

        public ServiceOrderCRUD(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public bool Create(Order entity)
        {
            try
            {
                _databaseContext.Orders.Add(entity);
                return _databaseContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                _databaseContext.Orders.Remove(_databaseContext.Orders.FirstOrDefault(o => o.Id == id)!);
                return _databaseContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public dynamic Get(int id) => _databaseContext.Orders.Where(o => o.Id == id).Select(o => new
        {
            o.Id,
            o.Name,
            o.Datecreation,
            o.Status,
            o.Payments,
            o.CustomerId
        });

        public dynamic Read() => _databaseContext.Orders.Select(o => new
        {
            o.Id,
            o.Name,
            o.Datecreation,
            o.Status,
            o.Payments,
            o.CustomerId
        });

        public bool Update(Order entity)
        {
            try
            {
                _databaseContext.Orders.Update(entity);
                return _databaseContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
