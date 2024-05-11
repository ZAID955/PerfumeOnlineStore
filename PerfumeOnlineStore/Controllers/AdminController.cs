using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PerfumeOnlineStore_Core.Dtos;
using PerfumeOnlineStore_Core.Dtos.Admin.Brand;
using PerfumeOnlineStore_Core.Dtos.Admin.Package;
using PerfumeOnlineStore_Core.Dtos.Admin.Product;
using PerfumeOnlineStore_Core.Dtos.Admin.ProductSection;
using PerfumeOnlineStore_Core.Dtos.Admin.ProductSize;
using PerfumeOnlineStore_Core.Dtos.Admin.ProductType;
using PerfumeOnlineStore_Core.Dtos.Admin.PromoCode;
using PerfumeOnlineStore_Core.IServices;
using PerfumeOnlineStore_Core.Models.Entites;
using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;

namespace PerfumeOnlineStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdmanServiceInterface _admanService;
        public AdminController(IAdmanServiceInterface admanService)
        {
            _admanService = admanService;
        }
        #region ProductSize Management
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllProductSize()
        {
            try
            {
                var productSizes = await _admanService.GetAllProductSize();
                return Ok(productSizes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetProductSizeById(int id)
        {
            try
            {
                var productSize = await _admanService.GetProductSizeById(id);
                if (productSize == null)
                {
                    return NotFound();
                }
                return Ok(productSize);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateProductSize(int Size)
        {
            try
            {
                var createdProductSectionId = await _admanService.CreateProductSize(Size);
                return CreatedAtAction(nameof(GetProductSizeById), new { id = createdProductSectionId }, Size);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateProductSize(UpdateProductSizeDTO dto)
        {
            try
            {
                await _admanService.UpdateProductSize(dto);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteProductSize(int id)
        {
            try
            {
                await _admanService.DeleteProductSize(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region ProductSection Management
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllProductSection()
        {
            try
            {
                var ProductSections = await _admanService.GetAllProductSection();
                return Ok(ProductSections);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetProductSectionById(int id)
        {
            try
            {
                var ProductSection = await _admanService.GetProductSectionById(id);
                if (ProductSection == null)
                {
                    return NotFound();
                }
                return Ok(ProductSection);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateProductSection(string Name)
        {
            try
            {
                var createdProductSectionId = await _admanService.CreateProductSection(Name);
                return CreatedAtAction(nameof(GetProductSectionById), new { id = createdProductSectionId }, Name);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateProductSection(UpdateProductSectionDTO dto)
        {
            try
            {
                await _admanService.UpdateProductSection(dto);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteProductSection(int id)
        {
            try
            {
                await _admanService.DeleteProductSection(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region ProductType Management
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllProductType()
        {
            try
            {
                var ProductTypes = await _admanService.GetAllProductType();
                return Ok(ProductTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetProductTypeById(int id)
        {
            try
            {
                var ProductType = await _admanService.GetProductTypeById(id);
                if (ProductType == null)
                {
                    return NotFound();
                }
                return Ok(ProductType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateProductType(string Name)
        {
            try
            {
                var createdProductTypeId = await _admanService.CreateProductType(Name);
                return CreatedAtAction(nameof(GetProductTypeById), new { id = createdProductTypeId }, Name);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateProductType(UpdateProductTypeDTO dto)
        {
            try
            {
                await _admanService.UpdateProductType(dto);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteProductType(int id)
        {
            try
            {
                await _admanService.DeleteProductType(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region ProductBrand Management
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllProductBrand()
        {
            try
            {
                var ProductBrands = await _admanService.GetAllProductBrand();
                return Ok(ProductBrands);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetProductBrandById(int id)
        {
            try
            {
                var ProductBrand = await _admanService.GetProductBrandById(id);
                if (ProductBrand == null)
                {
                    return NotFound();
                }
                return Ok(ProductBrand);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateProductBrand(CreatePromoCodeDTO dto)
        {
            try
            {
                var createdProductBrandId = await _admanService.CreateProductBrand(dto.Name);
                return CreatedAtAction(nameof(GetProductBrandById), new { id = createdProductBrandId }, dto.Name);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateProductBrand(UpdateProductBrandDTO dto)
        {
            try
            {
                await _admanService.UpdateProductBrand(dto);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteProductBrand(int id)
        {
            try
            {
                await _admanService.DeleteProductBrand(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region PromoCode Management
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllPromoCode()
        {
            try
            {
                var promoCodes = await _admanService.GetAllPromoCode();
                return Ok(promoCodes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetPromoCodeById(int id)
        {
            try
            {
                var promoCode = await _admanService.GetPromoCodeById(id);
                if (promoCode == null)
                {
                    return NotFound();
                }
                return Ok(promoCode);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreatePromoCode(CreatePromoCodeDTO dto)
        {
            try
            {
                var createdPromoCodeId = await _admanService.CreatePromoCode(dto);
                return CreatedAtAction(nameof(GetPromoCodeById), new { id = createdPromoCodeId }, dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdatePromoCode(UpdatePromoCodeDTO dto)
        {
            try
            {
                await _admanService.UpdatePromoCode(dto);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeletePromoCode(int id)
        {
            try
            {
                await _admanService.DeletePromoCode(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion

        #region Package Management
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllPackage()
        {
            try
            {
                var result = await _admanService.GetAllPackage();
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GePackageById(int id)
        {
            try
            {
                var result = await _admanService.GePackageById(id);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> SearchOnPackage(string? Name, int Price, string? Category)
        {
            try
            {
                var result = await _admanService.SearchOnPackage(Name, Price, Category);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreatePackage(CreateOrUpdatePackageDTO dto)
        {
            try
            {
                await _admanService.CreatePackage(dto);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdatePackage(CreateOrUpdatePackageDTO dto)
        {
            try
            {
                await _admanService.UpdatePackage(dto);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeletePackage(int id)
        {
            try
            {
                await _admanService.DeletePackage(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        #endregion

        #region Product Management
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllProduct()
        {
            try
            {
                var result = await _admanService.GetAllProduct();
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GeProductById(int id)
        {
            try
            {
                var result = await _admanService.GeProductById(id);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> SearchOnProduct(string? Name, string? Brand, int Price, int Size)
        {
            try
            {
                var result = await _admanService.SearchOnProduct(Name, Brand, Price, Size);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateProduct(CreateOrUpdateProductDTO dto)
        {
            try
            {
                await _admanService.CreateProduct(dto);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateProduct(CreateOrUpdateProductDTO dto)
        {
            try
            {
                await _admanService.UpdateProduct(dto);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _admanService.DeleteProduct(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        #endregion
    }
}