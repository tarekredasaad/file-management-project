using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Documents
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("Priority")]
        public int PriorityId { get; set; }
        public Priorities Priority { get; set; }
        public DateTime? Due_Date { get; set; }
    }
}
