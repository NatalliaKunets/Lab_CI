using NUnit.Framework;
using Project.Core.Logging;
using Project.Core.UI.PageObjects.Pages;

namespace Project.Tests.UI;

[TestFixture]
public class UserLibrary : BaseTest
{
    [TestCase("31cinettxjyfv2um6x3aa2iqkkdi", "AT_Lab2024")]
    public void CreateNewPlaylist(string userName, string password)
    {
        Logger.Information("Entering Test Create a New Playlist");

        MainPage mainPage = new(Driver!);
        LoginPage loginPage = new(Driver!);

        if (Login(mainPage, loginPage, userName, password))
        {
            Logger.Information("Logged In successfully.");

            mainPage.ClickCreatePlaylistPlusBtn();
            mainPage.ClickCreatePlaylistMenuItem();

            Assert.That(mainPage.GetPlaylistTitle(), Does.Match(@"^My Playlist #\d+$"), "The playlist was not created successfully.");

            Logger.Information("Test Create a New Playlist executed.");
        }
    }

    private bool Login(MainPage mainPage, LoginPage loginPage, string userName, string password)
    {
        mainPage.ClickLoginButton();

        if (!loginPage.IsPageLoaded())
        {
            Logger.Error("Failed to load Login Page");
            return false;
        }

        loginPage.EnterUserName(userName);
        loginPage.EnterPassword(password);
        loginPage.ClickLoginButton();

        return mainPage.IsLoggedIn();
    }
}
