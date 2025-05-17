using PhoneBook.Application.DTO;
using PhoneBook.Domain.Interfaces.Cqrs;

namespace PhoneBook.Application.Commands;

public record CreateContactCommand(ContactRequestDto ContactRequestDto) : ICommand<ContactResponseDto>;