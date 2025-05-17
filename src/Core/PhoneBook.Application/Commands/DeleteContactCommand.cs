using PhoneBook.Domain.Interfaces.Cqrs;

namespace PhoneBook.Application.Commands;

public record DeleteContactCommand(Guid Id, bool TrackChanges) : ICommand;