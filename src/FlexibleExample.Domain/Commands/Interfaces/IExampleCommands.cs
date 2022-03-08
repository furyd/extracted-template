using FlexibleExample.Domain.Commands.Models;

namespace FlexibleExample.Domain.Commands.Interfaces;

public interface IExampleCommands
{
    void ExampleCommand(ExampleModel model);
}