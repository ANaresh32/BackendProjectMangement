using FinanceManagement.DATA.Models;

namespace FinanceManagement.API.Models.Request
{
    public class AddClientRequest
    {
        public Client client { get; set; }
        public IFormFile file { get; set; }
    }
}
