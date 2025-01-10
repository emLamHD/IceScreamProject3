using demoDataFirst.Models;
using demoDataFirst.Repositories;
using Microsoft.EntityFrameworkCore;

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

        public async Task CreateProductAsync(Product product)
        {
            await _productRepository.AddAsync(product);
            await _productRepository.SaveAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public async Task<bool> UpdateProductImagesAsync(int productId, string imageUrls)
        {
            // Tìm sản phẩm theo ID
            var product = await _productRepository.GetByConditionAsync(p => p.ProductId == productId);
            if (product == null)
            {
                throw new Exception("Sản phẩm không tồn tại.");
            }

            // Cập nhật thông tin ảnh cho sản phẩm
            product.Image = imageUrls;

            // Lưu thay đổi vào cơ sở dữ liệu
            await _productRepository.UpdateAsync(product);
            return true;
        }
    }
}
