using HnC.Repository.Interfaces;
using HnC.Repository.Models;
using HnC.Web.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HnC.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IService _repoService;

        public OrdersController(IService repoService)
        {
            _repoService = repoService;
        }

        [HttpGet("ping")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Ping()
        {
            return Ok("Pong");
        }

        [HttpGet("{userId}")]
        [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetOrder(int userId)
        {
            try
            {
                if (userId < 1)
                    return new StatusCodeResult(StatusCodes.Status400BadRequest);

                var order = await
                    _repoService.GetOrderAsync(userId);

                if (order == null)
                    return new StatusCodeResult(StatusCodes.Status404NotFound);

                return Ok(order);
            }
            catch (NullReferenceException e)
            {
                //TODO: log
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            }
            catch (Exception e)
            {
                //TODO: log
            }

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrder([FromBody]AddOrderRequest item)
        {
            try
            {
                if (item.UserId < 1)
                    return new StatusCodeResult(StatusCodes.Status400BadRequest);

                //Check if it already exists
                var order = await
                    _repoService.GetOrderAsync(item.UserId);

                if(order != null)
                    return new StatusCodeResult(StatusCodes.Status400BadRequest);

                var orderId = await
                    _repoService.AddOrderAsync(item.UserId);

                if (orderId > 0)
                    return new StatusCodeResult(StatusCodes.Status201Created);
            }
            catch (NullReferenceException e)
            {
                //TODO: log
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            }
            catch (Exception e)
            {
                //TODO: log
            }

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("{userId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RemoveOrder(int userId)
        {
            try
            {
                if (userId < 1)
                    return new StatusCodeResult(StatusCodes.Status400BadRequest);

                //Check if it already exists
                var order = await
                    _repoService.GetOrderAsync(userId);

                if (order == null)
                    return new StatusCodeResult(StatusCodes.Status404NotFound);

                var orderId = await
                    _repoService.RemoveOrderAsync(userId);

                if (orderId > 0)
                    return new StatusCodeResult(StatusCodes.Status204NoContent);
            }
            catch (NullReferenceException e)
            {
                //TODO: log
                return new StatusCodeResult(StatusCodes.Status404NotFound);
            }
            catch (Exception e)
            {
                //TODO: log
            }

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

    }
}