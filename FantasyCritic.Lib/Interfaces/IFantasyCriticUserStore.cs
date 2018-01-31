﻿using System;
using System.Collections.Generic;
using System.Text;
using FantasyCritic.Lib.Domain;
using Microsoft.AspNetCore.Identity;

namespace FantasyCritic.Lib.Interfaces
{
    public interface IFantasyCriticUserStore : IUserStore<FantasyCriticUser>, IUserEmailStore<FantasyCriticUser>, IUserPhoneNumberStore<FantasyCriticUser>,
        IUserTwoFactorStore<FantasyCriticUser>, IUserPasswordStore<FantasyCriticUser>, IUserRoleStore<FantasyCriticUser>
    {
    }
}