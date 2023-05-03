using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WordCounterAPI.Core.Services;
using WordCounterAPI.Core.Interfaces;

using WordCounterAPI.Infrastructure.Interfaces;

namespace WordCounterAPI.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordCounterController : Controller
    {
        private readonly IDataReceiver _receiver;

        public WordCounterController(IDataReceiver receiver)
        {
            _receiver = receiver;
        }

        /// <summary>
        /// Word Counter from uploaded text file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("Count")]
        public async Task<ActionResult> Count(IFormFile file)
        {
            if (file == null)
            {
                return BadRequest();
            }
            try
            {
                var wordCounter = new WordCounterService(
                    new DataProvider(
                            await _receiver.GetDataAsync(file)
                        )
                    );

                return Ok(JsonSerializer.Serialize<Dictionary<string, int>>(wordCounter.GetWords()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
