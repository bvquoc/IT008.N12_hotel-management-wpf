using Hotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Exceptions
{
    public class ReservationConflictException : Exception
    {
        public ReservationModel ExistingReservation { get; }
        public ReservationModel IncomingReservation { get; }

        public ReservationConflictException(ReservationModel existingReservation, ReservationModel incomingReservation)
        {
            ExistingReservation = existingReservation;
            IncomingReservation = incomingReservation;
        }

        public ReservationConflictException(string message, ReservationModel existingReservation, ReservationModel incomingReservation) : base(message)
        {
            ExistingReservation = existingReservation;
            IncomingReservation = incomingReservation;
        }

        public ReservationConflictException(string message, Exception innerException, ReservationModel existingReservation, ReservationModel incomingReservation) : base(message, innerException)
        {
            ExistingReservation = existingReservation;
            IncomingReservation = incomingReservation;
        }

        protected ReservationConflictException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
