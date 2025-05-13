namespace DAL
{
    public interface IRepositorios<T>
    {
        string Createe(T entity);
        List<T> Readee();
        string Updatee(T entity);
        string Deletee(int id);
    }
}
