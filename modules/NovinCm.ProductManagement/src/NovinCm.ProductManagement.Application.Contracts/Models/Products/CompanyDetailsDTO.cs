using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace NovinCm.ProductManagement.Models.Products
{
    [Serializable]
    public class CompanyDetailsDto : FullAuditedEntityDto<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
