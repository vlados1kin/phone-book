using PhoneBook.Application.DTO;
using PhoneBook.Domain.Interfaces.Cqrs;

namespace PhoneBook.Application.Queries;

public record GetAllContactsQuery(bool TrackChanges) : IQuery<IEnumerable<ContactResponseDto>>;
