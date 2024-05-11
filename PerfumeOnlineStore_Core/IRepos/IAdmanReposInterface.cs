
using PerfumeOnlineStore_Core.Dtos.Admin.Brand;
using PerfumeOnlineStore_Core.Dtos.Admin.Package;
using PerfumeOnlineStore_Core.Dtos.Admin.Product;
using PerfumeOnlineStore_Core.Dtos.Admin.ProductSection;
using PerfumeOnlineStore_Core.Dtos.Admin.ProductSize;
using PerfumeOnlineStore_Core.Dtos.Admin.ProductType;
using PerfumeOnlineStore_Core.Dtos.Admin.PromoCode;
using PerfumeOnlineStore_Core.Models.Entites;

namespace PerfumeOnlineStore_Core.IRepos
{
    public interface IAdmanReposInterface
    {

        #region ProductSize Management
        Task<List<ProductSizeRecordDTO>> GetAllProductSize();
        Task<ProductSize> GetProductSizeById(int id);
        Task<int> CreateProductSize(ProductSize productSize);
        Task<int> UpdateProductSize(ProductSize productSize);
        Task<int> DeleteProductSize(int id);
        #endregion

        #region ProductSection Management
        Task<List<ProductSectionRecordDTO>> GetAllProductSection();
        Task<ProductSection> GetProductSectionById(int id);
        Task<int> CreateProductSection(ProductSection ProductSection);
        Task<int> UpdateProductSection(ProductSection ProductSection);
        Task<int> DeleteProductSection(int id);
        #endregion

        #region ProductType Management
        Task<List<ProductTypeRecordDTO>> GetAllProductType();
        Task<ProductType> GetProductTypeById(int id);
        Task<int> CreateProductType(ProductType ProductType);
        Task<int> UpdateProductType(ProductType ProductType);
        Task<int> DeleteProductType(int id);
        #endregion

        #region ProductBrand Management
        Task<List<ProductBrandRecordDTO>> GetAllProductBrand();
        Task<ProductBrand> GetProductBrandById(int id);
        Task<int> CreateProductBrand(ProductBrand ProductBrand);
        Task<int> UpdateProductBrand(ProductBrand ProductBrand);
        Task<int> DeleteProductBrand(int id);
        #endregion

        #region PromoCode Management
        Task<List<PromoCodeRecordDTO>> GetAllPromoCode();
        Task<PromoCodeDetailsDTO> GetPromoCodeById(int id);
        Task<int> CreatePromoCode(PromoCode PromoCode);
        Task<int> UpdatePromoCode(PromoCode PromoCode);
        Task<int> DeletePromoCode(int id);
        #endregion

        #region Package Management
        Task<List<PackageRecordDTO>> GetAllPackage();
        Task<PackageDetailsDTO> GePackageById(int Id);
        Task CreatePackage(CreateOrUpdatePackageDTO dto);
        Task UpdatePackage(CreateOrUpdatePackageDTO dto);
        Task DeletePackage(int Id);
        #endregion

        #region Product Management
        Task<List<ProductRecordDTO>> GetAllProduct();
        Task<ProductDetailsDTO> GeProductById(int Id);
        Task CreateProduct(CreateOrUpdateProductDTO dto);
        Task UpdateProduct(CreateOrUpdateProductDTO dto);
        Task DeleteProduct(int Id);
        #endregion
    }
}
