using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API.Completions;
using OpenAI_API;
using System.Threading.Tasks;

namespace DotNetTextAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> GetAIBasedResult(string SearchText)
        {
            string APIKey = "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";
            string answer = string.Empty;

            var openai = new OpenAIAPI(APIKey);
            CompletionRequest completion = new CompletionRequest
            {
                Prompt = SearchText,
                Model = "davinci-002", 
               // Model = "gpt-3.5-turbo",
                MaxTokens = 200
            };

            try
            {
                var result = await openai.Completions.CreateCompletionAsync(completion);
                foreach (var item in result.Completions)
                {
                    answer = item.Text;
                }

                return Ok(answer);
            }
            catch (HttpRequestException ex)
            {
                if (ex.Message.Contains("TooManyRequests"))
                {
                    return StatusCode(StatusCodes.Status429TooManyRequests, "Quota exceeded. Please check your OpenAI plan and billing details.");
                }

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
    }
}
