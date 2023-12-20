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
    public class ShoppingCart
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        [ForeignKey("BookId")]
        [ValidateNever]
        public Book Book { get; set; }
        [Range(1, 1000, ErrorMessage = "Enter a value between 1 and 1000")]
        public int Count {  get; set; }

        public string AppUserId {  get; set; }
        [ForeignKey("AppUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

        [NotMapped]
        public double Price { get; set; }

    }
}
