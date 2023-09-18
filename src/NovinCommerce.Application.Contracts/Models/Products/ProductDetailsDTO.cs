using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace NovinCommerce.Models.Products
{
    [Serializable]
    public class ProductDetailsDto : ExtensibleAuditedEntityDto<Guid>
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual long Price { get; set; }
        public virtual int Quantity { get; set; }
        public CompanyDetailsDto Company { get; set; }
    }
}
