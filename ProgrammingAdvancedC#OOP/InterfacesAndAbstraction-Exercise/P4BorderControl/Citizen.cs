namespace P4BorderControl
{
    public class Citizen : IPerson, IBirthable
    {
        public Citizen(string name, int age,string id,string birt)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birt;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }
        public string Birthdate { get; private set; }
    }
}