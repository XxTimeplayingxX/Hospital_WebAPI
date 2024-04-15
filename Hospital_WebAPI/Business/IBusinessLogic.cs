using Hospital_WebAPI.RESPONSE;

namespace Hospital_WebAPI.Business
{
    public interface IBusinessLogic
    {
        //Todo esto se manda al controlador
        public Task<Response> GetAll();
        public Task<Response> GetById(int id);
        public Task<Response> UpdatePut(int id);
        public Task<Response> AddPost(object value);
        public Task<Response> Delete(int id);

    }
}
