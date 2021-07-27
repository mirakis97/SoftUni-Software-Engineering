﻿namespace _02.Data.Models
{
    public class Invoice : BaseEntity
    {
        public Invoice(int id, int? parentId)
            : base(id, parentId)
        {
        }

        public string Description { get; set; }

        public int PriceCents { get; set; }
    }
}
