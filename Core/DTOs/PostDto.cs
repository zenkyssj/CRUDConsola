﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class PostDto
    {
        public int Id { get; set;}
        public int UserId { get; set;}
        public string? Title { get; set;}
        public string? Body { get; set;}
    }
}
