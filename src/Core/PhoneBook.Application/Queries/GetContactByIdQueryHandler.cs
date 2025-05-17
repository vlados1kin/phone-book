using PhoneBook.Application.DTO;
using PhoneBook.Application.Exceptions;
using PhoneBook.Application.Mapper;
using PhoneBook.Domain.Entities;
using PhoneBook.Domain.Interfaces;
using PhoneBook.Domain.Interfaces.Cqrs;

namespace PhoneBook.Application.Queries;

public class GetContactByIdQueryHandler(IUnitOfWork unitOfWork, MapperRegistry mapper) : IQueryHandler<GetContactByIdQuery, ContactResponseDto>
{
    public async Task<ContactResponseDto> ExecuteAsync(GetContactByIdQuery query, CancellationToken cancellationToken)
    {
        var contact = await unitOfWork.Contact.GetContactByIdAsync(query.Id, query.TrackChanges, cancellationToken);

        if (contact == null)
        {
            throw new NotFoundException(string.Format(ExceptionMessages.ContactWithIdNotFound, query.Id));
        }

        return mapper.Map<Contact, ContactResponseDto>(contact);
    }
}