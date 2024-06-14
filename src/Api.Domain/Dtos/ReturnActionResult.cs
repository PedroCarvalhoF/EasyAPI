using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Domain.Dtos
{
    public class ReturnActionResult : Controller
    {
        public ActionResult ParseToActionResult(RequestResult request, DtoUserClaims dtoUserClaims)
        {

            request.SetUsersDetails(dtoUserClaims);

            switch (request.StatusCode)
            {
                case (int)HttpStatusCode.OK:
                    return Ok(request);
                case (int)HttpStatusCode.BadRequest:
                    return BadRequest(request);
                default:
                    return BadRequest(request);
            }
        }
    }
}
