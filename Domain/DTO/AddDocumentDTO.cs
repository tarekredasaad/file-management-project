using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class AddDocumentDTO
    {
        public string Name { get; set; }
        //public string PriorityName { get; set; }
        public string PriorityLevel { get; set; }
        public IFormFile? File_Path { get; set; }
        public DateTime CreatedDate = DateTime.Now;
    }
}
