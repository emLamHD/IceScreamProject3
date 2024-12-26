using demoDataFirst.Models;
using demoDataFirst.Repositories;
using System.Collections.Generic;

namespace demoDataFirst.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _productRepository;

        public ProductService(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetById(id);
        }

        public void AddProduct(Product product)
        {
            _productRepository.Add(product);
            _productRepository.Save();
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.Update(product);
            _productRepository.Save();
        }

        public void DeleteProduct(int id)
        {
            _productRepository.Delete(id);
            _productRepository.Save();
        }
    }

    
}
