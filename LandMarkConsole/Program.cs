using System;
using LandMarkApi.Repository;

namespace LandMarkConsole
{
    class Program
    {
        static void Main(string[] args)
        {
	        var queryString =
		        "fullname=Jamal%20Fanaian&oauth_token=72157626318069415-087bfc7b5816092c&oauth_token_secret=a202d1f853ec69de&user_nsid=21207597%40N07&username=jamalfanaian";


			var moo = new PersonRepo().SavePersonFromQueryString(queryString);
            Console.WriteLine("Hello World!");
        }
    }
}
