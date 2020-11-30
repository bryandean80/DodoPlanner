using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DodoPlanner.Models
{
    public class Category
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public Guid Id { get; set; }

        public Category()
        {
            Id = Guid.NewGuid();
            Name = "New Category";
            Color = "#FFFFFF";
        }
    }
}
