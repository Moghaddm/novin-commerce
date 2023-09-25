using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace NovinCommerce.Models.Companies
{
    [Serializable]
    public class CompanyDto : FullAuditedEntityDto<Guid>
    {
        [Required]
        [StringLength(maximumLength:100,MinimumLength =2)]
        public string Title { get;  set; }
        public string Description { get; set; }
    }
}
