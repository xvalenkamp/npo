using CsvHelper;
using CsvHelper.Configuration;
using Npo.Domain.Entities;
using System.Globalization;

namespace Npo.Data.Repositories.v1
{
    public class CameraRepository : ICameraRepository
    {
        private const string CAMERA_FILENAME = "cameras-defb.csv";
        public List<Camera> GetAll()
        {
            var filename = GetFilename();
            var config = GetCvsConfig();

            using (var reader = new StreamReader(filename))
            using (var csv = new CsvReader(reader, config))
            {
                return csv.GetRecords<CsvCamera>().Select(camera => new Camera()
                {
                    Id = GetCameraId(camera.Camera),
                    Camera = camera.Camera,
                    Latitude = camera.Latitude,
                    Longitude = camera.Longitude,
                }).ToList();
            }
        }

        private long? GetCameraId(string cameraName)
        {
            if (cameraName.StartsWith("ERROR"))
            {
                return null;
            }

            var cameraid = cameraName.Replace(" ", "-").Split("-")[2];
            return Convert.ToInt64(cameraid);
        }

        private CsvConfiguration GetCvsConfig()
        {
            return new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                MissingFieldFound = null,
                Delimiter = ";",
            };
        }

        private string GetFilename()
        {
            var basePath = GetBasePath();
            var filename = $"{basePath}{CAMERA_FILENAME}";
            if (!File.Exists(filename))
            {
                throw new ApplicationException("Camera file does not exist.");
            }
            return filename;
        }

        private string GetBasePath()
        {
            var isLinux = Environment.CurrentDirectory.Contains("/");

            if (isLinux)
            {
                return "./data/";
            }

            return ".\\data\\";
        }
    }
}
