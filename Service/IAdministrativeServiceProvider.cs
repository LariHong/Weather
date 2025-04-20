using Weather.Infrastructure;

namespace Weather.Service
{
    // AdministrativeServiceProvider自動注入介面
    public interface IAdministrativeServiceProvider
    {
        public AdministrativeService Create();
    }
}
