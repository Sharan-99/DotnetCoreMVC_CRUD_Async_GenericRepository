using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
namespace DotnetCoreMVC_CRUD_Async_GenericRepository.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, StringLength(20)]
        public string Name { get; set; }

        [Range(1, 10000)]
        public int Price { get; set; }
    }
}
