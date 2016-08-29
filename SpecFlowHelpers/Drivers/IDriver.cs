using SpecFlowHelpers.Pages;

namespace SpecFlowHelpers.Drivers
{
    public interface IDriver
    {
        void Initialize();
        void NavigateTo(IPage page);
        ITePrestaHome NavigateToHomePage();
        void Close();
    }
}
