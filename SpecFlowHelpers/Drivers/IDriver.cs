using SpecFlowHelpers.Pages;

namespace SpecFlowHelpers.Drivers
{
    public interface IDriver
    {
        void Initialize();
        void NavigateTo(IBasePage page);
        ISpecFlowHome NavigateToHomePage();
        void Close();
        void TurnOnWait();
    }
}
