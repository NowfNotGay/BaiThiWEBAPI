using BaiThiWEBAPI.Models;
using BaiThiWEBAPI.Service.Interface;

namespace BaiThiWEBAPI.Service.ClassImplement;

public class ServiceCustomerCRUD: IServiceCRUD<Customer>
{
    private readonly DatabaseContext _databaseContext;

    public ServiceCustomerCRUD(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public bool Create(Customer entity)
    {
        try
        {
            _databaseContext.Customers.Add(entity);
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
            _databaseContext.Customers.Remove(_databaseContext.Customers.FirstOrDefault(c=>c.Id == id)!);
            return _databaseContext.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public dynamic Get(int id) => _databaseContext.Customers.Where(c=>c.Id == id).Select(c => new
    {
        c.Id,
        c.Name,
        c.Address,
        c.Birthday,
        c.Phone
    });

    public dynamic Read() => _databaseContext.Customers.Select(c => new
    {
        c.Id,
        c.Name,
        c.Address,
        c.Birthday,
        c.Phone
    });

    public bool Update(Customer entity)
    {
        try
        {
            _databaseContext.Customers.Update(entity);
            return _databaseContext.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
