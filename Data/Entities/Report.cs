﻿using System.ComponentModel.DataAnnotations;

namespace BaseProject.Data.Entities
{
    public class Report
    {
        public int Id { get; set; }
        public int Post_id { get; set; }
        public Guid User_id { get; set; }
        public int AllegedUser_id { get; set; }
        public int Comment_id { get; set; }
        public string Content { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }


        // Relationship
        public Post Post { get; set; }
        public User User { get; set; }
        public User AllegedUser { get; set; }
        public Comment Comment { get; set; }
    }
}
