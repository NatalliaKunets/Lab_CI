﻿using NUnit.Framework;
using Project.Core.Logging;
using Project.Core.UI.PageObjects.Pages;

namespace Project.Tests.UI;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
[Parallelizable(ParallelScope.Children)]
public class RecommendedSection : BaseUITest
{
    [Test]
    public void FirstRecommendedPlaylistIsOpened_WhenClicked()
    {
        Logger.Information("Starting Test First Recommended Playlist Is Opened When Clicked");

        RecommendedPage recommendedPage = new(Driver!);

        if(!recommendedPage.IsPageLoaded())
        {
            Logger.Error("Failed to load Recommended Page");
            Assert.Fail("Failed to load Recommended Page");
            return;
        }

        Logger.Information("Recommended Page is loaded successfully.");

        recommendedPage.ClickFirstPlaylist();
        
        Logger.Information("The First Playlist is clicked.");

        PlaylistPage playlistPage = new(Driver!);
        
        Assert.That(playlistPage.IsPageLoaded(), Is.True, "The playlist was not opened as expected.");

        Logger.Information("Test First Recommended Playlist Is Opened When Clicked executed.");
    }
}
