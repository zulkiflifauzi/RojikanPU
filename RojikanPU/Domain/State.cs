﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RojikanPU.Domain
{
    [Table("States")]
    public class State
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AreaCode { get; set; }

        [Required]
        public string Title { get; set; }
        
        public double? Latitude { get; set; } 

        public double? Longitude { get; set; }

        private ICollection<int> _cityIds;
        [NotMapped]
        public ICollection<int> CityIds
        {
            get { return _cityIds ?? (_cityIds = Cities.Select(s => s.Id).ToList()); }
            set { _cityIds = value; }
        }

        private ICollection<City> _cities;
        public virtual ICollection<City> Cities
        {
            get { return _cities ?? (_cities = new Collection<City>()); }
            set { _cities = value; }
        }
        
    }
}