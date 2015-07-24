using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AwaitAndAccess
{
    public class Product
    {
        public int Property { get; set; }

        public Task<int> GetResultAsync()
        {
            throw new NotImplementedException();
        }
    }
}
