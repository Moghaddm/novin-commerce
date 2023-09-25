using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace NovinCm.ProductManagement.Models.Products
{
    [Serializable]
    public class CategoryDto : AuditedEntityDto<Guid>
    {
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
