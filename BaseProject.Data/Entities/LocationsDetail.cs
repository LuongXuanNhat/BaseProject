﻿using BaseProject.Data.Entities;
using BaseProject.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace BaseProject.Data.Entities
{
    public class LocationsDetail
    {
        

        public int Id { get; set; }
        public int LocationId { get; set; }
        public int PostId { get; set; }
        public string Title { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime When { get; set; }
        public string Content { get; set; }


        // Relationship
        public Post Post { get; set; }
        public Location Location { get; set; }
        public List<Image> Image { get; set; }


        // Contructor
        public LocationsDetail( int locationId, int postId, string title, DateTime when, string content)
        {
            LocationId = locationId;
            PostId = postId;
            When = when;
            Content = content;
            Title = title;
        }
        public LocationsDetail(int ID, int locationId, int postId, string title, DateTime when, string content)
        {
            Id = ID;
            LocationId = locationId;
            PostId = postId;
            When = when;
            Content = content;
            Title = title;
        }
    }
}
