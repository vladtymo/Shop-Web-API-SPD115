﻿using BusinessLogic.ApiModels;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Shop_api_spd115.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService service;

        public ProductsController(IProductsService service)
        {
            this.service = service;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[HttpGet]                     // GET ~/api/products
        [HttpGet("all")]                // GET ~/api/products/all
        //[HttpGet("/all-products")]    // GET ~/all-products
        public IActionResult Get()
        {
            return Ok(service.Get()); // status: 200
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(service.Get(id));
        }

        [HttpPost]
        public IActionResult Create(CreateProductModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            service.Create(model);
            return Ok();
        }

        [HttpPut]
        public IActionResult Edit(EditProductModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            service.Edit(model);
            return Ok();
        }

        [Authorize]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            service.Delete(id);
            return Ok();
        }
    }
}
