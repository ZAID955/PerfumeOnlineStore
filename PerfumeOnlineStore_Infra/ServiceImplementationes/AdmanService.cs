using PerfumeOnlineStore_Core.Dtos;
using PerfumeOnlineStore_Core.Dtos.Admin.Brand;
using PerfumeOnlineStore_Core.Dtos.Admin.Package;
using PerfumeOnlineStore_Core.Dtos.Admin.Product;
using PerfumeOnlineStore_Core.Dtos.Admin.ProductSection;
using PerfumeOnlineStore_Core.Dtos.Admin.ProductSize;
using PerfumeOnlineStore_Core.Dtos.Admin.ProductType;
using PerfumeOnlineStore_Core.Dtos.Admin.PromoCode;
using PerfumeOnlineStore_Core.Dtos.Client;
using PerfumeOnlineStore_Core.IRepos;
using PerfumeOnlineStore_Core.IServices;
using PerfumeOnlineStore_Core.Models.Entites;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PerfumeOnlineStore_Core.Helper.Enums.PerfumeOnlineStoreLookups;
using static PerfumeOnlineStore_Infra.ReposImplementation.AdmanRepos;

namespace PerfumeOnlineStore_Infra.ServiceImplementation
{
    public class AdmanService : IAdmanServiceInterface
    {
        private readonly IAdmanReposInterface _repos;
        public AdmanService(IAdmanReposInterface repos)
        {
            _repos = repos;
        }

        #region ProductSize Management
        public async Task<List<ProductSizeRecordDTO>> GetAllProductSize()
        {
            return await _repos.GetAllProductSize();
        }
        public async Task<ProductSize> GetProductSizeById(int id)
        {
            return await _repos.GetProductSizeById(id);
        }
        public async Task<int> CreateProductSize(int Size)
        {
            return await _repos.CreateProductSize(new ProductSize { Size = Size });
        }
        public async Task<int> UpdateProductSize(UpdateProductSizeDTO dto)
        {
            var existingProductSize = new ProductSize
            {
                Id = dto.Id,
                Size = dto.Size
            };

            return await _repos.UpdateProductSize(existingProductSize);
        }
        public async Task<int> DeleteProductSize(int id)
        {
            return await _repos.DeleteProductSize(id);
        }
        #endregion

        #region ProductSection Management
        public async Task<List<ProductSectionRecordDTO>> GetAllProductSection()
        {
            return await _repos.GetAllProductSection();
        }
        public async Task<ProductSection> GetProductSectionById(int id)
        {
            return await _repos.GetProductSectionById(id);
        }
        public async Task<int> CreateProductSection(string name)
        {
            var ProductSection = new ProductSection { Name = name };
            return await _repos.CreateProductSection(ProductSection);
        }
        public async Task<int> UpdateProductSection(UpdateProductSectionDTO dto)
        {
            var existingProductSection = new ProductSection
            {
                Id = dto.Id,
                Name = dto.Name
            };

            return await _repos.UpdateProductSection(existingProductSection);
        }
        public async Task<int> DeleteProductSection(int id)
        {
            return await _repos.DeleteProductSection(id);
        }
        #endregion

        #region ProductType Management
        public async Task<List<ProductTypeRecordDTO>> GetAllProductType()
        {
            return await _repos.GetAllProductType();
        }
        public async Task<ProductType> GetProductTypeById(int id)
        {
            return await _repos.GetProductTypeById(id);
        }
        public async Task<int> CreateProductType(string name)
        {
            var ProductType = new ProductType { Name = name };
            return await _repos.CreateProductType(ProductType);
        }
        public async Task<int> UpdateProductType(UpdateProductTypeDTO dto)
        {
            var existingProductType = new ProductType
            {
                Id = dto.Id,
                Name = dto.Name
            };

            return await _repos.UpdateProductType(existingProductType);
        }
        public async Task<int> DeleteProductType(int id)
        {
            return await _repos.DeleteProductType(id);
        }
        #endregion

        #region ProductBrand Management
        public async Task<List<ProductBrandRecordDTO>> GetAllProductBrand()
        {
            return await _repos.GetAllProductBrand();
        }
        public async Task<ProductBrand> GetProductBrandById(int id)
        {
            return await _repos.GetProductBrandById(id);
        }
        public async Task<int> CreateProductBrand(string name)
        {
            var ProductBrand = new ProductBrand { Name = name };
            return await _repos.CreateProductBrand(ProductBrand);
        }
        public async Task<int> UpdateProductBrand(UpdateProductBrandDTO dto)
        {
            var existingProductBrand = new ProductBrand
            {
                Id = dto.Id,
                Name = dto.Name
            };

            return await _repos.UpdateProductBrand(existingProductBrand);
        }
        public async Task<int> DeleteProductBrand(int id)
        {
            return await _repos.DeleteProductBrand(id);
        }
        #endregion

        #region PromoCode Management
        public async Task<List<PromoCodeRecordDTO>> GetAllPromoCode()
        {
            return await _repos.GetAllPromoCode();
        }

        public async Task<PromoCodeDetailsDTO> GetPromoCodeById(int id)
        {
            return await _repos.GetPromoCodeById(id);
        }

        public async Task<int> CreatePromoCode(CreatePromoCodeDTO dto)
        {
            var PromoCode = new PromoCode
            {
                Name = dto.Name,
                DiscountAmount = dto.DiscountAmount,
                DateTimeActive = dto.DateTimeActive

            };
            return await _repos.CreatePromoCode(PromoCode);
        }

        public async Task<int> UpdatePromoCode(UpdatePromoCodeDTO dto)
        {
            var existingPromoCode = new PromoCode
            {
                Id = dto.Id,
                Name = dto.Name,
                DiscountAmount = dto.DiscountAmount,
                DateTimeActive = dto.DateTimeActive

            };

            return await _repos.UpdatePromoCode(existingPromoCode);
        }

        public async Task<int> DeletePromoCode(int id)
        {
            return await _repos.DeletePromoCode(id);
        }
        #endregion

        #region Package Management
        public async Task<List<PackageRecordDTO>> GetAllPackage()
        {
            return await _repos.GetAllPackage();
        }
        public async Task<PackageDetailsDTO> GePackageById(int Id)
        {
            return await _repos.GePackageById(Id);
        }
        public async Task<List<PackageRecordDTO>> SearchOnPackage(string? Name, int Price, string? Category)
        {
            var result = new List<PackageRecordDTO>();
            var GetAllpackages = await _repos.GetAllPackage();
            if (GetAllpackages != null)
            {
                if (Name != null && Price != 0 && Category != null)
                {
                    result = GetAllpackages.Where(x => x.Name.Contains(Name)
                          || x.Category.Equals(Category)
                          || x.Price.Equals(Price)).ToList();
                }
                else if (Name != null && Price == 0 && Category != null)
                {
                    result = GetAllpackages.Where(x => x.Name.Contains(Name)
                          || x.Category.Equals(Category)).ToList();
                }
                else if (Name != null && Price != 0 && Category == null)
                {
                    result = GetAllpackages.Where(x => x.Name.Contains(Name)
                          || x.Price.Equals(Price)).ToList();
                }
                else if (Name != null && Price == 0 && Category == null)
                {
                    result = GetAllpackages.Where(x => x.Name.Contains(Name)).ToList();
                }
                else if (Name == null && Price != 0 && Category != null)
                {
                    result = GetAllpackages.Where(x => x.Category.Equals(Category)
                          || x.Price.Equals(Price)).ToList();
                }
                else if (Name == null && Price != 0 && Category == null)
                {
                    result = GetAllpackages.Where(x => x.Price.Equals(Price)).ToList();
                }
                else if (Name == null && Price == 0 && Category != null)
                {
                    result = GetAllpackages.Where(x => x.Category.Equals(Category)).ToList();
                }
                else
                {
                    throw new ArgumentException("Package  not found");
                }
                return result;
            }
            else
            {
                throw new ArgumentException("Package  not found");
            }
        }
        public Task CreatePackage(CreateOrUpdatePackageDTO dto)
        {
            return _repos.CreatePackage(dto);
        }
        public Task UpdatePackage(CreateOrUpdatePackageDTO dto)
        {
            return _repos.UpdatePackage(dto);
        }
        public Task DeletePackage(int Id)
        {
            return _repos.DeletePackage(Id);
        }
        #endregion

        #region Product Management
        public async Task<List<ProductRecordDTO>> GetAllProduct()
        {
            return await _repos.GetAllProduct();

        }
        public async Task<ProductDetailsDTO> GeProductById(int Id)
        {
            return await _repos.GeProductById(Id);
        }
        public async Task<List<ProductRecordDTO>> SearchOnProduct(string? Name, string? Brand, int Price, int Size)
        {
            var result = new List<ProductRecordDTO>();
            var GetAllproductes = await _repos.GetAllProduct();
            if (GetAllproductes != null)
            {
                if (Name != null && Brand != null && Price != 0 && Size != 0)
                {
                    result = GetAllproductes.Where(x => x.Name.Contains(Name)
                                               || x.Brand.Equals(Brand)
                                               || x.Price.Equals(Price)
                                               || x.Size.Equals(Size)).ToList();
                }
                else if (Name != null && Brand == null && Price != 0 && Size != 0)
                {
                    result = GetAllproductes.Where(x => x.Name.Contains(Name)
                                               || x.Price.Equals(Price)
                                               || x.Size.Equals(Size)).ToList();
                }
                else if (Name != null && Brand != null && Price == 0 && Size != 0)
                {
                    result = GetAllproductes.Where(x => x.Name.Contains(Name)
                                               || x.Brand.Equals(Brand)
                                               || x.Size.Equals(Size)).ToList();
                }
                else if (Name != null && Brand != null && Price != 0 && Size == 0)
                {
                    result = GetAllproductes.Where(x => x.Name.Contains(Name)
                                              || x.Brand.Equals(Brand)
                                              || x.Price.Equals(Price)).ToList();
                }
                else if (Name != null && Brand == null && Price == 0 && Size != 0)
                {
                    result = GetAllproductes.Where(x => x.Name.Contains(Name)
                                               || x.Size.Equals(Size)).ToList();
                }
                else if (Name != null && Brand == null && Price != 0 && Size == 0)
                {
                    result = GetAllproductes.Where(x => x.Name.Contains(Name)
                                               || x.Price.Equals(Price)).ToList();
                }
                else if (Name != null && Brand != null && Price == 0 && Size == 0)
                {
                    result = GetAllproductes.Where(x => x.Name.Contains(Name)
                                               || x.Brand.Equals(Brand)).ToList();
                }
                else if (Name != null && Brand == null && Price == 0 && Size == 0)
                {
                    result = GetAllproductes.Where(x => x.Name.Contains(Name)).ToList();
                }
                else if (Name == null && Brand != null && Price != 0 && Size != 0)
                {
                    result = GetAllproductes.Where(x => x.Brand.Equals(Brand)
                                               || x.Price.Equals(Price)
                                               || x.Size.Equals(Size)).ToList();
                }
                else if (Name == null && Brand != null && Price != 0 && Size == 0)
                {
                    result = GetAllproductes.Where(x => x.Brand.Equals(Brand)
                                               || x.Price.Equals(Price)).ToList();
                }
                else if (Name == null && Brand != null && Price == 0 && Size != 0)
                {
                    result = GetAllproductes.Where(x => x.Brand.Equals(Brand)
                                               || x.Size.Equals(Size)).ToList();
                }
                else if (Name == null && Brand != null && Price == 0 && Size == 0)
                {
                    result = GetAllproductes.Where(x => x.Brand.Equals(Brand)).ToList();
                }
                else if (Name == null && Brand == null && Price != 0 && Size != 0)
                {
                    result = GetAllproductes.Where(x => x.Price.Equals(Price)
                                                || x.Size.Equals(Size)).ToList();
                }
                else if (Name == null && Brand == null && Price == 0 && Size != 0)
                {
                    result = GetAllproductes.Where(x => x.Price.Equals(Price)).ToList();
                }
                else if (Name == null && Brand == null && Price == 0 && Size != 0)
                {
                    result = GetAllproductes.Where(x => x.Size.Equals(Size)).ToList();
                }
                else
                {
                    throw new ArgumentException("Producte  not found");

                }
                return result;
            }
            else
            {
                throw new ArgumentException("Producte  not found");
            }

        }
        public Task CreateProduct(CreateOrUpdateProductDTO dto)
        {
            return _repos.CreateProduct(dto);
        }
        public Task UpdateProduct(CreateOrUpdateProductDTO dto)
        {
            return _repos.UpdateProduct(dto);
        }
        public Task DeleteProduct(int Id)
        {
            return _repos.DeleteProduct(Id);
        }
        #endregion
    }
}
