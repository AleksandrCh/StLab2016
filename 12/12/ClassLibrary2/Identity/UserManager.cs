﻿using Domain.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Identity
{
    public class UserManager : UserManager<User>
    {
        public UserManager(IUserStore<User> store)
                : base(store)
        {
        }
    }
}
