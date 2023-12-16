using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LXxUS.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        [Required]
        public int OrderHeadID { get; set; }
        [ForeignKey("OrderHeadID")]
        [ValidateNever]
        public OrderHeader OrderHeader { get; set; }


        [Required]
        public int BookID { get; set; }
        [ForeignKey("BookID")]
        [ValidateNever]
        public Book Book { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
    }
}
