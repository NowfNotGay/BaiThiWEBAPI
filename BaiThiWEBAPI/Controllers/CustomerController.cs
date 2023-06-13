using BaiThiWEBAPI.Models;
using BaiThiWEBAPI.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaiThiWEBAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly IServiceCRUD<Customer> _customerRepository;
    private readonly IOrderService _orderService;

    public CustomerController(IServiceCRUD<Customer> customerRepository, IOrderService orderService)
    {
        _customerRepository = customerRepository;
        _orderService = orderService;
    }

    [Consumes("application/json")]
    [Produces("application/json")]
    [HttpGet("Read")]
    public IActionResult Read()
    {
        try
        {
            return Ok(_customerRepository.Read());
        }
        catch
        {
            return BadRequest();
        }
    }

    [Consumes("application/json")]
    [Produces("application/json")]
    [HttpPost("AddCustomer")]
    public IActionResult AddCustomer([FromBody]Customer customer)
    {
        try
        {
            return Ok(_customerRepository.Create(customer));
        }
        catch
        {
            return BadRequest();
        }
    }

    [Consumes("application/json")]
    [Produces("application/json")]
    [HttpPut("UpdateCustomer")]
    public IActionResult UpdateCustomer([FromBody] Customer customer)
    {
        try
        {
            return Ok(_customerRepository.Update(customer));
        }
        catch
        {
            return BadRequest();
        }
    }

    [Consumes("application/json")]
    [Produces("application/json")]
    [HttpDelete("DeleteCustomer")]
    public IActionResult DeleteCustomer(int id)
    {
        try
        {
            if(_orderService.CountOrderByCustomerId(id) > 0)
            {
                return BadRequest();
            }
            return Ok(_customerRepository.Delete(id));
        }
        catch
        {
            return BadRequest();
        }
    }
}
