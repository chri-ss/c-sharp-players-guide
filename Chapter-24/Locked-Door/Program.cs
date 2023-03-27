Console.WriteLine("Enter a passcode for a new door");

int pass = Convert.ToInt32(Console.ReadLine());

Door door = new Door(pass);

while (true)
{
    Console.WriteLine("What would you like to do?\n 1. Open the Door\n 2. Close the Door\n 3. Lock the Door\n 4. Unlock the door\n 5. Set new password");

    int response = Convert.ToInt32(Console.ReadLine());

    switch (response)
    {
        case 1:
            door.Open();
            break;
        case 2:
            door.Close();
            break;
        case 3:
            door.Lock();
            break;
        case 4:
            Console.WriteLine("Please enter the password:");
            pass = Convert.ToInt32(Console.ReadLine());
            door.Unlock(pass);
            break;
        case 5:
            Console.WriteLine("Enter a new password:");
            pass = Convert.ToInt32(Console.ReadLine());
            door.UpdatePass(pass);
            break;

        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}

class Door
{
    private int Passcode { get; set; }

    private DoorStates OpenState { get; set; }
    private DoorStates LockState { get; set; }

    public void Open()
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

    public void Close()
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

    public void Lock()
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

    public void UpdatePass(int newPass)
    {
        Console.WriteLine("Please enter the old Password to change:");
        int old = Convert.ToInt32(Console.ReadLine());

        if (old == Passcode)
        {
            Passcode = newPass;
        }
        else
        {
            Console.WriteLine("Wrong Pass");
        }
    }

    public void LogDoorState()
    {
        Console.WriteLine($"The Door is {OpenState} and {LockState}");
    }

    public Door(int passcode)
    {
        Passcode = passcode;
        OpenState = DoorStates.Closed;
        LockState = DoorStates.Unlocked;
    }

    enum DoorStates { Open, Closed, Locked, Unlocked }
}