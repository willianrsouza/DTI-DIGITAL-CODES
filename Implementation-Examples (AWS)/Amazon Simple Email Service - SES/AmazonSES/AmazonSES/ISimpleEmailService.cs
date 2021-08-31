using AmazonSES.EmailBodyModels;
using System.Threading.Tasks;

namespace AmazonSES
{
    public interface ISimpleEmailService
    {
        Task SendRequestAsync(string emailReceptor, string assunto, SimpleEmailServiceBody simpleEmailServiceBody);
    }
}