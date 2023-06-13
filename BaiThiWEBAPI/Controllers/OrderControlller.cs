using BaiThiWEBAPI.Models;
using BaiThiWEBAPI.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaiThiWEBAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrderControlller : ControllerBase
{
    private IServiceCRUD<Order> _orderRepository;

    public OrderControlller(IServiceCRUD<Order> orderRepository)
    {
        _orderRepository = orderRepository;
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
}
