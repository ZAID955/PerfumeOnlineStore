using PerfumeOnlineStore_Core.Dtos.Admin.Brand;
using PerfumeOnlineStore_Core.Dtos.Admin.Package;
using PerfumeOnlineStore_Core.Dtos.Admin.Product;
using PerfumeOnlineStore_Core.Dtos.Admin.ProductSection;
using PerfumeOnlineStore_Core.Dtos.Admin.ProductSize;
using PerfumeOnlineStore_Core.Dtos.Admin.ProductType;
using PerfumeOnlineStore_Core.Dtos.Admin.PromoCode;
using PerfumeOnlineStore_Core.Models.Entites;

namespace PerfumeOnlineStore_Core.IServices
{
    public interface IAdmanServiceInterface
    {

        #region ProductSize Management
        Task<List<ProductSizeRecordDTO>> GetAllProductSize();
        Task<ProductSize> GetProductSizeById(int id);
        Task<int> CreateProductSize(int Size);
        Task<int> UpdateProductSize(UpdateProductSizeDTO dto);
        Task<int> DeleteProductSize(int id);
        #endregion

        #region ProductSection Management
        Task<List<ProductSectionRecordDTO>> GetAllProductSection();
        Task<ProductSection> GetProductSectionById(int id);
        Task<int> CreateProductSection(string Name);
        Task<int> UpdateProductSection(UpdateProductSectionDTO dto);
        Task<int> DeleteProductSection(int id);
        #endregion

        #region ProductType Management
        Task<List<ProductTypeRecordDTO>> GetAllProductType();
        Task<ProductType> GetProductTypeById(int id);
        Task<int> CreateProductType(string Name);
        Task<int> UpdateProductType(UpdateProductTypeDTO dto);
        Task<int> DeleteProductType(int id);
        #endregion

        #region ProductBrand Management
        Task<List<ProductBrandRecordDTO>> GetAllProductBrand();
        Task<ProductBrand> GetProductBrandById(int id);
        Task<int> CreateProductBrand(string Name);
        Task<int> UpdateProductBrand(UpdateProductBrandDTO dto);
        Task<int> DeleteProductBrand(int id);
        #endregion

        #region PromoCode Management
        Task<List<PromoCodeRecordDTO>> GetAllPromoCode();
        Task<PromoCodeDetailsDTO> GetPromoCodeById(int id);
        Task<int> CreatePromoCode(CreatePromoCodeDTO dto);
        Task<int> UpdatePromoCode(UpdatePromoCodeDTO dto);
        Task<int> DeletePromoCode(int id);
        #endregion

        #region Package Management
        Task<List<PackageRecordDTO>> GetAllPackage();
        Task<PackageDetailsDTO> GePackageById(int Id);
        Task<List<PackageRecordDTO>> SearchOnPackage(string? Name, int Price, string? Category);
        Task CreatePackage(CreateOrUpdatePackageDTO dto);
        Task UpdatePackage(CreateOrUpdatePackageDTO dto);
        Task DeletePackage(int Id);
        #endregion

        #region Product Management
        Task<List<ProductRecordDTO>> GetAllProduct();
        Task<ProductDetailsDTO> GeProductById(int Id);
        Task CreateProduct(CreateOrUpdateProductDTO dto);
        Task UpdateProduct(CreateOrUpdateProductDTO dto);
        Task<List<ProductRecordDTO>> SearchOnProduct(string? Name, string? Brand, int Price, int Size);
        Task DeleteProduct(int Id);
        #endregion
    }
}
