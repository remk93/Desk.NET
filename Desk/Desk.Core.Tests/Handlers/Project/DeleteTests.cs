﻿using BA.Core.Functional.Tests.Handlers.Team.Fakers.Project;
using Desk.Shared.Exceptions;
using Desk.Core.Functional.Tests.Fixtures;
using Desk.Core.Handlers.Project.Commands;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Desk.Core.Tests.Handlers.Project;

[Collection(nameof(SliceFixture))]

public class DeleteTests
{
    private readonly SliceFixture _fixture;

    public DeleteTests(SliceFixture fixture) => _fixture = fixture;

    [Fact]
    public async Task Delete_ProjcetModel()
    {
        var createdCommand = new Faker().FakeCreateCommand();
        var created = await _fixture.SendAsync(createdCommand);

        var result = await _fixture.SendAsync(new DeleteCommand { Id = created.Id });

        await Should.ThrowAsync<NotFoundException>(() => _fixture.SendAsync(new GetCommand { Id = created.Id }));
    }

    [Theory]
    [InlineData(0)]
    public async Task Get_ValidationExcecption_On_Not_Zero_Id(int id)
    {
        var command = new Faker().FakeCreateCommand();
        var created = await _fixture.SendAsync(command);

        await Should.ThrowAsync<ValidationException>(() => _fixture.SendAsync(new DeleteCommand { Id = id }));
    }
}
