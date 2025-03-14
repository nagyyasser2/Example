using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Core.Enums;

namespace Example.Core.Models
{
    public class UserPermission
    {
        public int UserId { get; set; }
        public Permission PermissionId { get; set; }
    }
}
