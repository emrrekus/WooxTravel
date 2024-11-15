﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WooxTravel.Entities
{
    public class Reservation
    {

        public int ReservationId { get; set; }

       
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int PersonCount { get; set; }
        public int ResarvationPrice { get; set; }
        public DateTime ReservastionDate { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Description { get; set; }

        public string Tour {  get; set; }
    }
}