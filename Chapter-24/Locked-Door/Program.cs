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
            else if (OpenState == DoorStates.Open)
            {
                Console.WriteLine("The Door is already Open.");
            }
            else if (LockState == DoorStates.Locked)
            {
                Console.WriteLine("The Door is Locked.");
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
            else if (OpenState == DoorStates.Closed)
            {
                Console.WriteLine("The Door is already Closed.");
            }
        }
        else
        {
            Console.WriteLine("Wrong Pass Code.");
        }
    }

    public void Lock(int pass)
    {
        if (pass == Passcode)
        {
            if (OpenState == DoorStates.Closed && LockState == DoorStates.Unlocked)
            {
                LockState = DoorStates.Locked;
                LogDoorState();
            }
            else if (OpenState == DoorStates.Open)
            {
                Console.WriteLine("The door is already Open, it can't be Locked.");
            }
            else if (LockState == DoorStates.Locked)
            {
                Console.WriteLine("The Door is already locked.");
            }
        }
        else
        {
            Console.WriteLine("Wrong Pass Code.");
        }
    }

    public void Unlock(int pass)
    {
        if (pass == Passcode)
        {
            if (OpenState == DoorStates.Closed && LockState == DoorStates.Locked)
            {
                LockState = DoorStates.Unlocked;
                LogDoorState();
            }
            else if (OpenState == DoorStates.Open)
            {
                Console.WriteLine("The Door is already Open, it can't be Unlocked.");
            }
            else if (LockState == DoorStates.Unlocked)
            {
                Console.WriteLine("The Door is already Unlocked.");
            }
        }
        else
        {
            Console.WriteLine("Wrong Pass Code.");
        }
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