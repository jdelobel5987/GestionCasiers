namespace GestionCasiers.Models
{
    class Casier
    {
        // Fields
        private bool _isOpen;
        private bool _isOccupied;

        // Properties
        //// auto-implemented property --> no need for backing field
        public int Id { get; private set; }     
        public string Dimension { get; }
        public string Location { get; }
        public string Code { get; private set; }
        public int FailedAttempts { get; private set; }

        //// custom property with get/set logic
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

            // if isOccupied, VerifyAccess()
            // else: see below code
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

            // TODO: if IsOccupied -> SetCode() ; else -> reset code

            IsOpen = false;
            Console.WriteLine($"Casier {Id} is now closed.");
        }

        // TODO: implement VerifyAccess method to verify 4-digit code
        // private bool VerifyAccess()
        // {
            // prompt user for 4-digit code
            // compare to stored code
            // return true if match

            // implement retry logic with max attempts (3)
            // return false if exceeded attempts
        // }

        //TODO: implement SetCode method to set a new 4-digit code
        // private void SetCode()
        // {
            // prompt user for new 4-digit code
            // validate input
            // store code securely
        // }
    }

}