using PhoneBook.Application.Exceptions;
using PhoneBook.Domain.Interfaces;
using PhoneBook.Domain.Interfaces.Cqrs;

namespace PhoneBook.Application.Commands;

public class DeleteContactCommandHandler(IUnitOfWork unitOfWork) : ICommandHandler<DeleteContactCommand>
{
    public async Task ExecuteAsync(DeleteContactCommand command, CancellationToken cancellationToken)
    {
        var contact = await unitOfWork.Contact.GetContactByIdAsync(command.Id, command.TrackChanges, cancellationToken);

        if (contact == null)
        {
            throw new NotFoundException(string.Format(ExceptionMessages.ContactWithIdNotFound, command.Id));
        }
        
        unitOfWork.Contact.Delete(contact);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}