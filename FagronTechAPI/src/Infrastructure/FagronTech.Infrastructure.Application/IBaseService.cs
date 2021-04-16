namespace FagronTech.Infrastructure.Application
{
    public interface IBaseService
    {
        T Map<T>(object source);
    }
}
