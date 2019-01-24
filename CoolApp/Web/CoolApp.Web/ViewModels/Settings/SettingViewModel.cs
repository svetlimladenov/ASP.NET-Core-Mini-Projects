namespace CoolApp.Web.ViewModels.Settings
{
    using CoolApp.Data.Models;
    using CoolApp.Services.Mapping;

    public class SettingViewModel : IMapFrom<Setting>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}
