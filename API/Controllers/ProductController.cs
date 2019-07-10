using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service;
using Model;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {

            _productService = productService;

        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productService.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_productService.Get(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Product model)
        {

            return Ok(_productService.Add(model));

        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Product model)
        {

            return Ok(_productService.Add(model));

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_productService.Delete(id));

        }
    }
}
