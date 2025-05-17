namespace PhoneBook.Domain.Entities;

public class Contact : BaseEntity
{
    public string Name { get; set; }
    public string MobilePhone { get; set; }
    public string TitleJob { get; set; }
    public DateOnly BirthDate { get; set; }
}