using BackEndPruebaTecnicsLaureate.Business;
using BackEndPruebaTecnicsLaureate.Models.Request;
using BackEndPruebaTecnicsLaureate.Models.Response;
using BackEndPruebaTecnicsLaureate.Models.ViewModel;
using System.Data.SqlClient;

namespace BackEndPruebaTecnicsLaureate.Queries.Employees
{
    public class QEmployee
    {
        private readonly DBConection conection = new();

        public async ValueTask<VMEmployees> GetEmployees()
        {
            VMEmployees response = new VMEmployees();
            
            try
            {
                List<REmployee> employees = new List<REmployee>();
                using (var sql = new SqlConnection(conection.cadenaSQL()))
                {
                    using (var cm = new SqlCommand("ObtenerEmpleados", sql))
                    {
                        await sql.OpenAsync();
                        cm.CommandType = System.Data.CommandType.StoredProcedure;
                        using (var items = await cm.ExecuteReaderAsync())
                        {

                            while (await items.ReadAsync())
                            {
                                var employee = new REmployee();
                                employee.id = items["id"].ToString();
                                employee.name = (string)items["Nombre"];
                                employee.lastName = (string)items["ApellidoPaterno"];
                                employee.secondLastName = (string)items["ApellidoMaterno"];
                                employee.registrationDate = (DateTime)items["FechaIngreso"];
                                employee.birthDate = (string)items["FechaNacimiento"];
                                employee.age = (int)items["Edad"];
                                employee.photography = (string)items["Fotografia"];
                                employee.position = (string)items["Puesto"];
                                employee.salary = (decimal)items["Salario"];
                                employees.Add(employee);
                            }
                        }
                    }
                }

                response.code = true;
                response.globalMessage = Messages.ok;
                response.employees = employees;
            }
            catch (Exception ex)
            {
                response.code = false;
                response.globalMessage = ex.Message;
            }
            return response;
        }
        public async ValueTask<VMGeneric> PostEmployee(ReqEmployee reqEmployee)
        {
            VMGeneric response = new VMGeneric();
            try
            {
                using (var sql = new SqlConnection(conection.cadenaSQL()))
                {
                    using (var cm = new SqlCommand("CrearEmpleado", sql))
                    {
                        cm.CommandType = System.Data.CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@id", reqEmployee.id);
                        cm.Parameters.AddWithValue("@Nombre", reqEmployee.name);
                        cm.Parameters.AddWithValue("@ApellidoPaterno", reqEmployee.lastName);
                        cm.Parameters.AddWithValue("@ApellidoMaterno", reqEmployee.secondLastName);
                        cm.Parameters.AddWithValue("@FechaNacimiento", reqEmployee.birthDate);
                        cm.Parameters.AddWithValue("@Edad", reqEmployee.age);
                        cm.Parameters.AddWithValue("@Fotografia", reqEmployee.photography);
                        cm.Parameters.AddWithValue("@Puesto", reqEmployee.position);
                        cm.Parameters.AddWithValue("@Salario", reqEmployee.salary);
                        cm.Parameters.AddWithValue("@Usuario", reqEmployee.user);
                        cm.Parameters.AddWithValue("@Contraseña", reqEmployee.password);
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

        public async ValueTask<VMGeneric> PutEmployee(string id, ReqEmployee reqEmployee)
        {
            VMGeneric response = new VMGeneric();
            try
            {
                using (var sql = new SqlConnection(conection.cadenaSQL()))
                {
                    using (var cm = new SqlCommand("ActualizarEmpleado", sql))
                    {
                        cm.CommandType = System.Data.CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@id", id);
                        cm.Parameters.AddWithValue("@Nombre", reqEmployee.name);
                        cm.Parameters.AddWithValue("@ApellidoPaterno", reqEmployee.lastName);
                        cm.Parameters.AddWithValue("@ApellidoMaterno", reqEmployee.secondLastName);
                        cm.Parameters.AddWithValue("@FechaNacimiento", reqEmployee.birthDate);
                        cm.Parameters.AddWithValue("@Edad", reqEmployee.age);
                        cm.Parameters.AddWithValue("@Fotografia", reqEmployee.photography);
                        cm.Parameters.AddWithValue("@Puesto", reqEmployee.position);
                        cm.Parameters.AddWithValue("@Salario", Convert.ToDecimal(reqEmployee.salary));
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

        public async ValueTask<VMEmployees> GetEmployeeById(string id)
        {
            VMEmployees response = new();
            try
            {
                REmployee employee = new();
                using (var sql = new SqlConnection(conection.cadenaSQL()))
                {
                    using (var cm = new SqlCommand("EmpleadoPorId", sql))
                    {
                        await sql.OpenAsync();
                        cm.CommandType = System.Data.CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@id", id);
                        await cm.ExecuteNonQueryAsync();
                        using (var items = await cm.ExecuteReaderAsync())
                        {
                            while (await items.ReadAsync())
                            {
                                employee.id = items["id"].ToString();
                                employee.name = (string)items["Nombre"];
                                employee.lastName = (string)items["ApellidoPaterno"];
                                employee.secondLastName = (string)items["ApellidoMaterno"];
                                employee.registrationDate = (DateTime)items["FechaIngreso"];
                                employee.birthDate = (string)items["FechaNacimiento"];
                                employee.age = (int)items["Edad"];
                                employee.photography = (string)items["Fotografia"];
                                employee.position = (string)items["Puesto"];
                                employee.salary = (decimal)items["Salario"];
                            }
                        }
                    }
                }

                response.code = true;
                response.globalMessage = Messages.ok;
                response.employee = employee;
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
