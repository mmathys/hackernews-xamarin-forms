using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HackerNewsXamarinForms
{
	public partial class DetailPage : ContentPage
	{
		public object _bindingContext;
		public HackerNewsItem item;
		public ObservableCollection<HackerNewsItem> comments;
		public DetailPage(HackerNewsItem item)
		{
			this.Title = item.title;
			this.BindingContext = item;
			this.item = item;
			this.comments = new ObservableCollection<HackerNewsItem>();
			comments.Add(new HackerNewsItem { text = "ay" });
			InitializeComponent();
			commentsView.ItemsSource = this.comments;
			doAsyncWork();
		}

		async void doAsyncWork()
		{
			int[] commentIds = item.kids;
			await Task.WhenAll(commentIds.Select(i => getComment(this, i)));
			Debug.WriteLine("all async comment work done");
		}

		async Task<HackerNewsItem> getComment(DetailPage detailPage, int i)
		{
			Debug.WriteLine("in getComment at thestart");
			HackerNewsItem item = await MainPage.getDetail(detailPage, i);
			this.comments.Add(item);
			Debug.WriteLine("in getComment at theend");
			Debug.WriteLine("added comment with text "+item.text);
			return item;
		}
	}
}
