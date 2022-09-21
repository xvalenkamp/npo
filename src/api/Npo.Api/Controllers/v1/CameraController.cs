using Microsoft.AspNetCore.Mvc;
using Npo.Dtos.v1.Filters;
using Npo.Services.v1;

namespace Npo.Api.Controllers.v1
{
    /// <summary>
    /// CameraController
    /// </summary>
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/cameras")]
    public class CameraController : ControllerBase
    {
        private readonly ILogger<CameraController> _logger;
        private readonly ICameraService _cameraService;

        /// <summary>
        /// Constructor
        /// </summary>
        public CameraController(ILogger<CameraController> logger, ICameraService cameraService) 
        {
            _logger = logger;
            _cameraService = cameraService;
        }

        /// <summary>
        /// Get Cameras
        /// </summary>
        /// <param name="cameraFilter"></param>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpGet]
        public IActionResult GetCameras([FromQuery] CameraFilter cameraFilter)
        {
            try
            {
                var cameras = _cameraService.GetCameras(cameraFilter);
                return Ok(cameras);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
