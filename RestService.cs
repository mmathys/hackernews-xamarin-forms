using System;
using System.Net.Http;

namespace HackerNewsXamarinForms
{
	public class RestService
	{
		HttpClient client;

		public RestService()
		{
			client = new HttpClient();

		}
	}
}
