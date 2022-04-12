namespace Core.Interfases
{
    public interface IUnitOfWork <T> where T:class
    {
        IGenericRepostory <T> Entity { get; }
        void Save();
    }
}
