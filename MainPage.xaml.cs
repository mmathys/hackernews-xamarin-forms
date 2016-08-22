using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace HackerNewsXamarinForms
{
	public partial class MainPage : ContentPage
	{
		public ObservableCollection<string> ListViewItems { get; set; }
		public bool IsLoading { get; private set; }
		public HttpClient client;
		public MainPage()
		{
			this.IsLoading = true;
			InitializeComponent();
			ListViewItems = new ObservableCollection<string> {};
			postsView.ItemsSource = ListViewItems;

			//ListViewItems.Add("hi there testing");

			doPostFetching();
		}

		async void doPostFetching()
		{
			client = new HttpClient();
			Task<string> getStringTask = client.GetStringAsync("https://hacker-news.firebaseio.com/v0/topstories.json");

			string urlContents = await getStringTask;

			int[] postIds = JsonConvert.DeserializeObject<int[]>(urlContents);

			Debug.WriteLine("before awaiting.");

			await Task.WhenAll(postIds.Select(i => getDetail(this, i)));

			Debug.WriteLine("all completed");

			indicator.SetValue(ActivityIndicator.IsVisibleProperty, false);
		}

		public async Task<HackerNewsItem> getDetail(MainPage instance, int itemId)
		{
			string detailUrl = "https://hacker-news.firebaseio.com/v0/item/" + itemId + ".json";
			Task<string> getDetailTask = client.GetStringAsync(detailUrl);
			try
			{
				string urlContents = await getDetailTask;
				HackerNewsItem item = JsonConvert.DeserializeObject<HackerNewsItem>(urlContents);
				ListViewItems.Add(item.title);
				return item;
			}
#pragma warning disable RECS0022 // A catch clause that catches System.Exception and has an empty body
			catch (Exception e)
#pragma warning restore RECS0022 // A catch clause that catches System.Exception and has an empty body
			{
				return null;
			}
		}
	}
}
