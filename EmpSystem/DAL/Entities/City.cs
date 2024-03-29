﻿using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpSystem.DAL.Entities
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]

        public Country Country { get; set; }
        public Collection<District> District { get; set; }

    }
}
