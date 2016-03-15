﻿using System.Runtime.Serialization;

namespace FlickrSearcher.Search
{
    [DataContract]
    public class Photo
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "image")]
        public byte[] Image { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }
    }
}