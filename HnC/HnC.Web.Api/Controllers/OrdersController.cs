using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HnC.Repository.Interfaces;
using HnC.Web.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        // GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        [HttpGet]
        [ProducesResponseType(typeof(List<BasketItemGetResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetItems([FromBody]int userId)
        {
            try
            {
                if (userId < 1)
                    return new StatusCodeResult(StatusCodes.Status400BadRequest);

                var basketItems = await
                    _repoService.GetItemsInBasketAsync(userId);

                if (basketItems != null)
                    return Ok(basketItems);
            }
            catch (Exception e)
            {
                //TODO: log
            }

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        [HttpPost]
        [ProducesResponseType(typeof(BasketItemPostResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddItem([FromBody]BasketItemPostRequest item)
        {
            try
            {
                if (item.UserId < 1
                    && item.ItemId < 1
                    && item.Quantity < 1)
                    return new StatusCodeResult(StatusCodes.Status400BadRequest);
                
                var basketId = await
                    _repoService.AddItemToBasketAsync(item.UserId, item.ItemId, item.Quantity);

                if (basketId > 0)
                    return Ok(new BasketItemPostResponse
                    {
                        BasketId = basketId,
                        UserId = item.UserId,
                        ItemId = item.ItemId,
                        Quantity = item.Quantity
                    });
            }
            catch (Exception e)
            {
                //TODO: log
            }

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
