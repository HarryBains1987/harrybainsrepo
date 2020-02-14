using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelAPI
{
    public class Results
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("modified")]
        public string Modified { get; set; }

        [JsonProperty("thumbnail")]
        public Thumbnail Thumbnail { get; set; }

        [JsonProperty("resourceURI")]
        public Uri ResourceUri { get; set; }

        [JsonProperty("comics")]
        public Comics Comics { get; set; }

        [JsonProperty("series")]
        public Comics Series { get; set; }

        [JsonProperty("stories")]
        public Stories Stories { get; set; }

        [JsonProperty("events")]
        public Comics Events { get; set; }

        [JsonProperty("urls")]
        public List<Url> Urls { get; set; }

    }


    public partial class Comics
    {
        [JsonProperty("available")]
        public long Available { get; set; }

        [JsonProperty("collectionURI")]
        public Uri CollectionUri { get; set; }

        [JsonProperty("items")]
        public List<ComicsItem> Items { get; set; }

        [JsonProperty("returned")]
        public long Returned { get; set; }
    }

    public partial class ComicsItem
    {
        [JsonProperty("resourceURI")]
        public Uri ResourceUri { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Stories
    {
        [JsonProperty("available")]
        public long Available { get; set; }

        [JsonProperty("collectionURI")]
        public Uri CollectionUri { get; set; }

        [JsonProperty("items")]
        public List<StoriesItem> Items { get; set; }

        [JsonProperty("returned")]
        public long Returned { get; set; }
    }

    public class StoriesItem
    {
        [JsonProperty("resourceURI")]
        public Uri ResourceUri { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public  class Thumbnail
    {
        [JsonProperty("path")]
        public Uri Path { get; set; }

        [JsonProperty("extension")]
        public string Extension { get; set; }
    }

    public partial class Url
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("url")]
        public Uri UrlUrl { get; set; }
    }

    public enum ItemType { Ad, Backcovers, Cover, Empty, InteriorStory, Pinup, Recap, TextArticle };

    public enum Extension { Gif, Jpg };

    public enum UrlType { Comiclink, Detail, Wiki };
}
