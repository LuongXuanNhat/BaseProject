﻿using BaseProject.Data.Entities;
using BaseProject.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.ViewModels.Catalog.Post
{
    public class PostVm
    {
        public int PostId { get; set; }

        public Guid UserId { get; set; }
        public string? UserName { get; set; }
        public int? CountComment { get; set; }
        public int? CountSave { get; set; }
        public int? CountLike { get; set; }
        public int? checkLock { get; set; }
        public string Title { get; set; }
        public string? Content { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public int View { get; set; }
        public List<string>? Categories { get; set; }
        


    }
}
