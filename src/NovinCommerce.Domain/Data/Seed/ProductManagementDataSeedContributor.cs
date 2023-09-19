using NovinCommerce.Entities.Categories;
using NovinCommerce.Entities.Companies;
using NovinCommerce.Entities.Products;
using NovinCommerce.Products;
using NovinCommerce.Repositories.Companies;
using NovinCommerce.Repositories.Products;
using NovinCommerce.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace NovinCommerce.Data.Seed
{
    internal class ProductManagementDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly ProductManagerService _productManagerService;

        public ProductManagementDataSeedContributor(IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            ICompanyRepository companyRepository,
            ProductManagerService productManagerService)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _companyRepository = companyRepository;
            _productManagerService = productManagerService;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _categoryRepository.GetCountAsync() > 0)
                return;

            /* Categories */
            var shoeCategory = new Category("Shoe", "Foot Care For Humans");
            var shirtCategory = new Category("Shirt", "Body Cover With Many Types");

            await _categoryRepository.InsertAsync(shoeCategory);
            await _categoryRepository.InsertAsync(shirtCategory);


            /* Companies */
            var kooroshCompany = new Company("Ofoghe Koorosh", "Internal Country-Wild Market");
            var refahCompany = new Company("Refah", "Best Internal Country-Wild Market");

            await _companyRepository.InsertAsync(refahCompany);
            await _companyRepository.InsertAsync(kooroshCompany);


            /* Products */
            var shoeProduct = await _productManagerService.CreateAsync(new Product("Walking Shoe 5x0x", "Good Shoe For Walk or Run", 350000, 15, ProductStockState.InStock, shoeCategory, kooroshCompany));
            var tShirtProduct = await _productManagerService.CreateAsync(new Product("T-Shirt 2y31", "Good T-Shirt For Covering in Public", 500000, 23, ProductStockState.InStock, shirtCategory, refahCompany));
            var hatProduct = await _productManagerService.CreateAsync(new Product("Sun Hat 4q12", "Good Hat For Sunny Days", 95000, 4, ProductStockState.InStock, shirtCategory, refahCompany));


            await _productRepository.InsertAsync(hatProduct);
            await _productRepository.InsertAsync(shoeProduct);
            await _productRepository.InsertAsync(tShirtProduct);
        }
    }
}
