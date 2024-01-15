using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public enum Priority
    {
        Low,
        High,
        Critical
    }
    public class Priorities
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Priority { get; set; }
        public string File_Path { get; set; }
    }
}

        