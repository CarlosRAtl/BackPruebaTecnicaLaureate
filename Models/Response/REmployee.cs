namespace BackEndPruebaTecnicsLaureate.Models.Response
{
    public class REmployee
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public string? lastName { get; set; }
        public string? secondLastName { get; set; }
        public DateTime registrationDate { get; set; }
        public string? birthDate { get; set;}
        public int age { get; set; }
        public string? photography { get; set; }
        public string? position { get; set;}
        public decimal salary { get; set; }
    }
}
