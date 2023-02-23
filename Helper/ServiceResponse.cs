using Microsoft.AspNetCore.Mvc;

namespace BookApi.Helper
{
    public class ServiceResponse<TEntity>
    {
        public ServiceResponse()
        {
            
        }
        public ServiceResponse(TEntity data)
        {
            Data = data;
        }

        public ServiceResponse(string error)
        {
            Error = error;
            Success = false;
        }

        public TEntity? Data { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
        public int statusCode { get; set; }
       
    }

}
//public class ServiceResponse2
//{
  
//    public bool Success { get; set; }
//    public string Error { get; set; }
//    public int statusCode { get; set; }
//    public string Data2 { get; set; }
//    public ServiceResponse2()
//    {

//    }
//    public ServiceResponse2(string data)
//    {
//        Data2 = data;
//    }

   

    
//}
