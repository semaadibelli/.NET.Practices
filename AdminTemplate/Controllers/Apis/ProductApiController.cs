using AdminTemplate.BusinessLogic.Repository.Abstracts;
using AdminTemplate.Dtos;
using AdminTemplate.Models.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdminTemplate.Controllers.Apis
{
    [ApiController]
    public class ProductApiController : BaseApiController
    {

        private readonly IMapper _mapper;
        private readonly IRepository<Product, Guid> _productRepo;

        public ProductApiController(IMapper mapper, IRepository<Product, Guid> productRepo)
        {

            _mapper = mapper;
            _productRepo = productRepo;
        }

        [HttpGet]
        public IActionResult All()
        {
            try
            {
                var data = _productRepo.Get()
                    .Include(x => x.Category)
                    .ToList()
                    .Select(x => _mapper.Map<ProductDto>(x));

                return Ok(data);

            }

            catch (Exception ex)
            {
                return BadRequest(new { Message = $"Bir hata oluştu: {ex.Message}" });
            }

            //var products = _context.Products.Include(x => x.Category)
            //    .ToList()
            //    .Select(x => _mapper.Map<ProductDto>(x))
            //    .ToList();

            //var data = _productRepo.Get().ToList().Select(x => _mapper.Map<ProductDto>(x));
            //return Ok(data);
        }

        [HttpGet]
        public IActionResult Detail(Guid id)
        {
            try
            {
                var data = _productRepo.GetById(id);
                if (data == null)
                {
                    return NotFound(new { Message = $"{id} numaralı kategori bulunamadı" });
                }
                var model = _mapper.Map<ProductDto>(data);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = $"Bir hata oluştu: {ex.Message}" });
            }
        }

        [HttpPost]
        public IActionResult Add(ProductDto model)
        {
            try
            {
                var data = _mapper.Map<Product>(model);
                data.CreatedUser = HttpContext.User.Identity!.Name;
                // _context.Products.Add(data);
                // _context.SaveChanges();
                _productRepo.Insert(data);
                return Ok(new
                {
                    Success = true,
                    Message = $"{data.Name} isimli ürün kaydedildi"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        [HttpPut]
        public IActionResult Update(Guid id, ProductDto model)
        {
            try
            {
                // var product = _context.Products.Find(id);
                var product = _productRepo.GetById(id);
                if (product == null)
                {
                    return NotFound(new { Success = false, Message = "Ürün bulunamadı" });
                }
                model.UpdatedUser = HttpContext.User.Identity!.Name;
                model.UpdatedDate = DateTime.UtcNow;
                product.Name = model.Name;
                product.UnitPrice = model.UnitPrice;
                product.CategoryId = model.CategoryId;
                // _context.SaveChanges();
                _productRepo.Update(product);
                return Ok(new
                {
                    Success = true,
                    Message = $"{model.Name} isimli ürün güncellendi"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                // var product = _context.Products.Find(id);

                var product = _productRepo.GetById(id);
                if (product == null)
                {
                    return NotFound(new { Success = false, Message = "Ürün bulunamadı" });
                }

                // _context.Products.Remove(product);
                // _context.SaveChanges();
                _productRepo.Delete(product);
                return Ok(new
                {
                    Success = true,
                    Message = $"{product.Name} isimli ürün silindi"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }
    }
}