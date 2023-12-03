namespace HigiaServer.Test.DomainUnitTest;

public class CollaboratorTest
{
    private static readonly string Name = "Name";
    private static readonly string Address = "email.exemplo@gmail.com";
    private static readonly string PhoneNumber = "47 994324914";
    private static readonly DateTime Birthday = DateTime.Now.AddYears(-18);

    [Fact(DisplayName = "Create Collaborator With Valid State")]
    public void CreateCollaborator_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Collaborator(Name, Address, PhoneNumber, Birthday, "senha");
        action.Should().NotThrow<DomainExeptionValidation>();
    }
}