using Calculator.Core;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculator<int> _calculator;

        public CalculatorController(ICalculator<int> calculator)
        {
            _calculator = calculator;
        }

        [HttpGet("Add/{a:int}/{b:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]      
        public ActionResult Add(int a, int b)
        {
            return Ok(_calculator.Add(a,b));
        }

        [HttpGet("Subtract/{a:int}/{b:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Subtract(int a, int b)
        {
            return Ok(_calculator.Subtract(a, b));
        }

        [HttpGet("Multiply/{a:int}/{b:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Multiply(int a, int b)
        {
            return Ok(_calculator.Multiply(a, b));
        }

        [HttpGet("Divide/{a:int}/{b:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Divide(int a, int b)
        {
            try 
            {
                return Ok(_calculator.Divide(a, b));
            }
            catch(DivideByZeroException ex)
            {
                return BadRequest(ex.Message);
            }           
        }
    }
}
