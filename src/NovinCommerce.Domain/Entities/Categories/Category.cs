using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovinCommerce.Categories;
using NovinCommerce.Entities.Products;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace NovinCommerce.Entities.Categories
{
    public class Category : AuditedAggregateRoot<Guid>
    {
        protected Category() { }

        public virtual string Name { get; private set; }
        public virtual string Description { get; private set; }

        public Category(string name, string description)
        {
            SetCategoryName(name);
            SetCategoryDescription(description);
        }

        private void SetCategoryName(string name)
         => Name = Check.NotNullOrWhiteSpace(name, nameof(name), maxLength: CategoryConsts.MaxNameLength, minLength: CategoryConsts.MinNameLength);

        private void SetCategoryDescription(string description)
       => Description = Check.NotNullOrWhiteSpace(description, nameof(description), maxLength: CategoryConsts.MaxDescriptionLength, CategoryConsts.MinDescriptionLength);

        public List<Product> Products { get; private set; }
    }
}
