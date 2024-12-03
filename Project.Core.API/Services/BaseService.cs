using RestSharp;
using Project.Core.API.Managers;
using Project.Core.Logging;

namespace Project.Core.API.Services;

public abstract class BaseService
{
	protected readonly ISessionManager SessionManager;
	protected readonly RestClient Client;

	protected BaseService(ISessionManager sessionManager)
	{
		SessionManager = sessionManager;
		Client = sessionManager.RestClient;
	}

	protected RestRequest CreateRequest(string resource, Method method)
	{
		Logger.Information($"Creating request for resource: {resource}, method: {method}");
		var request = SessionManager.RestRequest;
		request.Resource = resource;
		request.Method = method;
		return request;
	}

	protected T ExecuteRequest<T>(RestRequest request) where T : new()
	{
		Logger.Information($"Executing request: {request.Resource}");
		var response = Client.Execute<T>(request);

		if (response.StatusCode != System.Net.HttpStatusCode.OK || response.Data == null)
		{
			Logger.Error($"Request failed: {response.ErrorMessage}");
			throw new InvalidOperationException($"Failed to execute request. Status: {response.StatusCode}, Error: {response.ErrorMessage}");
		}

		return response.Data;
	}
}
