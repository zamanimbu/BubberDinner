﻿using BubberDinner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubberDinner.Application.Services.Authintication
{
    public record AuthenticationResult(
        User? User,
        string Token
        );


}
