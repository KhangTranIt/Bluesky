using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bluesky.Core.Data;
using Bluesky.Core.Domain.Banks;

namespace Bluesky.Services.Banks
{
    public class BankService : IBankService
    {
        private readonly IRepository<Bank> _bankRepository;

        public BankService(IRepository<Bank> bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public Bank GetBankById(int bankId)
        {
            if (bankId == 0)
                return null;
            return _bankRepository.Table.FirstOrDefault(p => p.Id == bankId);
        }

        public IEnumerable<Bank> GetAllBank()
        {
            return _bankRepository.Table.AsEnumerable();
        }

        public void InsertBank(Bank bank)
        {
            if(bank == null)
                throw new ArgumentNullException("bank");

            _bankRepository.Insert(bank);
        }

        public void UpdateBank(Bank bank)
        {
            if (bank == null)
                throw new ArgumentNullException("bank");

            _bankRepository.Update(bank);
        }

        public void DeleteBank(Bank bank)
        {
            if (bank == null)
                throw new ArgumentNullException("bank");

            _bankRepository.Delete(bank);
        }
    }
}
