namespace PhoneBook.Application.DTO;

public record ContactRequestDto
{
    public string Name { get; init; }
    public string MobilePhone { get; init; }
    public string TitleJob { get; init; }
    public DateOnly BirthDate { get; init; }
}