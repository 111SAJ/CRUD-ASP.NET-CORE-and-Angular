using CRUD_API.ViewModel;

namespace CRUD_API.Service
{
    public class ErrorResponseService
    {
        public CustomeErrorResponseViewModel CreateErrorResponse (int status, string error)
        {
            return new CustomeErrorResponseViewModel
            {
                Status = status,
                Error = error,
                Data = null
            };
        }
    }
}
