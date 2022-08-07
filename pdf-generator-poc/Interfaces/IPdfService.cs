namespace pdf_generator_poc.Interfaces
{
    public interface IPdfService<T> : IPdfServiceBase
    {
        string OutputPath { get; }

        Task<bool> CreatePdf(T content);
    }
}
