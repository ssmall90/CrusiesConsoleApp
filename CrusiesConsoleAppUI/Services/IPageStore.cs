using CrusiesConsoleAppUI.Pages;

namespace CrusiesConsoleAppUI.Services
{
    public interface IPageStore
    {
        IBasePage CurrentPage { get; set; }
    }
}