using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapperDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapperDemo.Controllers
{
[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{

    private readonly IMapper _mapper;

    public OrdersController(IMapper mapper)
    {
        _mapper = mapper;
    }

    public ActionResult<Order> Get()
    {
        var orderDTO = new OrderDTO()
        {
            Id = "1"
        };

        return Ok(_mapper.Map<Order>(orderDTO));
    }
}
}