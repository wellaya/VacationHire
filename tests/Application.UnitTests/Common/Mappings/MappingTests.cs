using System.Runtime.Serialization;
using AutoMapper;
using VacationHire.Application.Common.Mappings;
using VacationHire.Application.Common.Models;
using VacationHire.Domain.Entities;
using NUnit.Framework;

namespace VacationHire.Application.UnitTests.Common.Mappings;

public class MappingTests
{
    private readonly IConfigurationProvider _configuration;
    private readonly IMapper _mapper;

    public MappingTests()
    {
        _configuration = new MapperConfiguration(config => 
            config.AddProfile<MappingProfile>());

        _mapper = _configuration.CreateMapper();
    }

    [Test]
    public void ShouldHaveValidConfiguration()
    {
        _configuration.AssertConfigurationIsValid();
    }

    
}
