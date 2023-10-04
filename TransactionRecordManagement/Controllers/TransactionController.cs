using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransactionRecordManagement.Models;

namespace TransactionRecordManagement.Controllers
{
    public class TransactionController : Controller
    {
        TransactionDataAccessLayer _dataLayer = null;
        public TransactionController() {
            _dataLayer = new TransactionDataAccessLayer();
        }
        // GET: TransactionController
        public ActionResult Index()
        {
            IEnumerable<Transaction> transactions = _dataLayer.GetAllTransaction();
            return View(transactions);
        }

        // GET: TransactionController/Details/5
        public ActionResult Details(int id)
        {
            Transaction transaction = _dataLayer.GetTransactionData(id);
            return View(transaction);
        }

        // GET: TransactionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransactionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Transaction transaction)
        {
            try
            {
                _dataLayer.AddTransaction(transaction);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionController/Edit/5
        public ActionResult Edit(int id)
        {
            Transaction transaction =  _dataLayer.GetTransactionData(id);
            return View(transaction);
        }

        // POST: TransactionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Transaction transaction)
        {
            try
            {   
                _dataLayer.UpdateTransaction(transaction);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionController/Delete/5
        public ActionResult Delete(int id)
        {
            Transaction transaction = _dataLayer.GetTransactionData(id);
            return View(transaction);
        }

        // POST: TransactionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Transaction transaction)
        {
            try
            {
                _dataLayer.DeleteTransaction(transaction.TransactionId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
