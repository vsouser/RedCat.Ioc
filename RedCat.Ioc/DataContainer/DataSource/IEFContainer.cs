
namespace RedCat.Ioc.DataContainer.DataSource
{
    public interface IEFContainer<T>
    {
       T SelectData();
       void InsertData(T data);
       void DropData(T data);
    }
}
