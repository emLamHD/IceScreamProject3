using demoDataFirst.Models;
using demoDataFirst.Repositories;
using Microsoft.EntityFrameworkCore;

namespace demoDataFirst.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductImage> _productImageRepository;

        public ProductService(IGenericRepository<Product> productRepository, IGenericRepository<ProductImage> productImageRepository)
        {
            _productRepository = productRepository;
            _productImageRepository = productImageRepository;
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

        public async Task<bool> UpdateProductImagesAsync(int id, List<string> imageUrls)
        {
            // Lấy thông tin sản phẩm
            var product = await _productRepository.GetByConditionAsync(p => p.ProductId == id);
            if (product == null)
            {
                throw new Exception("Sản phẩm không tồn tại.");
            }

            // Kiểm tra và thêm ảnh mới nếu có
            if (imageUrls != null && imageUrls.Any())
            {
                // Xóa tất cả ảnh cũ (nếu cần)
                var existingImages = await _productImageRepository.Find(img => img.ProductId == id);

                // Kiểm tra xem có ảnh không
                if (existingImages != null && existingImages.Any())
                {
                    foreach (var image in existingImages)
                    {
                        await _productImageRepository.DeleteAsync(image.ImageId); // Đảm bảo xóa bất đồng bộ
                    }
                }


                // Thêm các ảnh mới
                foreach (var imageUrl in imageUrls)
                {
                    var newImage = new ProductImage
                    {
                        ProductId = id,
                        ImageUrl = imageUrl
                    };

                    await _productImageRepository.AddAsync(newImage);
                }

                // Lưu thay đổi
                await _productImageRepository.SaveAsync();
            }

            return true;
        }
    }
}
