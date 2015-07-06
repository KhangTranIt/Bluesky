using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bluesky.Core.Domain.Banks;

namespace Bluesky.Services.Banks
{
    public interface IBankService
    {
        Bank GetBankById(int bankId);
        IEnumerable<Bank> GetAllBank();
        void InsertBank(Bank bank);
        void UpdateBank(Bank bank);
        void DeleteBank(Bank bank);
    }
}
