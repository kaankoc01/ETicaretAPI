﻿using ETicaretAPI.Domain.Entitites.Common;

namespace ETicaretAPI.Domain.Entitites
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public long Price { get; set; }
        // çoka çok ilişki burada order'ı , orderda productı
        public ICollection<Order> Orders { get; set; }
         

    }
}
