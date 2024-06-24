using BackEndPruebaTecnicsLaureate.Conversions;
using BackEndPruebaTecnicsLaureate.Models.Request;
using BackEndPruebaTecnicsLaureate.Models.ViewModel;
using BackEndPruebaTecnicsLaureate.Queries.Employees;
using BackEndPruebaTecnicsLaureate.Queries.LogIn;

namespace BackEndPruebaTecnicsLaureate.Business
{
    public class BEmployee
    {
        public async ValueTask<VMEmployees> GetEmployees()
        {
            VMEmployees response = new();
            try
            {
                QEmployee function = new();
                var employess = await function.GetEmployees();
                return employess;
            }
            catch (Exception ex)
            {
                response.code = false;
                response.globalMessage = ex.Message;
            }

            return response;
        }

        public async ValueTask<VMGeneric> PostEmployee(RQEmloyee qEmloyee)
        {
            VMGeneric response = new();
            try
            {
                Validate valid = new();
                Converts convert = new();
                QEmployee function = new();
                if (qEmloyee == null || (qEmloyee.user == "" && qEmloyee.password == "") || (qEmloyee.user == null && qEmloyee.password == null))
                {
                    response.code = false;
                    response.globalMessage = "Existen datos incorrectos";
                    return response;
                }

                if (!valid.EsFecha(qEmloyee.birthDate!))
                {
                    response.code = false;
                    response.globalMessage = "El formate de la fecha es incorrecto";
                    return response;
                }

                string idEmployee = Guid.NewGuid().ToString();

                ReqEmployee newEmployee = new()
                {
                    id = idEmployee,
                    name = qEmloyee.name,
                    lastName = qEmloyee.lastName,
                    secondLastName = qEmloyee.secondLastName,
                    birthDate = qEmloyee.birthDate,
                    age = qEmloyee.age,
                    photography = convert.Image(qEmloyee.photography!, idEmployee),
                    position = qEmloyee.position,
                    salary = qEmloyee.salary,
                    user = qEmloyee.user,
                    password = convert.Text(qEmloyee.password!)
                };

                var addNewEmployee = await function.PostEmployee(newEmployee);
                return addNewEmployee;
            }
            catch (Exception ex)
            {
                response.code = false;
                response.globalMessage = ex.Message;
            }

            return response;
        }

        public async ValueTask<VMGeneric> PutEmployee(string id, UPEmployee qEmloyee)
        {
            VMGeneric response = new();
            try
            {
                Validate valid = new();
                Converts convert = new();
                QEmployee function = new();

                if (id == "")
                {
                    response.code = false;
                    response.globalMessage = $"No existe el id {id}";
                }

                if (!valid.EsFecha(qEmloyee.birthDate!))
                {
                    response.code = false;
                    response.globalMessage = "El formato de la fecha es incorrecto";
                    return response;
                }

                ReqEmployee newEmployee = new()
                {
                    name = qEmloyee.name,
                    lastName = qEmloyee.lastName,
                    secondLastName = qEmloyee.secondLastName,
                    birthDate = qEmloyee.birthDate,
                    age = qEmloyee.age,
                    photography = convert.Image(qEmloyee.photography!, id),
                    position = qEmloyee.position,
                    salary = qEmloyee.salary,
                };

                var addNewEmployee = await function.PutEmployee(id, newEmployee);
                return addNewEmployee;
            }
            catch (Exception ex)
            {
                response.code = false;
                response.globalMessage = ex.Message;
            }

            return response;
        }

        public async ValueTask<VMEmployees> GetEmployeeById(string id)
        {
            VMEmployees response = new();
            try
            {
                QEmployee function = new();
                if (id == "")
                {
                    response.code = false;
                    response.globalMessage = "El id es requerido";
                    return response;
                }

                var checkEmployee = await function.GetEmployeeById(id);

                if (checkEmployee.employee!.id == null)
                {
                    response.code = false;
                    response.globalMessage = $"El id es incorrecto";
                    return response;
                }

                return checkEmployee;
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
