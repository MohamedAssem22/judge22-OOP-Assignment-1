namespace Part2_HotelReservationSystem;

public class Guest
{
    public int GuestId { get;  init; }
    public string FullName { get; init; }
    public string PhoneNumber { get; init; }
    private  List<Reservation> _reservationsList = new List<Reservation>();
    public IReadOnlyList<Reservation> ReservationsList => _reservationsList.AsReadOnly();


    public Guest(int guestId, string fullName, string phoneNumber)
    {
        if (guestId < 0)
        {
            throw new ArgumentException("Guest id cannot be negative ... ");
        }
        this.GuestId = guestId;
        
        
        
        if (string.IsNullOrEmpty(phoneNumber) || string.IsNullOrWhiteSpace(phoneNumber))
        {
            throw new ArgumentException("Phone number cannot be null or empty ..."); 
        }
        this.PhoneNumber = phoneNumber; 
        
        
        if (string.IsNullOrEmpty(fullName) || string.IsNullOrWhiteSpace(fullName))
        {
            throw new ArgumentException("Phone number cannot be null or empty ..."); 
        } 
        this.FullName = fullName; 
        
        
    }
    
    public void AddReservation(Reservation reservation)
    {
        if (reservation == null)
        {
            throw new ArgumentException("reservation cannot be null"); 
        }
        this._reservationsList.Add(reservation);
    }
}