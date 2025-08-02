namespace LINQDemo
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public List<string> Projects { get; set; } = new List<string>();
    }

}