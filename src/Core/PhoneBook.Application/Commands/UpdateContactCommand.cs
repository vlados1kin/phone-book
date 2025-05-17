using PhoneBook.Application.DTO;
using PhoneBook.Domain.Interfaces.Cqrs;

namespace PhoneBook.Application.Commands;

public record UpdateContactCommand(Guid Id, ContactRequestDto ContactRequestDto, bool TrackChanges) : ICommand;