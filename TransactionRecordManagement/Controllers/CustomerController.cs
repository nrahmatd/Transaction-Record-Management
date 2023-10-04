using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransactionRecordManagement.Models;

namespace TransactionRecordManagement.Controllers
{
    public class CustomerController : Controller
    {
        CustomerDataAccessLayer _dataAccessLayer = null;   
        public CustomerController() {
            _dataAccessLayer = new CustomerDataAccessLayer();
        }

        // GET: CustomerController
        public ActionResult Index()
        {
            IEnumerable<Customer> customerList = _dataAccessLayer.GetAllCustomer();
            return View(customerList);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            Customer customer = _dataAccessLayer.GetCustomerData(id);
            return View(customer);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                _dataAccessLayer.AddCustomer(customer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            Customer customer = _dataAccessLayer.GetCustomerData(id);
            return View(customer);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                _dataAccessLayer.UpdateCustomer(customer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {

            Customer customer = _dataAccessLayer.GetCustomerData(id);
            return View(customer);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Customer customer)
        {
            try
            {
                _dataAccessLayer.DeleteCustomer(customer.AccountId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
