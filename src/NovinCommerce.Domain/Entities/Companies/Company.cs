using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace NovinCommerce.Entities.Companies;

public class Company : FullAuditedAggregateRoot<Guid>
{
    protected Company()
    {
    }

    public Company(string title, string description)
    {
        Title = Check.NotNullOrWhiteSpace(title, nameof(title));
        Description = Check.NotNullOrWhiteSpace(description, nameof(description));
    }

    public virtual string Title { get; private set; }
    public virtual string Description { get; private set; }

    public void Update(string title, string description)
    {
        Title = Check.NotNullOrWhiteSpace(title, nameof(title));
        Description = Check.NotNullOrWhiteSpace(description, nameof(description));
    }
}