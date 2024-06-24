namespace BackEndPruebaTecnicsLaureate.Conversions
{
    public class Validate
    {
        public Boolean EsFecha(string fecha)
        {
            try
            {
                DateTime.Parse(fecha);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
