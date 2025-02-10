﻿using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.ViewModels.Products;
using ETicaretAPI.Domain.Entitites;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ETicaretAPI.Application.RequestParameters;
using ETicaretAPI.Application.Services;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFileService _fileService;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IWebHostEnvironment webHostEnvironment, IFileService fileService)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _webHostEnvironment = webHostEnvironment;
            _fileService = fileService;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]Pagination pagination)
        {
            
            var totalCount = _productReadRepository.GetAll(false).Count();
            var products =  _productReadRepository.GetAll(false).Skip(pagination.Page * pagination.Size).Take(pagination.Size).Select(p => new
            {
                p.Id,
                p.Name,
                p.Price,
                p.Stock,
                p.CreatedDate,
                p.UpdatedDate
            }).ToList();

            return Ok(new
            {
                totalCount,
                products
            });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id,false);
            //if (product == null)
            //    return NotFound();
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Product model)
        {
            
            await _productWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                Stock = model.Stock,
                Price = model.Price
                
            });
            await _productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }
        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Product model)
        {
            Product product = await _productReadRepository.GetByIdAsync(model.Id);
            //if (product == null)
            //    return NotFound();
            product.Name = model.Name;
            product.Price = model.Price;
            product.Stock = model.Stock;
            await _productWriteRepository.SaveAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
            return Ok();
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Upload()
        {
            await _fileService.UploadAsync("resource/product-images", Request.Form.Files);
            return Ok();
        }

    }
}
