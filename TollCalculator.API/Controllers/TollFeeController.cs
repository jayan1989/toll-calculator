namespace TollCalculator.API.Controllers
{
    [Route("api/toll-fee", Name = "Toll Fee")]
    [ApiController]
    public class TollFeeController : ControllerBase
    {
        private readonly ITollCalculatorService _tollCalculatorService;

        public TollFeeController(ITollCalculatorService tollCalculatorService)
        {
            _tollCalculatorService = tollCalculatorService;
        }

        [HttpPost("calculate")]
        public IActionResult Calculate(TollFeeRequestDto tollFeeRequest)
        {            
            return Ok(_tollCalculatorService.GetTollFee(tollFeeRequest));
        }
    }
}
