using System;
using System.Collections.Generic;

#nullable disable

namespace CrudMind
{
    public partial class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
