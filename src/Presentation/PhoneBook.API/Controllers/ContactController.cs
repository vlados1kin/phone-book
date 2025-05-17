using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.Commands;
using PhoneBook.Application.DTO;
using PhoneBook.Application.Queries;
using PhoneBook.Domain.Interfaces.Cqrs;

namespace PhoneBook.API.Controllers;

[ApiController]
[Route("api/contacts")]
public class ContactController : ControllerBase
{
    private readonly IQueryHandler<GetAllContactsQuery, IEnumerable<ContactResponseDto>> _getAllContactsHandler;
    private readonly IQueryHandler<GetContactByIdQuery, ContactResponseDto> _getContactByIdHandler;
    private readonly ICommandHandler<CreateContactCommand, ContactResponseDto> _createContactHandler;
    private readonly ICommandHandler<UpdateContactCommand> _updateContactHandler;
    private readonly ICommandHandler<DeleteContactCommand> _deleteContactHandler;
    
    public ContactController(
        IQueryHandler<GetAllContactsQuery, IEnumerable<ContactResponseDto>> getAllContactsHandler,
        IQueryHandler<GetContactByIdQuery, ContactResponseDto> getContactByIdHandler,
        ICommandHandler<CreateContactCommand, ContactResponseDto> createContactHandler,
        ICommandHandler<UpdateContactCommand> updateContactHandler,
        ICommandHandler<DeleteContactCommand> deleteContactHandler)
    {
        _getAllContactsHandler = getAllContactsHandler;
        _getContactByIdHandler = getContactByIdHandler;
        _createContactHandler = createContactHandler;
        _updateContactHandler = updateContactHandler;
        _deleteContactHandler = deleteContactHandler;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllContacts(CancellationToken cancellationToken = default)
    {
        var query = new GetAllContactsQuery(false);
        
        var contactsDto = await _getAllContactsHandler.ExecuteAsync(query, cancellationToken);

        return Ok(contactsDto);
    }

    [HttpGet("{id:guid}", Name = "GetContactById")]
    public async Task<IActionResult> GetContactById([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        var query = new GetContactByIdQuery(id, false);

        var contactDto = await _getContactByIdHandler.ExecuteAsync(query, cancellationToken);

        return Ok(contactDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateContact([FromBody] ContactRequestDto contactRequestDto, CancellationToken cancellationToken = default)
    {
        var command = new CreateContactCommand(contactRequestDto);

        var contactDto = await _createContactHandler.ExecuteAsync(command, cancellationToken);

        return CreatedAtRoute(nameof(GetContactById), new { id = contactDto.Id }, contactDto);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateContactById([FromRoute] Guid id, [FromBody] ContactRequestDto contactRequestDto, CancellationToken cancellationToken = default)
    {
        var command = new UpdateContactCommand(id, contactRequestDto, true);

        await _updateContactHandler.ExecuteAsync(command, cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteContactById([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        var command = new DeleteContactCommand(id, true);

        await _deleteContactHandler.ExecuteAsync(command, cancellationToken);

        return NoContent();
    }
}