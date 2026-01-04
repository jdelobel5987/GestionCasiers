namespace GestionCasiers.Models
{
    class Casier
    {
        // Fields

        // unnecessary backing fields (auto-implemented properties)
        //private int _id;
        //private string _dimension;
        //private string _location;
        //private string _code; // 4-digits code for secured access (set at deposit, required at withdrawal)
        //private int _failedAttempts; // to track failed attempts for secured access
        private bool _isOpen;
        private bool _isOccupied;

        // Properties
        public int Id { get; private set; }     // auto-implemented property --> no need for backing field
        public string Dimension { get; }
        public string Location { get; }
        public string Code { get; private set; }
        public int FailedAttempts { get; private set; }
        public bool IsBlocked
        {
            get => FailedAttempts >= 3;
        }

        public bool IsOpen
        {
            get => _isOpen;
            private set
            {
                // TODO: implement logic for secured access if IsOccupied
                _isOpen = value;
            }
        }
        public bool IsOccupied
        {
            get => _isOccupied;
            private set
            {
                _isOccupied = value;
            }
        }

        // Constructor
        public Casier(int id, string dimension, string location, string code = "0000", int failedAttempts = 0, bool isOccupied = false, bool isOpen = false)
        {
            Id = id;
            Dimension = dimension;
            Location = location;
            Code = code;
            FailedAttempts = failedAttempts;
            IsOpen = isOpen;
            IsOccupied = isOccupied;
        }

        // Member Methods
        public void Info()
        {
            Console.WriteLine($"Casier ID: {Id}");
            Console.WriteLine($"Dimension: {Dimension}");
            Console.WriteLine($"Location: {Location}");
            Console.WriteLine($"Is Open: {IsOpen}");
            Console.WriteLine($"Is Occupied: {IsOccupied}");
        }

        public void Deposit()
        {
            if (IsOccupied)
            {
                Console.WriteLine($"Casier {Id} is occupied. Choose another Casier.");
                return;
            }

            Console.WriteLine($"Opening Casier {Id} for deposit...");
            Open();

            Console.WriteLine($"You can now deposit your items in Casier {Id} and close it.");
            IsOccupied = true;

            // TODO: implement user input for a 4-digit code to lock the Casier
            // TODO: store the code securely

            Close();

        }

        public void Withdraw()
        {
            if (!IsOccupied)
            {
                Console.WriteLine($"Casier {Id} is empty. Please select another Casier.");
                return;
            }

            Console.WriteLine($"Opening Casier {Id} for withdrawal...");

            // TODO: if (IsOccupied) VerifyAccess();

            Open();

            Console.WriteLine($"You can now withdraw your items from Casier {Id} and close it.");
            IsOccupied = false;

            Close();
        }

        public void Open()
        {
            Console.WriteLine($"Attempting to open Casier {Id}...");

            if (IsOpen)
            {
                Console.WriteLine($"Casier {Id} is already open.");
                return;
            }

            IsOpen = true;
            Console.WriteLine($"Casier {Id} is now open.");

        }

        public void Close()
        {
            Console.WriteLine($"Attempting to close Casier {Id}...");

            if (!IsOpen)
            {
                Console.WriteLine($"Casier {Id} is already closed.");
                return;
            }

            // TODO: if IsOccupied -> ask user to set a 4-digit code to lock the Casier
            // TODO: set code securely

            // TODO: if !IsOccupied -> reset stored code

            IsOpen = false;
            Console.WriteLine($"Casier {Id} is now closed.");
        }

        // TODO: implement VerifyAccess method to verify 4-digit code
        // public bool VerifyAccess()
        // {
            // prompt user for 4-digit code
            // compare to stored code
            // return true if match

            // implement retry logic with max attempts (3)
            // return false if exceeded attempts
        // }
    }

}