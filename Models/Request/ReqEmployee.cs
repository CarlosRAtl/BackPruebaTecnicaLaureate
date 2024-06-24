namespace BackEndPruebaTecnicsLaureate.Models.Request
{
    public class ReqEmployee
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public string? lastName { get; set; }
        public string? secondLastName { get; set; }
        public string? birthDate { get; set; }
        public int age { get; set; }
        public string? photography { get; set; }
        public string? position { get; set; }
        public decimal salary { get; set; }
        public string? user {  get; set; }
        public string? password { get; set; }
    }

    public class RQEmloyee
    {
        public string? name { get; set; }
        public string? lastName { get; set; }
        public string? secondLastName { get; set; }
        public string? birthDate { get; set; }
        public int age { get; set; }
        public IFormFile? photography { get; set; }
        public string? position { get; set; }
        public decimal salary { get; set; }
        public string? user { get; set; }
        public string? password { get; set; }
    }

    public class UPEmployee
    {
        public string? name { get; set; }
        public string? lastName { get; set; }
        public string? secondLastName { get; set; }
        public string? birthDate { get; set; }
        public int age { get; set; }
        public IFormFile? photography { get; set; }
        public string? position { get; set; }
        public decimal salary { get; set; }
    }
}
