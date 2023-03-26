Door door = new Door(1234);

door.Open(1234);
door.Close(1234);

class Door
{
    private int Passcode { get; set; }

    private DoorStates OpenState { get; set; }
    private DoorStates LockState { get; set; }

    public void Open(int pass)
    {
        if (pass == Passcode)
        {
            if (OpenState == DoorStates.Closed && LockState == DoorStates.Unlocked)
            {
                OpenState = DoorStates.Open;
                LogDoorState();
            }
        }
        else
        {
            Console.WriteLine("Wrong Pass Code.");
        }
    }
    public void Close(int pass)
    {
        if (pass == Passcode)
        {
            if (OpenState == DoorStates.Open)
            {
                OpenState = DoorStates.Closed;
                LogDoorState();
            }
        }
        else
        {
            Console.WriteLine("Wrong Pass Code.");
        }
    }
    public void Lock(int pass) 
    {
        
    }
    public void Unlock(int pass) 
    {
        
    }

    public void LogDoorState()
    {
        Console.WriteLine($"The Door is {OpenState}");
    }

    public Door(int passcode)
    {
        Passcode = passcode;
        OpenState = DoorStates.Closed;
        LockState = DoorStates.Unlocked;
    }

    enum DoorStates { Open, Closed, Locked, Unlocked }
}