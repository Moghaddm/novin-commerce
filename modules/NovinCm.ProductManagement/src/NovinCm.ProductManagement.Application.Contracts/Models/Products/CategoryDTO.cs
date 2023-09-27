using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace NovinCm.ProductManagement.Models.Products;

[Serializable]
public class CategoryDto : AuditedEntityDto<Guid>
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; }

    public string Description { get; set; }
}