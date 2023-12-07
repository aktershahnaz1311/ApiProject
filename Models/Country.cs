namespace DemoProject.Models
{
    public class Country:Base
    {
        public string? Name { get; set; }
        public string ? Code { get; set; }
        public IList <State>? States { get; set; }



    }
}