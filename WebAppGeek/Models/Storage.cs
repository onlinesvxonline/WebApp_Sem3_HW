﻿namespace WebAppGeek.Models
{
    public class Storage
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
