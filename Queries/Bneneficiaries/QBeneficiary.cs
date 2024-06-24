using BackEndPruebaTecnicsLaureate.Models.Request;
using BackEndPruebaTecnicsLaureate.Models.Response;
using BackEndPruebaTecnicsLaureate.Models.ViewModel;
using System.Data.SqlClient;

namespace BackEndPruebaTecnicsLaureate.Queries.Bneneficiaries
{
    public class QBeneficiary
    {
        private readonly DBConection conection = new();

        public async ValueTask<VMBeneficiaries> GetBeneficiaries(string id)
        {
            VMBeneficiaries response = new();
            try
            {
                List<RBeneficiary> beneficiaries = new();
                using (var sql = new SqlConnection(conection.cadenaSQL()))
                {
                    using (var cm = new SqlCommand("ObtenerBeneficiarioPorEmpleado", sql))
                    {
                        await sql.OpenAsync();
                        cm.CommandType = System.Data.CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@id", id);
                        await cm.ExecuteNonQueryAsync();
                        using (var items = await cm.ExecuteReaderAsync())
                        {
                            while (await items.ReadAsync())
                            {
                                var beneficiary = new RBeneficiary();
                                beneficiary.id = items["id"].ToString();
                                beneficiary.name = (string)items["Nombre"];
                                beneficiary.lastName = (string)items["ApellidoPaterno"];
                                beneficiary.secondLastName = (string)items["ApellidoMaterno"];
                                beneficiary.relationship = (string)items["Parentesco"];
                                beneficiaries.Add(beneficiary);
                            }
                        }
                    }
                }

                response.code = true;
                response.globalMessage = Messages.ok;
                response.beneficiaries = beneficiaries;
            }
            catch (Exception ex)
            {
                response.code = false;
                response.globalMessage = ex.Message;
            }
            return response;
        }
        public async ValueTask<VMGeneric> PostBeneficiary(ReqBeneficiary reqBeneficiary)
        {
            VMGeneric response = new VMGeneric();
            try
            {
                using (var sql = new SqlConnection(conection.cadenaSQL()))
                {
                    using (var cm = new SqlCommand("CrearBeneficiario", sql))
                    {
                        cm.CommandType = System.Data.CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@id", reqBeneficiary.id);
                        cm.Parameters.AddWithValue("@Nombre", reqBeneficiary.name);
                        cm.Parameters.AddWithValue("@ApellidoPaterno", reqBeneficiary.lastName);
                        cm.Parameters.AddWithValue("@ApellidoMaterno", reqBeneficiary.secondLastName);
                        cm.Parameters.AddWithValue("@Parentesco", reqBeneficiary.relationship);
                        cm.Parameters.AddWithValue("@Empleado", reqBeneficiary.employee);
                        await sql.OpenAsync();
                        await cm.ExecuteNonQueryAsync();
                    }
                }

                response.code = true;
                response.globalMessage = Messages.addUser;
            }
            catch (Exception ex)
            {
                response.code = false;
                response.globalMessage = ex.Message;
            }

            return response;
        }
        public async ValueTask<VMGeneric> PutBeneficiary(string id, ReqBeneficiary reqBeneficiary)
        {
            VMGeneric response = new VMGeneric();
            try
            {
                using (var sql = new SqlConnection(conection.cadenaSQL()))
                {
                    using (var cm = new SqlCommand("ActualizarBeneficiario", sql))
                    {
                        cm.CommandType = System.Data.CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@id", id);
                        cm.Parameters.AddWithValue("@Nombre", reqBeneficiary.name);
                        cm.Parameters.AddWithValue("@ApellidoPaterno", reqBeneficiary.lastName);
                        cm.Parameters.AddWithValue("@ApellidoMaterno", reqBeneficiary.secondLastName);
                        cm.Parameters.AddWithValue("@Parentesco", reqBeneficiary.relationship);
                        await sql.OpenAsync();
                        await cm.ExecuteNonQueryAsync();
                    }
                }

                response.code = true;
                response.globalMessage = Messages.updUser;
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
                RBeneficiary beneficiary = new();
                using (var sql = new SqlConnection(conection.cadenaSQL()))
                {
                    using (var cm = new SqlCommand("BeneficiarioPorId", sql))
                    {
                        await sql.OpenAsync();
                        cm.CommandType = System.Data.CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@id", id);
                        await cm.ExecuteNonQueryAsync();
                        using (var items = await cm.ExecuteReaderAsync())
                        {
                            while (await items.ReadAsync())
                            {
                                beneficiary.id = items["id"].ToString();
                                beneficiary.name = (string)items["Nombre"];
                                beneficiary.lastName = (string)items["ApellidoPaterno"];
                                beneficiary.secondLastName = (string)items["ApellidoMaterno"];
                                beneficiary.relationship = (string)items["Parentesco"];
                            }
                        }
                    }
                }

                response.code = true;
                response.globalMessage = Messages.ok;
                response.beneficiary = beneficiary;
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
