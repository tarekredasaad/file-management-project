using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class DocumentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PriorityName { get; set; }
        public Guid userId { get; set; }
        public string PriorityLevel { get; set; }
        public string? File_Path { get; set; }
        public DateTime Due_Date { get; set; }
    }
}
