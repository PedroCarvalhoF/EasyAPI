using Easy.Services.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Easy.Api.Tools
{
    public class ReturnActionResult<T> : Controller where T : class
    {
        public ActionResult ParseToActionResult(RequestResult<T> requestResult)
        {
            switch (requestResult.StatusCode)
            {
                case (int)HttpStatusCode.OK:
                    return Ok(requestResult);
                case (int)HttpStatusCode.BadRequest:
                    return BadRequest(requestResult);
                default:
                    return BadRequest(requestResult);
            }
        }
    }
}
