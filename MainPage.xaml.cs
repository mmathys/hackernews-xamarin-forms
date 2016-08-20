using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HackerNewsXamarinForms
{
	public partial class MainPage : ContentPage
	{
		public ObservableCollection<string> ListViewItems { get; set; }
		public bool IsLoading { get; private set; }
		public MainPage()
		{
			this.IsLoading = true;
			InitializeComponent();
			ListViewItems = new ObservableCollection<string> { "one", "two", "three" };
			postsView.ItemsSource = ListViewItems;
		}
	}
}
