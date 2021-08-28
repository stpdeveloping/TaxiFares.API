﻿using Microsoft.EntityFrameworkCore;
using TaxiFares.API.Domain.Aggregates.CompanyAggregate;

namespace TaxiFares.API.Infrastructure.EntityTypeConfigurations
{
    public interface IFaresConfiguration :
        IEntityTypeConfiguration<Fares>
    {
    }
}
