using NovinCm.FileManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace NovinCm.FileManagement;

public abstract class FileManagementController : AbpControllerBase
{
    protected FileManagementController()
    {
        LocalizationResource = typeof(FileManagementResource);
    }
}
