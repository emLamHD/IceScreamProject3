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
        public async Task<IActionResult> UploadProductImages(int id, IEnumerable<IFormFile> imageFiles)
        {
            if (imageFiles == null || !imageFiles.Any())
            {
                return BadRequest("Không có ảnh nào được chọn.");
            }

            // Kiểm tra định dạng file
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var uploadedImages = new List<string>();

            foreach (var imageFile in imageFiles)
            {
                if (imageFile.Length == 0)
                {
                    return BadRequest("Một hoặc nhiều file không hợp lệ.");
                }

                var fileExtension = Path.GetExtension(imageFile.FileName).ToLower();
                if (!allowedExtensions.Contains(fileExtension))
                {
                    return BadRequest("Chỉ chấp nhận các file định dạng JPG, JPEG, PNG hoặc GIF.");
                }

                // Tạo tên file duy nhất
                var uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/products");

                // Tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                var filePath = Path.Combine(uploadPath, uniqueFileName);

                // Lưu ảnh vào thư mục trên server
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }

                // Lưu URL của ảnh vào danh sách
                uploadedImages.Add($"/uploads/products/{uniqueFileName}");
            }

            try
            {
                // Gọi service để cập nhật ảnh cho sản phẩm
                await _productService.UpdateProductImagesAsync(id, uploadedImages);
                return Ok(new { message = "Ảnh sản phẩm đã được cập nhật thành công.", uploadedImages });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
