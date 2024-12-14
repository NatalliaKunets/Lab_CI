using NUnit.Framework;

namespace Project.Tests.API;

[TestFixture]
public class UserServiceTests : BaseAPITest
{
	[Test, Category("API")]
	[Ignore("Skip for testing CI/CD")]
	public void GetTopItems_ShouldReturnTopArtists_WhenValidParametersAreProvided()
	{
		string type = "artists";
		string timeRange = "medium_term";
		int limit = 10;
		int offset = 0;

		var result = _userService.GetTopItems(type, timeRange, limit, offset);

		Assert.That(result, Is.Not.Null);
		Assert.That(result.Limit, Is.EqualTo(limit));
		Assert.That(result.Offset, Is.EqualTo(offset));
		Assert.That(result.Total, Is.GreaterThan(0));
		Assert.That(result?.Items?.Count, Is.LessThanOrEqualTo(limit));
		Assert.That(result?.Items, Is.All.Not.Null);
	}
}
