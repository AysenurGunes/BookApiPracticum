using BookApi.Dtos;
using BookApi.Helper;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{

    [LoginAttribute("gunesaysenur94@gmail.com", "123456")]
    [Route("api/[controller]")]
    public class LoginProcess : ControllerBase
    {

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(Login login2)
        {
            try
            {
                if (login2 != null)
                {
                    LoginAttribute loginAttribute =
          (LoginAttribute)Attribute.GetCustomAttribute(typeof(LoginProcess), typeof(LoginAttribute));

                    if (login2.MailAdress == loginAttribute.MailAdress && login2.Password == loginAttribute.Password)
                    {
                        GenerateToken generateToken = new GenerateToken();
                        string token = generateToken.GenerateTokenJwt(1);

                        return Ok(token);

                    }

                    else
                    {
                        return NoContent();
                    }

                }
                else
                {
                    return NoContent();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
