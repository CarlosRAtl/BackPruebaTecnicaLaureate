using BackEndPruebaTecnicsLaureate.Models.Response;

namespace BackEndPruebaTecnicsLaureate.Models.ViewModel
{
    public class VMEmployees : VMGeneric
    {
        public List<REmployee>? employees {  get; set; }
        public REmployee? employee { get; set; }
    }
}
