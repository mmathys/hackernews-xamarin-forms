using System;
using Newtonsoft.Json;


public class HackerNewsItem
{
	public int Id { get; set; }
	public bool Deleted { get; set; }
	public string Type { get; set;}
	public string by { get; set; }
	public int time { get; set;}
	public string text { get; set; }
	public bool dead { get; set; }
	public object parent { get; set; }
	public object kids { get; set; }
	public string url { get; set; }
	public int score { get; set; }
	public string title { get; set; }
	public object parts { get; set; }
	public int descendants { get; set; }
	public HackerNewsItem() { }
}
