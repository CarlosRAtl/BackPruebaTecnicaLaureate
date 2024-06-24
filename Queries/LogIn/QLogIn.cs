using BackEndPruebaTecnicsLaureate.Models.Request;
using BackEndPruebaTecnicsLaureate.Models.Response;
using BackEndPruebaTecnicsLaureate.Models.ViewModel;
using System.Data.SqlClient;

namespace BackEndPruebaTecnicsLaureate.Queries.LogIn
{
    public class QLogIn
    {
        private readonly DBConection conection = new();
        public async ValueTask<VMLogIn> PostLogIn(ReqLogIn reqLogIn)
        {
            VMLogIn response = new();
            try
            {
                RLogIn logIn = new();
                using (var sql = new SqlConnection(conection.cadenaSQL()))
                {
                    using (var cm = new SqlCommand("LoginUsuario", sql))
                    {
                        cm.CommandType = System.Data.CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@Usuario", reqLogIn.user);
                        cm.Parameters.AddWithValue("@Contraseña", reqLogIn.password);
                        await sql.OpenAsync();
                        await cm.ExecuteNonQueryAsync();
                        using (var items = await cm.ExecuteReaderAsync())
                        {
                            while (await items.ReadAsync())
                            {

                                logIn.id = items["id"].ToString();
                                logIn.name = (string)items["Nombre"];
                                logIn.lastName = (string)items["ApellidoPaterno"];
                                logIn.secondLastName = (string)items["ApellidoMaterno"];
                                logIn.birthDate = (string)items["FechaNacimiento"];
                                logIn.age = (int)items["Edad"];
                                logIn.photography = (string)items["Fotografia"];
                                logIn.position = (string)items["Puesto"];
                                logIn.salary = (decimal)items["Salario"];
                            }
                        }
                    }
                }

                response.code = true;
                response.globalMessage = $"{Messages.logInUser} {logIn.name}";
                response.login = logIn;
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
