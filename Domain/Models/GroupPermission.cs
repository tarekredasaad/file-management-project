using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class GroupPermission
    {
        public int Id { get; set; }
        //[ForeignKey("Group")]
        //public int GroupId { get; set; }
        //public Group Group { get; set; }
        [ForeignKey("Permission")]
        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
