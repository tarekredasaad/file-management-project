//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using Index = Microsoft.EntityFrameworkCore.Metadata.Internal.Index;
using System;
using System.Net.Mail;

namespace Domain.Models
{
    //[Index(nameof(productCode), IsUnique = true)]

    public class Product
    {
        public int Id { get; set; }
       
        public string name { get; set; }
     
        public decimal price { get; set; }
        
    }
}
