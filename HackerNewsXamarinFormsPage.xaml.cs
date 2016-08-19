using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using System.Net.Http;

namespace HackerNewsXamarinForms
{
	public partial class HackerNewsXamarinFormsPage : INotifyPropertyChanged
	{
		public bool IsLoading { get; set; }
		public HackerNewsXamarinFormsPage()
		{
			this.IsLoading = true;
			this.BindingContext = new[] { "a", "b", "c" };

			InitializeComponent();

			doAsyncWork();
		}

		private async Task<int> doAsyncWork()
		{
			var httpClient = new HttpClient();

			Task<string> contentsTask = httpClient.GetStringAsync("https://hacker-news.firebaseio.com/v0/topstories.json"); // async method!

			string contents = await contentsTask;

			var json = (JObject)JsonConvert.DeserializeObject(contents);

			//TODO

			return contents.Length;

		}
	}
}

