namespace PhoneBook.Domain.Interfaces.Cqrs;

public interface ICommandHandler<in TCommand, TResponse> where TCommand : ICommand<TResponse>
{
    Task<TResponse> ExecuteAsync(TCommand command, CancellationToken cancellationToken);
}

public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
    Task ExecuteAsync(TCommand command, CancellationToken cancellationToken);
}