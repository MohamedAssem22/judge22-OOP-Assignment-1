namespace Part2_HotelReservationSystem;

public enum RoomType
{
    Single,
    Double,
    Suite
}
public class Room
{
    public int RoomNumber { get; init; }
    public RoomType RoomType { get; init; }
    public decimal NightlyRate { get; private set; }
    public bool IsUnderMaintenance { get; private set; }
    
 
    public Room(int roomNumber, RoomType roomType, decimal nightlyRate)
    {
        if (roomNumber <= 0)
        {
            throw new ArgumentException("Room Number cannot be negative."); 
        }

        this.RoomNumber = roomNumber; 
        
            
        
        
        UpdateNightlyRate(nightlyRate);
        
    }

    public void UpdateNightlyRate(decimal nightlyRate)
    {
        if (nightlyRate < 0)
        {
            throw new ArgumentException("Nightly rate cannot be negative."); 
        }

        this.NightlyRate = nightlyRate; 
    }
    public void StartMaintenance()
    {
        if (IsUnderMaintenance)
        {
            throw new InvalidOperationException("Room is already under maintenance.");
        }
        IsUnderMaintenance = true;
    }

    public void EndMaintenance()
    {
        if (!IsUnderMaintenance)
        {
            throw new InvalidOperationException("Room is not currently under maintenance.");
        }

        IsUnderMaintenance = false;
    }
    
   
}
