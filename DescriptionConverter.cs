using System;
using System.Globalization;
using Xamarin.Forms;

namespace HackerNewsXamarinForms
{
	public class DescriptionConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			HackerNewsItem item = (HackerNewsItem)value;
			return item.score + " points by " + item.by + " | " + item.descendants + " comments";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return true;
		}
	}
}
