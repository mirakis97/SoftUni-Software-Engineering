namespace P4BorderControl
{
    public interface IPerson : IIdentifiable,IBirthable
    {
       string Name { get; }
       int Age { get; }
    }
}