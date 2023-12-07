namespace DemoProject.Models
{
    public class State:Base
    {
        public string? Name { get; set; }

        public int CountryId { get; set; }

        public Country? Country { get; set; }


        public IList<City>? Cities { get; set; }











    }

}
