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
		public ObservableCollection<HackerNewsItem> HackerNewsItems { get; set; }
		public bool IsLoading { get; private set; }
		public static HttpClient client = new HttpClient();
		public MainPage()
		{
			this.IsLoading = true;
			this.Title = "Hacker News Xamarin.Forms";
			InitializeComponent();
			ListViewItems = new ObservableCollection<string> {};
			HackerNewsItems = new ObservableCollection<HackerNewsItem> { };
			postsView.ItemsSource = ListViewItems;
			postsView.ItemSelected += PostClicked;
			doPostFetching();
		}

		async void PostClicked(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem != null)
			{
				string name = e.SelectedItem.ToString();
				int index = ListViewItems.IndexOf(name);
				if (index >= -1)
				{
					//Debug.WriteLine("index is "+index+", name is "+name);
					HackerNewsItem item = HackerNewsItems[index];
					await Navigation.PushAsync(new DetailPage(item));
				}
				else
				{
					Debug.WriteLine("index is -1");
				}
			}
		}

		async void doPostFetching()
		{
			Task<string> getStringTask = client.GetStringAsync("https://hacker-news.firebaseio.com/v0/topstories.json");

			string urlContents = await getStringTask;

			int[] postIds = JsonConvert.DeserializeObject<int[]>(urlContents);

			Debug.WriteLine("before awaiting.");

			await Task.WhenAll(postIds.Select(i => processPost(this, i)));

			Debug.WriteLine("all completed");

			indicator.SetValue(ActivityIndicator.IsVisibleProperty, false);
		}

		async Task processPost(MainPage mainPage, int i)
		{
			HackerNewsItem item = await getDetail(mainPage, i);
			ListViewItems.Add(item.title);
			HackerNewsItems.Add(item);
		}

		public static async Task<HackerNewsItem> getDetail(ContentPage instance, int itemId)
		{
			string detailUrl = "https://hacker-news.firebaseio.com/v0/item/" + itemId + ".json";
			Task<string> getDetailTask = client.GetStringAsync(detailUrl);
			try
			{
				string urlContents = await getDetailTask;
				HackerNewsItem item = JsonConvert.DeserializeObject<HackerNewsItem>(urlContents);
				return item;
			}
#pragma warning disable RECS0022 // A catch clause that catches System.Exception and has an empty body
			catch (Exception e)
#pragma warning restore RECS0022 // A catch clause that catches System.Exception and has an empty body
			{
				Debug.WriteLine(e.GetBaseException().ToString());
				return new HackerNewsItem { text="none"};
			}
		}
	}
}
