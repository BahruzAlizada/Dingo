﻿using CoreLayer.Entity;
using System;

namespace EntityLayer.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }

        public string Image { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsDeactive { get; set; }

        public Category Category { get; set; }

    }
}
