using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiOperacionesHeader.Controllers
{
    namespace ApiOperaciones.Controllers
    {
        [ApiController]
        [Route("[controller]")]
        public class OperacionesController : ControllerBase
        {
            // GET: OperacionesController
            public ActionResult Get()
            {
                return Ok("Api Operaciones por Headers");
            }

            // Get: OperacionesController/calcular
            [HttpGet("calcular")]
            public ActionResult Calcular()
            {
                try
                {
                    char operacion;
                    string parametro1 = Request.Headers["parametro1"].ToString();
                    string parametro2 = Request.Headers["parametro2"].ToString();

                    if (string.IsNullOrEmpty(Request.Headers["operacion"]))
                        return BadRequest("El operador es un campo requerido.");
                    else
                        operacion = char.Parse(Request.Headers["operacion"].ToString());

                    if (string.IsNullOrEmpty(parametro1)) return BadRequest("Ingresar parametro 1");

                    if (string.IsNullOrEmpty(parametro2)) return BadRequest("Ingresar parametro 2");

                    var valor1 = decimal.Parse(parametro1);
                    var valor2 = decimal.Parse(parametro2);

                    switch (operacion)
                    {
                        case '+':
                            return Ok(valor1 + valor2);
                        case '-':
                            return Ok(valor1 - valor2);
                        case '*':
                            return Ok(valor1 * valor2);
                        case '/':
                            return Ok(valor1 / valor2);
                        default:
                            return BadRequest("Operador valido + - * /");
                    }
                }
                catch (System.Exception exc)
                {
                    return BadRequest(exc.Message);
                }
            }
        }
    }
}