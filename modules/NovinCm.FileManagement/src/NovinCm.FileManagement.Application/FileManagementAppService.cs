using NovinCm.FileManagement.Localization;
using Volo.Abp.Application.Services;

namespace NovinCm.FileManagement;

public abstract class FileManagementAppService : ApplicationService
{
    protected FileManagementAppService()
    {
        LocalizationResource = typeof(FileManagementResource);
        ObjectMapperContext = typeof(FileManagementApplicationModule);
    }
}
