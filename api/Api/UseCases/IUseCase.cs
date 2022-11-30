namespace Api.UseCases
{
    public interface IUseCase<T>
    {
        Task<T> Execute();
    }
}