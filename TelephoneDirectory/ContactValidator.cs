using FluentValidation;
using TELEPHONEDIRECTORY;

public class ContactValidator : AbstractValidator<Contact>
{
    List<Contact> _contacts = new List<Contact>();
    public ContactValidator(List<Contact>contacts)
    {
        RuleFor(contact => contact.phone).NotNull().MaximumLength(7);
        RuleFor(contact => contact.telephone).NotNull().MaximumLength(10);
        _contacts = contacts;
    }
}