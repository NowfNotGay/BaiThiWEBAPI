using BaiThiWEBAPI.Models;
using BaiThiWEBAPI.Service.Interface;

namespace BaiThiWEBAPI.Service.ClassImplement;

public class OrderService : IOrderService
{
    private readonly DatabaseContext _databaseContext;

    public OrderService(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public int CountOrderByCustomerId(int customerId) => _databaseContext.Orders.Count(o=>o.CustomerId == customerId );

    public dynamic GetOrderByCustomerId(int customerId) => _databaseContext.Orders.Where(o => o.CustomerId == customerId).Select(o => new
    {
        o.Id,
        o.Name,
        o.Datecreation,
        o.Status,
        o.Payments,
        o.CustomerId
    });

    public dynamic GetOrderByDateCreation(DateTime from, DateTime to) => _databaseContext.Orders.Where(o => o.Datecreation >= from &&o.Datecreation<= to).Select(o => new
    {
        o.Id,
        o.Name,
        o.Datecreation,
        o.Status,
        o.Payments,
        o.CustomerId
    });

    public dynamic GetOrderByPayments(string payment) => _databaseContext.Orders.Where(o => o.Payments.ToLower() == payment.ToLower()).Select(o => new
    {
        o.Id,
        o.Name,
        o.Datecreation,
        o.Status,
        o.Payments,
        o.CustomerId
    });

    public dynamic GetOrderByStatus(bool status) => _databaseContext.Orders.Where(o => o.Status == status).Select(o => new
    {
        o.Id,
        o.Name,
        o.Datecreation,
        o.Status,
        o.Payments,
        o.CustomerId
    });
}
