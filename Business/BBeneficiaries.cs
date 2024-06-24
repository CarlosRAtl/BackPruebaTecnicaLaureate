using BackEndPruebaTecnicsLaureate.Conversions;
using BackEndPruebaTecnicsLaureate.Models.Request;
using BackEndPruebaTecnicsLaureate.Models.ViewModel;
using BackEndPruebaTecnicsLaureate.Queries.Bneneficiaries;
using BackEndPruebaTecnicsLaureate.Queries.Employees;

namespace BackEndPruebaTecnicsLaureate.Business
{
    public class BBeneficiaries
    {
        public async ValueTask<VMBeneficiaries> GetBeneficiaries(string id)
        {
            VMBeneficiaries response = new();
            try
            {
                QBeneficiary function = new();
                var beneficiaries = await function.GetBeneficiaries(id);
                return beneficiaries;
            }
            catch (Exception ex)
            {
                response.code = false;
                response.globalMessage = ex.Message;
            }

            return response;
        }

        public async ValueTask<VMGeneric> PostBeneficiary(RQBeneficiary qBeneficiary)
        {
            VMGeneric response = new();
            try
            {
                QBeneficiary function = new();
                if (qBeneficiary == null)
                {
                    response.code = false;
                    response.globalMessage = "Existen datos incorrectos";
                    return response;
                }

                ReqBeneficiary newBeneficiary = new()
                {
                    id = Guid.NewGuid().ToString(),
                    name = qBeneficiary.name,
                    lastName = qBeneficiary.lastName,
                    secondLastName = qBeneficiary.secondLastName,
                    relationship = qBeneficiary.relationship,
                    employee = qBeneficiary.employee
                };

                var addNewBeneficiary = await function.PostBeneficiary(newBeneficiary);
                return addNewBeneficiary;
            }
            catch (Exception ex)
            {
                response.code = false;
                response.globalMessage = ex.Message;
            }

            return response;
        }

        public async ValueTask<VMGeneric> PutBeneficiary(string id, UPBeneficiary pBeneficiary)
        {
            VMGeneric response = new();
            try
            {
                QBeneficiary function = new();

                if (id == "")
                {
                    response.code = false;
                    response.globalMessage = $"No existe el id {id}";
                }

                ReqBeneficiary newBeneficiary = new()
                {
                    name = pBeneficiary.name,
                    lastName = pBeneficiary.lastName,
                    secondLastName = pBeneficiary.secondLastName,
                    relationship = pBeneficiary.relationship
                };

                var addNewBeneficiary = await function.PutBeneficiary(id, newBeneficiary);
                return addNewBeneficiary;
            }
            catch (Exception ex)
            {
                response.code = false;
                response.globalMessage = ex.Message;
            }

            return response;
        }

        public async ValueTask<VMBeneficiaries> GetBeneficiaryById(string id)
        {
            VMBeneficiaries response = new();
            try
            {
                QBeneficiary function = new();
                var beneficiaries = await function.GetBeneficiaryById(id);
                return beneficiaries;
            }
            catch (Exception ex)
            {
                response.code = false;
                response.globalMessage = ex.Message;
            }

            return response;
        }
    }
}
