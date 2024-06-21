using WebAppGeek.Abstraction;
using WebAppGeek.Data;
using WebAppGeek.Dto;
using WebAppGeek.Mapper;
using WebAppGeek.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace WebAppGeek.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly StorageContext _storageContext;
        private readonly IMapper _mapper;

        public ProductRepository(StorageContext storageContext, IMapper mapper)
        {
            _storageContext = storageContext;
            _mapper = mapper;
        }

        public int AddProduct(ProductDto productDto)
        {
            if (_storageContext.Products.Any(p => p.Name == productDto.Name))
            {
                throw new InvalidOperationException("Product with the same name already exists.");
            }

            var product = _mapper.Map<Product>(productDto);
            _storageContext.Products.Add(product);
            _storageContext.SaveChanges();
            return product.Id;
        }

        public void DeleteProduct(int id)
        {
            var product = _storageContext.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _storageContext.Products.Remove(product);
                _storageContext.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Product with the specified ID not found.");
            }
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            var products = _storageContext.Products.ToList();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }
    }
}
