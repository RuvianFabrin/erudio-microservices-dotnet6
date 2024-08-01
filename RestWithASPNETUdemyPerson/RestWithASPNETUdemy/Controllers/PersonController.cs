using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
       

        private readonly ILogger<PersonController> _logger;
        

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult GetSum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }
     

        private bool IsNumeric(string strNumber)
        {
            double number;
            //Aqui vai tentar parsear, se der certo retorna true, se n�o der certo retorna false
            bool isNumber = double.TryParse(
                strNumber, 
                System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo, 
                out number);
            return (isNumber) ;
            throw new NotImplementedException();
        }
    }
}
