using PhoneBook.Application.DTO;
using PhoneBook.Application.Mapper;
using PhoneBook.Domain.Entities;
using PhoneBook.Domain.Interfaces;
using PhoneBook.Domain.Interfaces.Cqrs;

namespace PhoneBook.Application.Commands;

public class CreateContactCommandHandler(IUnitOfWork unitOfWork, MapperRegistry mapper) : ICommandHandler<CreateContactCommand, ContactResponseDto>
{
    public async Task<ContactResponseDto> ExecuteAsync(CreateContactCommand command, CancellationToken cancellationToken)
    {
        var contact = mapper.Map<ContactRequestDto, Contact>(command.ContactRequestDto);

        await unitOfWork.Contact.CreateAsync(contact, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return mapper.Map<Contact, ContactResponseDto>(contact);
    }
}