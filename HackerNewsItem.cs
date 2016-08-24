using System;
using System.Diagnostics;
using System.Globalization;
using Newtonsoft.Json;
using Xamarin.Forms;

public class HackerNewsItem
{
	public int id { get; set; }
	public bool deleted { get; set; }
	public string type { get; set; }
	public string by { get; set; }
	public int time { get; set; }
	public string text { get; set; }
	public bool dead { get; set; }
	public object parent { get; set; }
	public int[] kids { get; set; }
	public string url { get; set; }
	public int score { get; set; }
	public string title { get; set; }
	public object parts { get; set; }
	public int descendants { get; set; }
	public HackerNewsItem() { }

	public string description
	{
		get
		{
			string ret;
			if (this.score >= 0 && this.by != null && this.descendants >= 0)
			{
				ret = this.score + " points by " + this.by + " | " + this.descendants + " comments";
			}
			else {
				ret = "something is null";
			}
			Debug.WriteLine("returning " + ret);
			return ret;
		}
		set
		{ }
	}

}