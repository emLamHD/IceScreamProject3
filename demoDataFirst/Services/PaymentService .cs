using demoDataFirst.Models;
using demoDataFirst.Repositories;
using System.Collections.Generic;

namespace demoDataFirst.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IGenericRepository<Payment> _paymentRepository;

        public PaymentService(IGenericRepository<Payment> paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public IEnumerable<Payment> GetAllPayments()
        {
            return _paymentRepository.GetAll();
        }

        public Payment GetPaymentById(int id)
        {
            return _paymentRepository.GetById(id);
        }

        public void AddPayment(Payment payment)
        {
            _paymentRepository.Add(payment);
            _paymentRepository.Save();
        }

        public void UpdatePayment(Payment payment)
        {
            _paymentRepository.Update(payment);
            _paymentRepository.Save();
        }

        public void DeletePayment(int id)
        {
            _paymentRepository.Delete(id);
            _paymentRepository.Save();
        }
    }
}
