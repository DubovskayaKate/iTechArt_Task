namespace App.Entities
{
    public class YoutubeItem
    {
        public string ImageUrlMedium;
        public string ImageUrlHigh;
        public string ImageUrlDefault;
        public string Title;
        public string Description;
        public string Id;

        public YoutubeItem(string imageUrlMedium,
            string imageUrlHigh, string imageUrlDefault,
            string title, string description, string id)
        {
            this.Description = description;
            this.Id = id;
            this.ImageUrlDefault = imageUrlDefault;
            this.ImageUrlHigh = imageUrlDefault;
            this.ImageUrlMedium = imageUrlMedium;
            this.Title = title;
        }


    }
}