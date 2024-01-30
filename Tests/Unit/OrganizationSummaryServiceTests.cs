using Application.Dto;
using Application.Interfaces;
using Application.Services;
using Moq;
using Tests.Data;

namespace Tests.Unit;

public class OrganizationSummaryServiceTests
{
    private readonly OrganizationSummaryService _organizationSummary;
    private readonly Mock<IExternalDataProvider> _mockProvider;

    public OrganizationSummaryServiceTests()
    {
        _mockProvider = new Mock<IExternalDataProvider>();

        _mockProvider.Setup(m => m.GetExternalData())
            .ReturnsAsync(() => OrganizationSummaryDto.Create(
                MockData.MockOrganizationDtos(),
                MockData.MockUserDtos(),
                MockData.MockPhoneDtos(
                )));
        _organizationSummary = new OrganizationSummaryService(_mockProvider.Object);
    }

    [Fact]
    public async Task GetAllSummaries_WithExternalData_ReturnsOrganizationSummaries()
    {
        var summaries = await _organizationSummary.GetAllSummaries();

        Assert.NotNull(summaries);
        Assert.Equal(8,summaries.Count());

        var firstEntry = summaries.ElementAt(0);
        var secondEntry = summaries.ElementAt(1);

        Assert.Equal("Mrs. Sasha Jakubowski", firstEntry.Name);
        Assert.Equal(3, firstEntry.TotalCount);
        Assert.Equal(2, firstEntry.BlacklistTotal);
        Assert.Equal(1, firstEntry.Users?.Count() ?? 0);

        Assert.Empty(secondEntry.Users!);
        Assert.Equal(0, secondEntry.TotalCount);
        Assert.Equal(0, secondEntry.BlacklistTotal);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task GetAllSummaries_WithNullOrEmptyOrganizations_ReturnEmptyEnumerable(bool isNullOrganizations)
    {
        var mockOrgs = isNullOrganizations ? null : Enumerable.Empty<OrganizationDto>();

        _mockProvider.Setup(m => m.GetExternalData())
            .ReturnsAsync(() => OrganizationSummaryDto.Create(
                mockOrgs!,
                MockData.MockUserDtos(),
                MockData.MockPhoneDtos()));

        var summaries = await _organizationSummary.GetAllSummaries();
        Assert.Empty(summaries);
    }

    [Fact]
    public async Task GetAllSummaries_WithExternalDataException_Throws()
    { 
        _mockProvider.Setup(m => m.GetExternalData())
            .ThrowsAsync(new HttpRequestException());

        await Assert.ThrowsAsync<HttpRequestException>(_organizationSummary.GetAllSummaries);
    }
}