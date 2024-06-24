using BackEndPruebaTecnicsLaureate.Models.Response;

namespace BackEndPruebaTecnicsLaureate.Models.ViewModel
{
    public class VMBeneficiaries : VMGeneric
    {
        public List<RBeneficiary>? beneficiaries { get; set; }
        public RBeneficiary? beneficiary { get; set; }
    }
}
