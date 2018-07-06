using LandMarkAPI.Domain.Entities.Flickr;

namespace LandMarkAPI.Domain.DTO.Recieve
{
    public class PhotoContainer
    {
	    public PhotoDetailObj photo { get; set; }
	    public string stat { get; set; }
    }

	public class PhotoDetailObj
	{
		public string id { get; set; }
		public string secret { get; set; }
		public int server { get; set; }
		public int farm { get; set; }
		public int dateuploaded { get; set; }
		public bool isfavorite { get; set; }
		public int license { get; set; }
		public int safety_level { get; set; }
		public int rotation { get; set; }
		public string originalsecret { get; set; }
		public string originalformat { get; set; }
		public int views { get; set; }
		public ContentOject title { get; set; }
		public ContentOject description { get; set; }
		public string media { get; set; }
	}

	public class PhotoDetailOwner
	{
		public string nsid { get; set; }
		public string username { get; set; }
		public string realname { get; set; }
		public string location { get; set; }
		public string iconserver { get; set; }
		public string iconfarm { get; set; }
		public string path_alias { get; set; }
	}

	public class ContentOject
	{
		public string _content { get; set; }
	}
}