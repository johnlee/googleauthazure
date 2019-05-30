using System;
using System.ComponentModel.DataAnnotations;

namespace GoogleAuthAzure.Models
{
    public class Widget
    {
        public int ID { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
