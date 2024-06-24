namespace BackEndPruebaTecnicsLaureate.Queries
{
    public class DBConection
    {
        private readonly string conectionString;

        public DBConection()
        {
            var buider = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            conectionString = buider.GetSection("ConnectionStrings:Conn").Value!;
        }

        public string cadenaSQL()
        {
            return conectionString!;
        }
    }
}
