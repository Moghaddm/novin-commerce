using System;
using Volo.Abp.Application.Dtos;

namespace NovinCm.ProductManagement.Models.Products;

[Serializable]
public class ProductDetailsDto : FullAuditedEntityDto<Guid>
{
    public virtual string Name { get; set; }
    public virtual string Description { get; set; }
    public virtual long Price { get; set; }
    public virtual int Quantity { get; set; }
    public CompanyDetailsDto Company { get; set; }
}