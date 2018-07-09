# LandMarkApi

In order to run this application you need to have the latest Visual Studio installed or atleast the sdk for dotnet core 2.1

Additionally you will also need to get the osbscure packages for DotNetCore App 2.1.0-preview1-final

Ensure that you have the entity framework CLI installed.
Before the proejct will work, allow the code first migrations to run. 
  From the CLI
    - Navigate to the the LandMarkAPI.Data
    - run the command "dotnet ef database update

# Exposed Endpoints
- /ListLocations/SearchLocationsBYKeyword?
  - params
    - where(string) eg. ?where=germany
  - description
    - To get a list of locations, we will hit the flicker server and request locations around a certain keyword. This logic is at the mercy of the tags being used by flickr.
  - result 
      - ` {
        "nz.gsghTUb4c2WAecA": "USA",
        "6iR08ndQU7sKvZ4I": "Usa, Oita Prefecture, Japan",
        "RhRwAGpTWrkeWlBLWA": "Awa-shi, Tokushima Prefecture, Japan",
        "zEO6RdNTWr7plXg.rQ": "Usa, Japan",
        "nCrUgyZZUbhWobg": "Usa, Minskaya Voblasts', Belarus",
        "45mR65RYUrxIg3QovA": "Уса, Kemerovo Oblast, Russia",
        "uq012LtYUr.xq1Yepg": "Уса, Kirov Oblast, Russia",
        "hPmOjt1YUr96LI5MKQ": "Уса, Komi Republic, Russia",
        "sHBZQ69TWrnj2GoYww": "Usa, South Sulawesi, Indonesia",
        "_T0gX45TVr_XwARs": "Mobile, Alabama, United States",
        "nRsMTC1UV7PmWRPnXA": "USA, Mobile, AL, United States",
        "W8E8CXpYUry7GP8.GQ": "Уса, Bashkortostan Republic, Russia",
        "tu6aqXxWU7JLNN0": "Miramare, Emilia Romagna, Italy",
        "EMo2gYtTUb7oiO66": "Texas, United States",
        "h7eZVDlTUb50Btij9Q": "Germany",
        "5pzQtV1TVrpPz8Iy": "Germany, New Florence, PA, United States",
        "yb1OdHZTVroSPYB.": "Germany, Clayton, GA, United States",
        "UUU.pnpTUb7KHEfH": "Ohio, United States",
        "8M8WMPxUV7KD2._AMw": "Germany, United States",
        "4PwpnylUVLwxPyRCUw": "Germany, New Brunswick, Canada"
    }`
- /ListLocations/GetImageListByLocationId?
  - params
    - place_id(string) eg ?place_id=zEO6RdNTWr7plXg.rQ
    - place_id would be the key value of one of the rows in "SearchlocationsByKeyword" endpoint
  - Description
     - To get the list of images from the flickr server based on the key returned from one of the keys retrieved from your initial request. if you use ?place_id=zEO6RdNTWr7plXg.rQ you will get 10 images from that location (japan in this example)
  - result
    - `{
        "8695808553": "https://farm9.staticflickr.com/8254/8695808553_bf51a2892c.jpg",
        "40942324990": "https://farm1.staticflickr.com/880/40942324990_826c294b0b.jpg",
        "40942323030": "https://farm2.staticflickr.com/1725/40942323030_765f647a67.jpg",
        "28879612718": "https://farm2.staticflickr.com/1737/28879612718_58de59cd7f.jpg",
        "28879609578": "https://farm2.staticflickr.com/1735/28879609578_8b6a6be418.jpg",
        "28879608208": "https://farm1.staticflickr.com/899/28879608208_13fb4b7c2e.jpg",
        "28879605548": "https://farm2.staticflickr.com/1728/28879605548_97941bc52e.jpg",
        "28879603778": "https://farm1.staticflickr.com/875/28879603778_2cb4309440.jpg",
        "27532858257": "https://farm2.staticflickr.com/1749/27532858257_6d3612e1ba.jpg",
        "27532857657": "https://farm2.staticflickr.com/1750/27532857657_2aa79ca097.jpg",
        "42559410961": "https://farm2.staticflickr.com/1747/42559410961_21bd429fdc.jpg"
    }`
  
- /ImageDetail/GetImageDetail?
  - parmas
    - flickrPhotoId eg. ?flockrPhotoId=8695808553
      - flickrPhotoId would be the key from one of the returned results in the previous request. 
  - Description
    - To get the image information based on the key retrieved from the previous request. This is watered down and flattened into a reasonable format.
  - result
    - `{
            "photoDetailId": 3,
            "flickrPhotoId": 40942324990,
            "secret": "826c294b0b",
            "server": 880,
            "farm": 1,
            "dateUploaded": null,
            "isFavorite": false,
            "license": 0,
            "rotation": 0,
            "originalSecret": "08a3f958e0",
            "originalFormat": "jpg",
            "views": 17,
            "title": "YONE8573",
            "decription": "",
            "media": "photo"
        }
    `
