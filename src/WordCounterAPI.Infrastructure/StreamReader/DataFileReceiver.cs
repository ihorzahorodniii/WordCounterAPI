using Microsoft.AspNetCore.Http;
using WordCounterAPI.Infrastructure.Interfaces;

namespace WordCounterAPI.Infrastructure.StreamReader
{
    public class DataFileReceiver : IDataReceiver
    {
        private FileStream? _stream;
        public async Task<FileStream> GetDataAsync(IFormFile fileData)
        {
            _stream = File.OpenWrite(fileData.FileName);
            await fileData.CopyToAsync(_stream);
            _stream.Close();

            return _stream;
        }
    }
}
