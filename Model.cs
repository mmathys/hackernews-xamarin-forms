using System;
using System.Collections.ObjectModel;

namespace HackerNewsXamarinForms
{
	public static class Model
	{
		public static ObservableCollection<Post> data { get; set; }

		static Model()
		{
			data = getData();
		}

		public static ObservableCollection<Post> getData()
		{
			ObservableCollection<Post> posts = new ObservableCollection<Post>() {
				new Post("Bedside", "Mel's Bedroom"),
				new Post("Desk", "Mel's Bedroom"),
				new Post("Flood Lamp", "Outside"),
				new Post("hallway1", "Entry Hallway"),
				new Post("hallway2", "Entry Hallway")
			};
			return posts;
		}
	}
}
