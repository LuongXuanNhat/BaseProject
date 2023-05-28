﻿using System.ComponentModel.DataAnnotations;

namespace BaseProject.Data.Entities
{
    public class Saved
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int LocationId { get; set; }
        public Guid UserId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }



        // Relationship
        public Post? Post { get; set; }
        public Location? Location { get; set; }
        public AppUser User { get; set; }
    }
}
