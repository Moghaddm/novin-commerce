using NovinCommerce.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace NovinCommerce.Models.Products
{
    [Serializable]
    public class ProductCreateUpdateDto : CreationAuditedEntityDto<Guid>
    {
        [Required]
        [StringLength(ProductConsts.MaxNameLength, MinimumLength = ProductConsts.MinNameLength)]
        public string Name { get; set; }
        [StringLength(ProductConsts.MaxDescriptionLength, MinimumLength = ProductConsts.MinDescriptionLength)]
        public string Description { get; set; }
        public long Price { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
