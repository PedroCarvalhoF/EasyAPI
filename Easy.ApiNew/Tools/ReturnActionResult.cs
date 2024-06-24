using Easy.Services.DTOs;
using Easy.Services.DTOs.UserClaims;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Easy.Api.Tools;

public class ReturnActionResult : Controller
{
    public ActionResult ParseToActionResult(RequestResult request, DtoUserClaims dtoUserClaims = null)
    {
        if (dtoUserClaims != null)
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