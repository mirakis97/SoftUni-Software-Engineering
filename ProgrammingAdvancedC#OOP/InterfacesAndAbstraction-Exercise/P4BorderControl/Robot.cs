namespace P4BorderControl
{
    public class Robot : IRobot
    {
        public Robot(string id, string model)
        {
            this.Id = id;
            this.Model = model;
        }
        public string Id { get; private set; }
        public string Model { get; private set; }
    }
}