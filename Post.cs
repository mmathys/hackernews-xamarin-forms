using System.ComponentModel;

namespace HackerNewsXamarinForms
{
	public class Post
	{
		private string _name;
		private string _comment;
		public string name { get { return _name; } set { _name = value; } }
		public string comment { get { return _comment; } set { _comment = value; } }

		public Post(string name, string comment) 
		{
			this.name = name;
			this.comment = comment;
		}
	}
}
