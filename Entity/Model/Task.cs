﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteMassenger.Entity.Model
{
    public class Task
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Priority { get; set; }
        public int Status { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime DateTime { get; set; }
        

    }
}
