﻿using VacationHire.Application.Common.Interfaces;

namespace VacationHire.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}