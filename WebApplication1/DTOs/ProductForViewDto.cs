﻿namespace WebApplication1.DTOs
{
    public sealed class ProductForViewDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Count { get; set; }
        public double Price { get; set; }
        public string Caregory { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string WrapperImage { get; set; } = string.Empty;
        public string Composition { get; set; } = string.Empty;
        public string[] Images { get; set; } = new string[0];
    }
}
