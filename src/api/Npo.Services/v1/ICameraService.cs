using Npo.Domain.Entities;
using Npo.Dtos.v1.Filters;

namespace Npo.Services.v1
{
    public interface ICameraService
    {
        List<Camera> GetCameras(CameraFilter? camerafilter);
    }
}