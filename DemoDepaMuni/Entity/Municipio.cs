namespace Entity
{
    public class Municipio : FormatoEntidades 
    {
        public override string ToString()
        {
            return $"{id};{nombre};";
        }
    }
}
