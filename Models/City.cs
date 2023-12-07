namespace DemoProject.Models
{
    public class City:Base
    {
        public string? Name { get; set; }



        public int StateId { get; set; }

        public State? State { get; set; }


    }
}
