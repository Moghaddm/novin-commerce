﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovinCommerce.Entities.Categories;
using NovinCommerce.Entities.Companies;
using NovinCommerce.Products;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Validation;

namespace NovinCommerce.Entities.Products
{
    public class Product : FullAuditedAggregateRoot<Guid>
    {
        protected Product() { }

        public Product(
            string name,
            string description,
            long price,
            int quantity,
            ProductStockState stockState,
            Category category,
            Company company)
        {
            SetProductName(name);
            SetProductDescription(description);
            SetProductPrice(price);
            SetProductQuantity(quantity);

            if (stockState is ProductStockState.Stopped)
                throw new BusinessException("Product stock cannot be negative in creation time.");

            _ = category ?? throw new ArgumentNullException(nameof(category));
            Category = category;

            _ = company ?? throw new ArgumentNullException(nameof(company));
            Company = company;

            StockState = stockState;
        }

        public virtual string Name { get; private set; }
        public virtual string Description { get; private set; }
        public virtual long Price { get; private set; }
        public virtual ProductStockState StockState { get; private set; }
        public virtual int Quantity { get; private set; }

        private void SetProductName(string name)
            => Name = Check.NotNullOrWhiteSpace(name, nameof(name), maxLength: ProductConsts.MaxNameLength, minLength: ProductConsts.MinNameLength);

        private void SetProductDescription(string description)
       => Description = Check.NotNullOrWhiteSpace(description, nameof(description), maxLength: ProductConsts.MaxDescriptionLength, ProductConsts.MinDescriptionLength);

        private void SetProductPrice(long price)
       => Price = Check.Positive(price, nameof(price));

        private void SetProductQuantity(int quantity)
            => Quantity = Check.Positive(quantity, nameof(quantity));

        public Product UpdateProduct(string name, string description, long price, int quantity)
        {
            SetProductName(name);
            SetProductDescription(description);
            SetProductPrice(price);
            SetProductQuantity(quantity);

            return this;
        }

        public void StopStockProduct() => StockState = ProductStockState.Stopped;

        public Category Category { get; private set; }
        public Company Company { get; private set; }
    }
}
