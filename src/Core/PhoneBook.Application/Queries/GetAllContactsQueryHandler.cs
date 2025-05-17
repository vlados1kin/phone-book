using PhoneBook.Application.DTO;
using PhoneBook.Application.Mapper;
using PhoneBook.Domain.Entities;
using PhoneBook.Domain.Interfaces;
using PhoneBook.Domain.Interfaces.Cqrs;

namespace PhoneBook.Application.Queries;

public class GetAllContactsQueryHandler(IUnitOfWork unitOfWork, MapperRegistry mapper) : IQueryHandler<GetAllContactsQuery, IEnumerable<ContactResponseDto>>
{
    public async Task<IEnumerable<ContactResponseDto>> ExecuteAsync(GetAllContactsQuery query, CancellationToken cancellationToken)
    {
        var contacts = await unitOfWork.Contact.GetAllContactsAsync(query.TrackChanges, cancellationToken);

        return contacts.Select(mapper.Map<Contact, ContactResponseDto>).ToList();
    }
}