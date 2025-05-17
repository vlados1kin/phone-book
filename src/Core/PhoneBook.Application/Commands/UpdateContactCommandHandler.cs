using PhoneBook.Application.DTO;
using PhoneBook.Application.Exceptions;
using PhoneBook.Domain.Entities;
using PhoneBook.Domain.Interfaces;
using PhoneBook.Domain.Interfaces.Cqrs;

namespace PhoneBook.Application.Commands;

public class UpdateContactCommandHandler(IUnitOfWork unitOfWork) : ICommandHandler<UpdateContactCommand>
{
    public async Task ExecuteAsync(UpdateContactCommand command, CancellationToken cancellationToken)
    {
        var contact = await unitOfWork.Contact.GetContactByIdAsync(command.Id, command.TrackChanges, cancellationToken);

        if (contact == null)
        {
            throw new NotFoundException(string.Format(ExceptionMessages.ContactWithIdNotFound, command.Id));
        }

        contact.Name = command.ContactRequestDto.Name;
        contact.MobilePhone = command.ContactRequestDto.MobilePhone;
        contact.TitleJob = command.ContactRequestDto.TitleJob;
        contact.BirthDate = command.ContactRequestDto.BirthDate;

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}