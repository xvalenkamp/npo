using Npo.Data.Repositories.v1;
using Npo.Domain.Entities;
using Npo.Dtos.v1.Filters;

namespace Npo.Services.v1
{
    public class CameraService : ICameraService
    {
        private readonly ICameraRepository _cameraRepository;

        public CameraService(ICameraRepository cameraRepository)
        {
            _cameraRepository = cameraRepository;
        }

        public List<Camera> GetCameras(CameraFilter? camerafilter)
        {
            var cameras = _cameraRepository.GetAll();

            if (camerafilter?.StreetName is not null)
            {
                cameras = cameras
                            .Where(camera => camera.Camera.Contains(camerafilter.StreetName, StringComparison.InvariantCultureIgnoreCase))
                            .ToList();
            }

            if (camerafilter?.CameraId is not null)
            {
                cameras = cameras
                            .Where(camera => camera.Id == camerafilter.CameraId)
                            .ToList();
            }

            return cameras;
        }
    }
}
