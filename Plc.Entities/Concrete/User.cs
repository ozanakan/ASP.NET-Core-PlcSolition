﻿using Plc.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Plc.Entities.Concrete
{
    public class User :IdentityUser<int> /* IEntity*/
    {
        //public int Id { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string UserName { get; set; }
        //public string Email { get; set; }
        //public byte[] PasswordHash { get; set; }
        //public int RoleId { get; set; }
        //public Role Role { get; set; }


    }
}
