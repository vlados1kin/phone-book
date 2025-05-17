using PhoneBook.Application.DTO;
using PhoneBook.Domain.Interfaces.Cqrs;

namespace PhoneBook.Application.Queries;

public record GetContactByIdQuery(Guid Id, bool TrackChanges) : IQuery<ContactResponseDto>;