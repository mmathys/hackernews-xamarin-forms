using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

		void Handle_Clicked(object sender, EventArgs e)
		{
			ListViewItems.Add("new item");
		}
	}
}
