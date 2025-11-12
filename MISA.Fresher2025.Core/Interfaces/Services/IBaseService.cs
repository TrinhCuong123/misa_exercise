namespace MISA.Fresher2025.Core.Interfaces.Services
{
  public interface IBaseService<T>
  {
    public List<T> Get();
    public T Insert(T entity);
    public T Update(T entity);
    public void Delete(Guid id);
  }
}