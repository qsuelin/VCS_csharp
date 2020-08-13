using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VCS.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Empty Tag")]
        [StringLength(50)]
        public string Name { get; set; }

        public List<Video> Videos { get; set; }


        public Tag(string name)
        {
            Name = name;
        }

        public Tag()
        {
        }
    }
}
