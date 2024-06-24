using BackEndPruebaTecnicsLaureate.Conversions;
using BackEndPruebaTecnicsLaureate.Models.Request;
using BackEndPruebaTecnicsLaureate.Models.ViewModel;
using BackEndPruebaTecnicsLaureate.Queries.LogIn;

namespace BackEndPruebaTecnicsLaureate.Business
{
    public class BLogIn
    {
        public async ValueTask<VMLogIn> PostLogIn(ReqLogIn reqLogIn)
        {
            VMLogIn response = new();
            Converts convert = new();
            try
            {
                QLogIn function = new();
                if (reqLogIn.user == "" || reqLogIn.password == "")
                {
                    response.code = false;
                    response.globalMessage = "Credenciales incorrectas";
                    return response;
                }

                ReqLogIn logIn = new()
                {
                    user = reqLogIn.user,
                    password = convert.Text(reqLogIn.password!)
                };

                var checkLogIn = await function.PostLogIn(logIn);

                if (checkLogIn.login!.id == null)
                {
                    response.code = false;
                    response.globalMessage = $"Usuario y/o contraseña incorrectos";
                    return response;
                }

                return checkLogIn;
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
