using NovinCommerce.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace NovinCommerce.Models.Products
{
    [Serializable]
    public class ProductCreateDto : CreationAuditedEntityDto<Guid>
    {
        [Required]
        [StringLength(ProductConsts.MaxNameLength,MinimumLength =ProductConsts.MinNameLength)]
        public virtual string Name { get; set; }
        [StringLength(ProductConsts.MaxDescriptionLength, MinimumLength = ProductConsts.MinDescriptionLength)]
        public virtual string Description { get; set; }
        public virtual long Price { get; set; }
        public virtual int Quantity { get; set; }
    }
}
