using NUnit.Framework;
using Project.Core.Logging;
using Project.Core.UI.PageObjects.Pages;

namespace Project.Tests.UI;

[TestFixture]
public class PlaylistManagement : BaseTest
{
	[TestCase("31cinettxjyfv2um6x3aa2iqkkdi", "AT_Lab2024", "New Playlist")]
	public void RenamePlaylist(string userName, string password, string newPlaylistName)
	{

		Logger.Information("Entering Test LogIn With Valid Credentials");

		MainPage mainPage = new(Driver!);
		LoginPage loginPage = new(Driver!);
		LibraryPage libPage = new(Driver!);

		mainPage.ClickLoginButton();

		if (!loginPage.IsPageLoaded())
		{
			Logger.Error("Failed to load Login Page");
			Assert.Fail("Login Page is not loaded");
		}

		loginPage.EnterUserName(userName);
		loginPage.EnterPassword(password);
		loginPage.ClickLoginButton();

		if (!mainPage.IsPageLoaded())
		{
			Logger.Error("Failed to load Main Page");
			Assert.Fail("Main Page is not loaded");
		}

		mainPage.ClickCreatePlaylistButton();

		if (!libPage.IsPageLoaded())
		{
			Logger.Error("Failed to load Library Page");
			Assert.Fail("Library Page is not loaded");
		}

		var isPlaylistCreated = libPage.isPlaylistCreated();

		Logger.Information("Playslist Created");

		libPage.EditPlaylistDetails();
		libPage.RenamePlaylist(newPlaylistName);
		Console.ReadLine();



	}
}

