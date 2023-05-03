using Microsoft.AspNetCore.Http;


namespace WordCounterAPI.Infrastructure.Interfaces
{
    public interface IDataReceiver
    {
        public Task<FileStream> GetDataAsync(IFormFile fileData);
    }
}
