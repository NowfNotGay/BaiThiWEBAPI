using BaiThiWEBAPI.Models;
using BaiThiWEBAPI.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaiThiWEBAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrderControlller : ControllerBase
{
    private readonly IServiceCRUD<Order> _orderRepository;
    private readonly IOrderService _orderService;

    public OrderControlller(IServiceCRUD<Order> orderRepository, IOrderService orderService)
    {
        _orderRepository = orderRepository;
        _orderService = orderService;
    }

    [Consumes("application/json")]
    [Produces("application/json")]
    [HttpGet("Read")]
    public IActionResult Read()
    {
        try
        {
            return Ok(_orderRepository.Read());
        }
        catch
        {
            return BadRequest();
        }
    }

    [Consumes("application/json")]
    [Produces("application/json")]
    [HttpPost("AddOrder")]
    public IActionResult AddOrder([FromBody] Order order)
    {
        try
        {
            return Ok(_orderRepository.Create(order));
        }
        catch
        {
            return BadRequest();
        }
    }

    [Consumes("application/json")]
    [Produces("application/json")]
    [HttpDelete("DeleteOrder")]
    public IActionResult DeleteOrder(int id)
    {
        try
        {
            return Ok(_orderRepository.Delete(id));
        }
        catch
        {
            return BadRequest();
        }
    }


    [Consumes("application/json")]
    [Produces("application/json")]
    [HttpGet("CountOrderByCustomerId")]
    public IActionResult CountOrderByCustomerId(int id)
    {
        try
        {
            return Ok(_orderService.CountOrderByCustomerId(id));
        }
        catch
        {
            return BadRequest();
        }
    }


    [Consumes("application/json")]
    [Produces("application/json")]
    [HttpGet("GetOrderByCustomerId")]
    public IActionResult GetOrderByCustomerId(int id)
    {
        try
        {
            return Ok(_orderService.GetOrderByCustomerId(id));
        }
        catch
        {
            return BadRequest();
        }
    }

    [Consumes("application/json")]
    [Produces("application/json")]
    [HttpGet("GetOrderByStatus")]
    public IActionResult GetOrderByStatus(bool status)
    {
        try
        {
            return Ok(_orderService.GetOrderByStatus(status));
        }
        catch
        {
            return BadRequest();
        }
    }

    [Consumes("application/json")]
    [Produces("application/json")]
    [HttpGet("GetOrderByPayments")]
    public IActionResult GetOrderByPayments(string payment)
    {
        try
        {
            return Ok(_orderService.GetOrderByPayments(payment));
        }
        catch
        {
            return BadRequest();
        }
    }

    [Consumes("application/json")]
    [Produces("application/json")]
    [HttpGet("GetOrderByDateCreation")]
    public IActionResult GetOrderByDateCreation(DateTime from, DateTime to)
    {
        try
        {
            return Ok(_orderService.GetOrderByDateCreation(from,to));
        }
        catch
        {
            return BadRequest();
        }
    }
}
