using Microsoft.EntityFrameworkCore;

namespace BookApi.DataAccess
{
    public class DataGenerator
    {
        public static void Initialize()
        {
            using (var dbcontext=new BookDbContext())
            {

            }
        }
    }
}
