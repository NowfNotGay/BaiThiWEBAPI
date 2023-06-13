namespace BaiThiWEBAPI.Service.Interface;

public interface IOrderService
{
    public int CountOrderByCustomerId(int customerId);
    public dynamic GetOrderByCustomerId(int customerId);

    public dynamic GetOrderByStatus(bool status);

    public dynamic GetOrderByPayments(string payment);
    public dynamic GetOrderByDateCreation(DateTime from, DateTime to);
}
