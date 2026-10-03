namespace Part2_HotelReservationSystem;
public enum ReservationStatus
{
  Pending ,
  Confirmed,
  CheckIn,
  CheckOut,
  Canceled
}

public class Reservation
{
   public int ReservationId { get; init; }
   public  Room Room { get; init; }
   public Guest Guest { get; init; }
   public DateTime CheckInDate { get; init; }
   public DateTime CheckOutDate { get; init; }
   public ReservationStatus Status { get; private set; } = ReservationStatus.Pending;
   
   public decimal TotalCost
   {
       get
       {
           TimeSpan numberOfDays = CheckOutDate - CheckInDate;
           return (numberOfDays.Days * Room.NightlyRate); 
       }
   }
   
   public Reservation(int reservationId, Room room, Guest guest, DateTime checkIntDate, DateTime checkOutDate)
   {
       if (reservationId <= 0)
           throw new ArgumentException("Reservation Id cannot be negative."); 

       if (room == null)
           throw new ArgumentNullException(nameof(room), "Room cannot be null.");
       
       if (guest == null)
           throw new ArgumentNullException(nameof(guest), "Guest cannot be null"); 

       if (checkIntDate >= checkOutDate)
           throw new ArgumentException("Checkout date must be strictly after checkin date.");

       if (room.IsUnderMaintenance)
           throw new InvalidOperationException("Room is under maintenance.");

       this.ReservationId = reservationId;
       this.Room = room;
       this.Guest = guest;
       this.CheckInDate = checkIntDate;
       this.CheckOutDate = checkOutDate;
       guest.AddReservation(this); // this -> current object 
   }

   public void Confirm()
   {
       if (Status != ReservationStatus.Pending)
       {
           throw new InvalidOperationException("Only pending reservations can be confirmed."); 
       }

       this.Status = ReservationStatus.Confirmed; 
   }

   public void CheckIn()
   {
       if (Status != ReservationStatus.Confirmed)
       {
           throw new InvalidOperationException("Only confirmed reservations can be checked in"); 
       }

       Status = ReservationStatus.CheckIn; 
   }

   public void CheckOut()
   {
       if (Status != ReservationStatus.CheckIn)
       {
           throw new InvalidOperationException("Only checked-in reservations can be checked out.");
       }

       this.Status = ReservationStatus.CheckOut; 
   }

   public void Canceled()
   {
       if (Status != ReservationStatus.Pending && Status != ReservationStatus.Confirmed)
       {
           throw new InvalidOperationException("Reservation cannot be cancelled at this stage.");
       }

       this.Status = ReservationStatus.Canceled; 
   }
}