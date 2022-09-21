using Npo.Domain.Entities;

namespace Npo.Data.Repositories.v1
{
    public interface ICameraRepository
    {
        List<Camera> GetAll();
    }
}