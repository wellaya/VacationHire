﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationHire.Domain.Entities;
public class Customer : BaseEntity<int>
{
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
}
