using demoDataFirst.Models;
using demoDataFirst.Services;
using Microsoft.AspNetCore.Mvc;

namespace demoDataFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            try
            {
                await _productService.CreateProductAsync(product);
                return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.ProductId) return BadRequest("Product ID không khớp.");

            await _productService.UpdateProductAsync(product);
            return Ok("Cập nhật thành công.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok("Xóa thành công.");
        }

        [HttpPost("{productId}/upload-images")]
        public async Task<IActionResult> UploadProductImages(int productId, IFormFileCollection? images)
        {
            if (images == null || images.Count == 0)
            {
                return BadRequest("Không có file nào được tải lên.");
            }

            // Kiểm tra định dạng file
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var imageUrls = new List<string>();  // Danh sách đường dẫn ảnh đã tải lên

            foreach (var imageFile in images)
            {
                var fileExtension = Path.GetExtension(imageFile.FileName).ToLower();
                if (!allowedExtensions.Contains(fileExtension))
                {
                    return BadRequest("Chỉ chấp nhận các file định dạng JPG, JPEG, PNG hoặc GIF.");
                }

                // Tạo đường dẫn lưu file
                var uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/products", productId.ToString());

                // Tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                var filePath = Path.Combine(uploadPath, uniqueFileName);

                // Lưu file vào server
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }

                // Lưu đường dẫn file vào danh sách
                var imageUrl = $"/uploads/products/{productId}/{uniqueFileName}";
                imageUrls.Add(imageUrl);
            }

            // Cập nhật thông tin hình ảnh cho sản phẩm (có thể lưu danh sách URL dưới dạng JSON hoặc chuỗi phân cách)
            var imageUrlsString = string.Join(",", imageUrls);

            try
            {
                // Gọi service để cập nhật ảnh cho sản phẩm
                await _productService.UpdateProductImagesAsync(productId, imageUrlsString);
                return Ok(new { message = "Ảnh đã được tải lên thành công.", imageUrls });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
