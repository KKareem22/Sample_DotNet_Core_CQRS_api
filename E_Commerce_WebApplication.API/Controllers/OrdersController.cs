using E_Commerce_WebApplication.Application.Features.Orders.Commands.CreateOrder;
using E_Commerce_WebApplication.Application.Features.Orders.Queries.GetOrderSummaries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_WebApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Create Order


        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var orderId = await _mediator.Send(command);

            return Ok(new { Message = "Order created successfully", OrderId = orderId });
        }
        #endregion
        #region Get Order Summaries

        [HttpGet]
        public async Task<IActionResult> GetOrderSummaries()
        {
            var summaries = await _mediator.Send(new GetOrderSummariesQuery());

            return Ok(summaries);
        }
        #endregion

    }
}
