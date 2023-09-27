using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using NovinCommerce.Categories;
using NovinCommerce.Entities.Products;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace NovinCommerce.Entities.Categories;

public class Category : AuditedAggregateRoot<Guid>
{
    protected Category()
    {
    }

    public Category(string name, string description)
    {
        SetCategoryName(name);
        SetCategoryDescription(description);
    }

    public virtual string Name { get; private set; }
    public virtual string Description { get; private set; }

    public List<Product> Products { get; private set; }

    private void SetCategoryName(string name)
    {
        Name = Check.NotNullOrWhiteSpace(name, nameof(name), CategoryConsts.MaxNameLength,
            CategoryConsts.MinNameLength);
    }

    private void SetCategoryDescription(string description)
    {
        Description = Check.NotNullOrWhiteSpace(description, nameof(description), CategoryConsts.MaxDescriptionLength);
    }

    public void Update(string name, [CanBeNull] string description)
    {
        SetCategoryName(name);
        SetCategoryDescription(description);
    }
}