using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwaitAndAccess
{
    public class Examples
    {
        private Task<Product> GetProductAsync()
        {
            throw new NotImplementedException();
        }

        public async Task AccessProperty()
        {
            {
                // Using an intermediate variable to capture the product.
                Product product = await GetProductAsync();
                int property = product.Property;
            }

            {
                // Combining the asynchronous call and member access requires
                // parentheses.
                int property = (await GetProductAsync()).Property;
            }

            {
                // Using methods of the Task can eliminate the parentheses.
                int property = await GetProductAsync().ContinueWith(p =>
                    p.Result.Property);
            }

            {
                // An extension method can clean up the syntax slightly.
                int property = await GetProductAsync().AndThen(p => p.Property);
            }

            {
                // The proposed operator.
                // int property = await GetProductAsync()..Property;
            }
        }

        public async Task CallAsyncMethod()
        {
            {
                // Using an intermediate variable to capture the product.
                Product product = await GetProductAsync();
                int result = await product.GetResultAsync();
            }

            {
                // Combining the two asynchronous calls.
                int result = await (await GetProductAsync()).GetResultAsync();
            }

            {
                // Using methods of Task eliminates the parentheses, but joins
                // the two awaits.
                int result = await await GetProductAsync()
                    .ContinueWith(p => p.Result.GetResultAsync());
            }

            {
                // An extension method cleans this up quite a bit.
                int result = await GetProductAsync().AndThen(p => p.GetResultAsync());
            }

            {
                // The proposed syntax.
                // int result = await GetProductAsync()..GetResultAsync();
            }
        }
    }
}
