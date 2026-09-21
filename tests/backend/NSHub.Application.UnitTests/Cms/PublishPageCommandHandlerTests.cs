// <copyright file="PublishPageCommandHandlerTests.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.UnitTests.Cms;

using Moq;
using NSHub.Application.Cms.Commands.PublishPage;
using NSHub.Domain.Cms.Entities;
using NSHub.Domain.Cms.Enums;
using NSHub.Domain.Cms.Repositories;
using NSHub.Domain.Cms.ValueObjects;
using NSHub.Domain.Common;

public class PublishPageCommandHandlerTests
{
    private readonly Mock<ICmsRepository> cmsRepositoryMock = new();
    private readonly Mock<IUnitOfWork> unitOfWorkMock = new();
    private readonly PublishPageCommandHandler handler;

    public PublishPageCommandHandlerTests()
    {
        handler = new PublishPageCommandHandler(
            cmsRepositoryMock.Object,
            unitOfWorkMock.Object);
    }

    [Fact]
    public async Task Handle_WhenPageNotFound_ShouldReturnNotFound()
    {
        // Arrange
        var pageId = Guid.NewGuid();
        _ = cmsRepositoryMock.Setup(r => r.GetByIdAsync(new PageId(pageId), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Page?)null);

        // Act
        var result = await handler.Handle(new PublishPageCommand(pageId), CancellationToken.None);

        // Assert
        _ = result.IsSuccess.Should().BeFalse();
        _ = result.Error.Code.Should().Be("Page.NotFound");
    }

    [Fact]
    public async Task Handle_WithValidPage_ShouldPublishSuccessfully()
    {
        // Arrange
        var pageId = Guid.NewGuid();
        var page = new Page(new PageId(pageId), "Press Release", "press-release", "# Important news", "Summary", Guid.NewGuid());

        _ = cmsRepositoryMock.Setup(r => r.GetByIdAsync(new PageId(pageId), It.IsAny<CancellationToken>()))
            .ReturnsAsync(page);

        // Act
        var result = await handler.Handle(new PublishPageCommand(pageId), CancellationToken.None);

        // Assert
        _ = result.IsSuccess.Should().BeTrue();
        _ = result.Value.Status.Should().Be(PublishingStatus.Published.ToString());
        _ = result.Value.PublishedAtUtc.Should().NotBeNull();
        cmsRepositoryMock.Verify(r => r.Update(page), Times.Once);
        unitOfWorkMock.Verify(u => u.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}
