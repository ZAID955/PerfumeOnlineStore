using Microsoft.EntityFrameworkCore;
using PerfumeOnlineStore_Core.Dtos.Admin.Brand;
using PerfumeOnlineStore_Core.Dtos.Admin.Package;
using PerfumeOnlineStore_Core.Dtos.Admin.Product;
using PerfumeOnlineStore_Core.Dtos.Admin.ProductSection;
using PerfumeOnlineStore_Core.Dtos.Admin.ProductSize;
using PerfumeOnlineStore_Core.Dtos.Admin.ProductType;
using PerfumeOnlineStore_Core.Dtos.Admin.PromoCode;
using PerfumeOnlineStore_Core.IRepos;
using PerfumeOnlineStore_Core.Models.Context;
using PerfumeOnlineStore_Core.Models.Entites;

namespace PerfumeOnlineStore_Infra.ReposImplementation
{
    public class AdmanRepos : IAdmanReposInterface
    {
        private readonly PerfumeOnlineStoreDbContext _context;
        public AdmanRepos(PerfumeOnlineStoreDbContext context)
        {
            _context = context;
        }

        #region ProductSize Management
        public async Task<List<ProductSizeRecordDTO>> GetAllProductSize()
        {
            var result = await _context.ProductSizes
                .Select(ps => new ProductSizeRecordDTO
                {
                    Id = ps.Id,
                    Size = ps.Size
                })
                .ToListAsync();
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new ArgumentException("No ProductSize found");
            }
        }
        public async Task<ProductSize> GetProductSizeById(int id)
        {
            var result = await _context.ProductSizes
                .Where(ps => ps.Id == id)
                .Select(ps => new ProductSize
                {
                    Id = ps.Id,
                    IsActive = ps.IsActive,
                    CreationDateTime = ps.CreationDateTime,
                    Size = ps.Size
                })
                .FirstOrDefaultAsync();
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new ArgumentException("ProductSize not found");
            }

        }
        public async Task<int> CreateProductSize(ProductSize productSize)
        {
            _context.ProductSizes.Add(productSize);
            await _context.SaveChangesAsync();
            return productSize.Id;
        }
        public async Task<int> UpdateProductSize(ProductSize productSize)
        {
            var existingProductSize = await _context.ProductSizes.FindAsync(productSize.Id);
            if (existingProductSize == null)
            {
                throw new ArgumentException("Product size not found.");
            }

            existingProductSize.Size = productSize.Size;

            await _context.SaveChangesAsync();
            return existingProductSize.Id;
        }
        public async Task<int> DeleteProductSize(int id)
        {
            var productSize = await _context.ProductSizes.FindAsync(id);
            if (productSize == null)
            {
                throw new ArgumentException("Product size not found.");
            }

            _context.ProductSizes.Remove(productSize);
            await _context.SaveChangesAsync();
            return id;
        }
        #endregion

        #region ProductSection Management
        public async Task<List<ProductSectionRecordDTO>> GetAllProductSection()
        {
            var result = await _context.ProductSections
                .Select(ps => new ProductSectionRecordDTO
                {
                    Id = ps.Id,
                    Name = ps.Name
                })
                .ToListAsync();
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new ArgumentException("No ProductSection found");
            }
        }
        public async Task<ProductSection> GetProductSectionById(int id)
        {
            var result = await _context.ProductSections
                .Where(ps => ps.Id == id)
                .Select(ps => new ProductSection
                {
                    Id = ps.Id,
                    IsActive = ps.IsActive,
                    CreationDateTime = ps.CreationDateTime,
                    Name = ps.Name
                })
                .FirstOrDefaultAsync();
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new ArgumentException("ProductSection not found");
            }
        }
        public async Task<int> CreateProductSection(ProductSection productSection)
        {
            _context.ProductSections.Add(productSection);
            await _context.SaveChangesAsync();
            return productSection.Id;
        }
        public async Task<int> UpdateProductSection(ProductSection ProductSection)
        {
            var existingProductSection = await _context.ProductSections.FindAsync(ProductSection.Id);
            if (existingProductSection == null)
            {
                throw new ArgumentException("ProductSection not found.");
            }
            else
            {
                existingProductSection.Name = ProductSection.Name;

                await _context.SaveChangesAsync();
                return existingProductSection.Id;
            }

        }
        public async Task<int> DeleteProductSection(int id)
        {
            var ProductSection = await _context.ProductSections.FindAsync(id);
            if (ProductSection == null)
            {
                throw new ArgumentException("ProductSection not found.");
            }

            _context.ProductSections.Remove(ProductSection);
            await _context.SaveChangesAsync();
            return id;
        }
        #endregion

        #region ProductType Management
        public async Task<List<ProductTypeRecordDTO>> GetAllProductType()
        {
            var result = await _context.ProductTypes
                .Select(ps => new ProductTypeRecordDTO
                {
                    Id = ps.Id,
                    Name = ps.Name
                })
                .ToListAsync();
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new ArgumentException("No ProductType found");
            }
        }
        public async Task<ProductType> GetProductTypeById(int id)
        {
            var result = await _context.ProductTypes
                .Where(ps => ps.Id == id)
                .Select(ps => new ProductType
                {
                    Id = ps.Id,
                    IsActive = ps.IsActive,
                    CreationDateTime = ps.CreationDateTime,
                    Name = ps.Name
                })
                .FirstOrDefaultAsync();
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new ArgumentException("ProductType not found");
            }
        }
        public async Task<int> CreateProductType(ProductType ProductType)
        {
            _context.ProductTypes.Add(ProductType);
            await _context.SaveChangesAsync();
            return ProductType.Id;
        }
        public async Task<int> UpdateProductType(ProductType ProductType)
        {
            var existingProductType = await _context.ProductTypes.FindAsync(ProductType.Id);
            if (existingProductType == null)
            {
                throw new ArgumentException("ProductType not found.");
            }
            else
            {
                existingProductType.Name = ProductType.Name;

                await _context.SaveChangesAsync();
                return existingProductType.Id;
            }

        }
        public async Task<int> DeleteProductType(int id)
        {
            var ProductType = await _context.ProductTypes.FindAsync(id);
            if (ProductType == null)
            {
                throw new ArgumentException("ProductType not found.");
            }

            _context.ProductTypes.Remove(ProductType);
            await _context.SaveChangesAsync();
            return id;
        }
        #endregion

        #region ProductBrand Management
        public async Task<List<ProductBrandRecordDTO>> GetAllProductBrand()
        {
            var result = await _context.ProductBrands
                .Select(ps => new ProductBrandRecordDTO
                {
                    Id = ps.Id,
                    Name = ps.Name
                })
                .ToListAsync();
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new ArgumentException("No ProductBrand found");
            }
        }
        public async Task<ProductBrand> GetProductBrandById(int id)
        {
            var result = await _context.ProductBrands
                .Where(ps => ps.Id == id)
                .Select(ps => new ProductBrand
                {
                    Id = ps.Id,
                    IsActive = ps.IsActive,
                    CreationDateTime = ps.CreationDateTime,
                    Name = ps.Name
                })
                .FirstOrDefaultAsync();
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new ArgumentException("ProductBrand not found");
            }
        }
        public async Task<int> CreateProductBrand(ProductBrand ProductBrand)
        {
            _context.ProductBrands.Add(ProductBrand);
            await _context.SaveChangesAsync();
            return ProductBrand.Id;
        }
        public async Task<int> UpdateProductBrand(ProductBrand ProductBrand)
        {
            var existingProductBrand = await _context.ProductBrands.FindAsync(ProductBrand.Id);
            if (existingProductBrand == null)
            {
                throw new ArgumentException("ProductBrand not found.");
            }
            else
            {
                existingProductBrand.Name = ProductBrand.Name;

                await _context.SaveChangesAsync();
                return existingProductBrand.Id;
            }

        }
        public async Task<int> DeleteProductBrand(int id)
        {
            var ProductBrand = await _context.ProductBrands.FindAsync(id);
            if (ProductBrand == null)
            {
                throw new ArgumentException("ProductBrand not found.");
            }

            _context.ProductBrands.Remove(ProductBrand);
            await _context.SaveChangesAsync();
            return id;
        }
        #endregion

        #region PromoCode Management
        public async Task<List<PromoCodeRecordDTO>> GetAllPromoCode()
        {
            var result = await _context.PromoCodes
                .Select(p => new PromoCodeRecordDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    DiscountAmount = p.DiscountAmount,
                    DateTimeActive = p.DateTimeActive
                })
                .ToListAsync();
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new ArgumentException("No ProductBrand found");
            }
        }

        public async Task<PromoCodeDetailsDTO> GetPromoCodeById(int id)
        {
            var promoCode = await _context.PromoCodes.FindAsync(id);
            if (promoCode == null)
                return null;

            var result = new PromoCodeDetailsDTO
            {
                Id = promoCode.Id,
                Name = promoCode.Name,
                CreationDateTime = promoCode.CreationDateTime,
                DiscountAmount = promoCode.DiscountAmount,
                DateTimeActive = promoCode.DateTimeActive
            };
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new ArgumentException("ProductBrand not found");
            }
        }
        public async Task<int> CreatePromoCode(PromoCode PromoCode)
        {
            _context.PromoCodes.Add(PromoCode);
            await _context.SaveChangesAsync();
            return PromoCode.Id;
        }
        public async Task<int> UpdatePromoCode(PromoCode PromoCode)
        {
            var existingPromoCode = await _context.PromoCodes.FindAsync(PromoCode.Id);
            if (existingPromoCode == null)
            {
                throw new ArgumentException("ProductBrand not found.");
            }
            else
            {
                existingPromoCode.Name = PromoCode.Name;
                existingPromoCode.DiscountAmount = PromoCode.DiscountAmount;
                existingPromoCode.DateTimeActive = PromoCode.DateTimeActive;


                await _context.SaveChangesAsync();
                return existingPromoCode.Id;
            }
        }

        public async Task<int> DeletePromoCode(int id)
        {
            var promoCode = await _context.PromoCodes.FindAsync(id);
            if (promoCode == null)
                throw new ArgumentException("Promo code not found.");

            _context.PromoCodes.Remove(promoCode);
            await _context.SaveChangesAsync();
            return promoCode.Id;
        }
        #endregion

        #region Package Management
        public async Task<List<PackageRecordDTO>> GetAllPackage()
        {
            var result = new List<PackageRecordDTO>();
            var Package = await _context.Packages.ToListAsync();

            if (Package != null)
            {
                foreach (var package in Package)
                {
                    var dto = new PackageRecordDTO();
                    dto.Id = package.Id;
                    dto.Name = package.Name;
                    dto.ImageUrl = package.ImageUrl;
                    dto.Quantity = package.Quantity;
                    dto.Price = package.Price;
                    dto.Category = package.Category.ToString();

                    result.Add(dto);
                }
                return result.ToList();
            }
            else
            {
                throw new ArgumentException("Product not found");
            }
        }
        public async Task<PackageDetailsDTO> GePackageById(int Id)
        {
            var result = new PackageDetailsDTO();
            var package = await _context.Packages.FirstOrDefaultAsync(p => p.Id == Id);
            if (package != null)
            {
                result.Id = package.Id;
                result.IsActive = package.IsActive;
                result.CreationDateTime = package.CreationDateTime;
                result.Name = package.Name;
                result.Category = package.Category.ToString();
                result.Description = package.Description;
                result.ImageUrl = package.ImageUrl;
                result.Quantity = package.Quantity;
                result.Price = package.Price;

                return result;
            }
            else
            {
                throw new ArgumentException("Package not found");
            }
        }
        public async Task CreatePackage(CreateOrUpdatePackageDTO dto)
        {
            var package = await _context.Packages.Where(x => x.Name.Equals(dto.Name)).ToListAsync();
            if (package != null)
            {
                throw new ArgumentException("The package name is already in use.");
            }
            else
            {
                var newpackage = new Package
                {
                    Name = dto.Name,
                    Category = dto.Category,
                    Quantity = dto.Quantity,
                    Price = dto.Price,
                    ImageUrl = dto.ImageUrl,
                    Description = dto.Description,
                };
                await _context.Packages.AddAsync(newpackage);
                await _context.SaveChangesAsync();
                throw new ArgumentException("successfully Created");
            }

        }
        public async Task UpdatePackage(CreateOrUpdatePackageDTO dto)
        {
            var package = await _context.Packages.FindAsync(dto.Id);

            if (package != null)
            {
                package.Name = dto.Name;
                package.Category = dto.Category;
                package.Description = dto.Description;
                package.ImageUrl = dto.ImageUrl;
                package.Quantity = dto.Quantity;
                package.Price = dto.Price;
                await _context.SaveChangesAsync();
                throw new ArgumentException("successfully Updated");
            }
            else
            {
                throw new ArgumentException("Package not found");
            }
        }
        public async Task DeletePackage(int Id)
        {
            var package = await _context.Packages.FindAsync(Id);

            if (package != null)
            {
                _context.Packages.Remove(package);
                await _context.SaveChangesAsync();

                throw new ArgumentException("Successfully Deleted");
            }
            else
            {
                throw new ArgumentException("Package not found");
            }
        }
        #endregion

        #region Product Management
        public async Task<List<ProductRecordDTO>> GetAllProduct()
        {
            var result = new List<ProductRecordDTO>();
            var Product = await _context.Productes
                                   .Include(x => x.ProductBrand)
                                   .Include(x => x.Size)
                                   .ToListAsync();

            if (Product != null)
            {
                foreach (var product in Product)
                {
                    var dto = new ProductRecordDTO();
                    dto.Id = product.Id;
                    dto.Name = product.Name;
                    dto.ImageUrl = product.ImageUrl;
                    dto.Size = product.Size.Size;
                    dto.SizeUnite = product.SizeUnite.ToString();
                    dto.Price = product.Price;
                    dto.Brand = product.ProductBrand.Name;


                    result.Add(dto);
                }
                return result.ToList();
            }
            else
            {
                throw new ArgumentException("Product not found");
            }
        }
        public async Task<ProductDetailsDTO> GeProductById(int Id)
        {
            var result = new ProductDetailsDTO();
            var product = await _context.Productes
                                   .Include(x => x.ProductBrand)
                                   .Include(x => x.Type)
                                   .Include(x => x.Size)
                                   .Include(x => x.Section)
                            .FirstOrDefaultAsync(sp => sp.Id == Id);
            if (product != null)
            {
                result.Id = product.Id;
                result.IsActive = product.IsActive;
                result.CreationDateTime = product.CreationDateTime;
                result.Name = product.Name;
                result.Brand = product.ProductBrand.Name;
                result.Category = product.Category.ToString();
                result.Type = product.Type.Name;
                result.Section = product.Section.Name;
                result.SizeId = product.Size.Id;
                result.SizeUnite = product.SizeUnite.ToString();
                result.Description = product.Description;
                result.ImageUrl = product.ImageUrl;
                result.Quantity = product.Quantity;
                result.Price = product.Price;
                result.MinQuantity = product.MinQuantity;
                return result;
            }
            else
            {
                throw new ArgumentException("Product not found");
            }

        }
        public async Task CreateProduct(CreateOrUpdateProductDTO dto)
        {
            var product = await _context.Productes.Where(pr => pr.Name.Equals(dto.Name)
                                                        && pr.ProductBrand.Id.Equals(dto.BrandId)
                                                        && pr.Size.Id.Equals(dto.SizeId)
                                                        && pr.Type.Id.Equals(dto.TypeId)
                                                        && pr.Category.Equals(dto.Category)
                                                        && pr.Section.Id.Equals(dto.SectionId)
                                                        ).ToListAsync();
            if (product != null)
            {
                throw new ArgumentException("product is available");
            }
            else
            {
                var newproduct = new Product();
                newproduct.Name = dto.Name;
                newproduct.ProductBrand = await GetProductBrandById(dto.BrandId);
                newproduct.Category = dto.Category;
                newproduct.SizeUnite = dto.SizeUnite;
                newproduct.Quantity = dto.NewQuantity;
                newproduct.Price = dto.Price;
                newproduct.MinQuantity = dto.MinQuantity;
                newproduct.ImageUrl = dto.ImageUrl;
                newproduct.Description = dto.Description;
                newproduct.Size = await GetProductSizeById(dto.SizeId);
                newproduct.Type = await GetProductTypeById(dto.TypeId);
                newproduct.Section = await GetProductSectionById(dto.SectionId);

                await _context.Productes.AddAsync(newproduct);
                await _context.SaveChangesAsync();
                throw new ArgumentException("successfully Created");
            }

        }
        public async Task UpdateProduct(CreateOrUpdateProductDTO dto)
        {
            var product = await _context.Productes.FindAsync(dto.Id);

            if (product != null)
            {
                product.Name = dto.Name;
                product.ProductBrand = await GetProductBrandById(dto.BrandId);
                product.Category = dto.Category;
                product.Type = await GetProductTypeById(dto.TypeId);
                product.Section = await GetProductSectionById(dto.SectionId);
                product.Size = await GetProductSizeById(dto.SizeId);
                product.SizeUnite = dto.SizeUnite;
                product.Description = dto.Description;
                product.ImageUrl = dto.ImageUrl;
                product.Quantity = product.Quantity + dto.NewQuantity;
                product.Price = dto.Price;
                product.MinQuantity = dto.MinQuantity;

                await _context.SaveChangesAsync();
                throw new ArgumentException("successfully Updated");
            }
            else
            {
                throw new ArgumentException("Product not found");
            }
        }
        public async Task DeleteProduct(int Id)
        {
            var producte = await _context.Productes.FindAsync(Id);

            if (producte != null)
            {
                _context.Productes.Remove(producte);
                await _context.SaveChangesAsync();

                throw new ArgumentException("Successfully Deleted");
            }
            else
            {
                throw new ArgumentException("Producte not found");
            }
        }
        #endregion
    }
}