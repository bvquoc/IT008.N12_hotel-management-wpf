using Hotel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Model
{
    public class ReservationBookModel
    {
        private readonly List<ReservationModel> _reservations;
        public ReservationBookModel() { _reservations = new List<ReservationModel>(); }

        public IEnumerable<ReservationModel> GetReservationForCustomer(CustomerModel customer)
        {
            return _reservations.Where(x => x.Customer == customer);
        }

        
        public void AddReservation(ReservationModel incomingReservation)
        {
            foreach (ReservationModel existingReservation in _reservations)
            {
                if (incomingReservation.Conflict(existingReservation))
                {
                    throw new ReservationConflictException(existingReservation, incomingReservation);
                }
            }

            _reservations.Add(incomingReservation);
        }
    }
}
