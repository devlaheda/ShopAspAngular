using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using Core.Specifictaion;
using AutoMapper;
using API.DTOs;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _brandRepository;
        private readonly IGenericRepository<ProductType> _typesRepository;
        private readonly IMapper _mapper;

        public ProductsController( IGenericRepository<Product> productRepository,
        IGenericRepository<ProductBrand> BrandRepository ,IGenericRepository<ProductType> typesRepository , IMapper mapper)
        {
            _productRepository = productRepository;
            _brandRepository = BrandRepository;
            _typesRepository = typesRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetProducts()
        {
            var spec = new  ProductWithTypesAndBrandsSpecification();
            var products = await  _productRepository.GetAllWithSpecsAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductDto>>(products));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var spec = new  ProductWithTypesAndBrandsSpecification(id);
               var product =  await _productRepository.GetByIdWithSpecsAsync(spec);
               if (product is null)
               {
                   return NotFound();
               }
               return Ok(_mapper.Map<Product,ProductDto>(product));
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
               var brands =  await _brandRepository.GetAllAsync();
               if (brands is null)
               {
                   return NotFound();
               }
               return Ok(brands);
        }
         [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductTypes()
        {
               var types =  await _typesRepository.GetAllAsync();
               if (types is null)
               {
                   return NotFound();
               }
               return Ok(types);
        }
    }
}