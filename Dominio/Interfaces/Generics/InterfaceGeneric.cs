namespace Dominio.Interfaces.Generics
{
    public interface InterfaceGeneric<T> where T : class
    {
        Task Add(T objeto);    

        Task Update(T objeto);

        Task Delete(T objeto);

        Task<T> GetEntityById(int Id);

        Task<List<T>> List();
    }
}
