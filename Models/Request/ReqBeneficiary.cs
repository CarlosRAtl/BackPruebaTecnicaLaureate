namespace BackEndPruebaTecnicsLaureate.Models.Request
{
    public class ReqBeneficiary
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public string? lastName { get; set; }
        public string? secondLastName { get; set; }
        public string? relationship { get; set; }
        public string? employee { get; set; }
    }

    public class RQBeneficiary
    {
        public string? name { get; set; }
        public string? lastName { get; set; }
        public string? secondLastName { get; set; }
        public string? relationship { get; set; }
        public string? employee { get; set; }
    }

    public class UPBeneficiary
    {
        public string? name { get; set; }
        public string? lastName { get; set; }
        public string? secondLastName { get; set; }
        public string? relationship { get; set; }
    }
}
