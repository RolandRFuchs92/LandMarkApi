using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LandMarkAPI.Domain.Models.OAuth;

namespace LandMarkAPI.Authentication
{
    public class ParseResponse
    {
	    public Dictionary<string,string> ParseTokenConfirmationReponse(string responseText)
	    {
		    return responseText.Split('&').ToDictionary(key => key.Split('=')[1], val => val.Split('=')[1]);
	    }
    }
}
