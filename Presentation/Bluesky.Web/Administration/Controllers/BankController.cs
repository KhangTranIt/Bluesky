using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bluesky.Admin.Models.Bank;
using Bluesky.Core;
using Bluesky.Core.Domain.Banks;
using Bluesky.Services.Banks;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace Bluesky.Admin.Controllers
{
    public class BankController : Controller
    {
        private readonly IBankService _bankService;
        private readonly IWorkContext _workContext;

        public BankController(IBankService bankService, 
            IWorkContext workContext)
        {
            _bankService = bankService;
            _workContext = workContext;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BankList([DataSourceRequest]DataSourceRequest request)
        {
            var transactions = _bankService.GetAllBank()
                .Select(p => new BankModel
                                      {
                                          Id = p.Id,
                                          Name = p.Name,
                                          BankAccNo = p.BankAccNo,
                                          Remark = p.Remark,
                                          UpdateBy = p.UpdateBy,
                                          UpdateOn = p.UpdateOn
                                      });

            return Json(transactions.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, BankModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var bank = new Bank
                {
                    Name = model.Name,
                    BankAccNo = model.BankAccNo,
                    UpdateOn = DateTime.Now,
                    Remark = model.Remark
                };

                if (_workContext.CurrentAccount != null)
                {
                    bank.UpdateBy = _workContext.CurrentAccount.Email;
                    model.UpdateBy = _workContext.CurrentAccount.Email;
                }

                _bankService.InsertBank(bank);

                model.Id = bank.Id;
                model.UpdateOn = DateTime.Now;
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit([DataSourceRequest] DataSourceRequest request, BankModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var bank = _bankService.GetBankById(model.Id);
                bank.Name = model.Name;
                bank.Remark = model.Remark;
                bank.UpdateOn = DateTime.Now;
                if (_workContext.CurrentAccount != null)
                {
                    bank.UpdateBy = _workContext.CurrentAccount.Email;
                    model.UpdateBy = _workContext.CurrentAccount.Email;
                }
                _bankService.UpdateBank(bank);
                model.UpdateOn = DateTime.Now;
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, BankModel model)
        {
            if (model != null)
            {
                var bank = _bankService.GetBankById(model.Id);
                _bankService.DeleteBank(bank);
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}