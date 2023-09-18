using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace NovinCommerce.Entities.Companies
{
    public class Company : FullAuditedAggregateRoot<Guid>
    {
        protected Company() { }

        public string Title { get; private set; }
        public string Description { get; private set; }

        public Company(string title, string description)
        {
            Title = Check.NotNullOrWhiteSpace(title, nameof(title));
            Description = Check.NotNullOrWhiteSpace(description, nameof(description));
        }
    }
}
