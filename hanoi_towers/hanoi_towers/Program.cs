namespace hanoi_towers{
    internal class Program{
        class Stick{
            // Define the stick class, which has a name and an array of disks
            public string name { get; set; }
            public int[] diskArray { get; set; }
            public Stick(string name, int diskCount){
                this.name = name;
                diskArray = new int[diskCount];
            }
            // Load the disk to the stick
            public void loadDisk(int diskSize){
                for (int i = 1; i < diskSize + 1; i++)
                    this.diskArray[i - 1] = diskArray.Length + 1 - i;
            }
            // Print the disk in the stick
            public void printInside(){
                foreach (int disk in diskArray)
                    Console.Write(disk + " ");
                Console.WriteLine();
            }
        }
        // Move the disk from source to destination
        static void hanoi(int n, Stick source, Stick destination, Stick middle){
            if (n == 1)
                Console.WriteLine("Moved the top disk from " + source.name + " to " + destination.name);
            else{
                hanoi(n - 1, source, middle, destination);
                hanoi(1, source, destination, middle);
                hanoi(n - 1, middle, destination, source);
            }
        }
        static void Main(string[] args){
            Console.WriteLine("How many disk we have in game?");
            int diskCount = Convert.ToInt32(Console.ReadLine());
            // Create 3 sticks
            Stick sourceStick = new Stick("Source", diskCount);
            Stick destStick = new Stick("Destination", diskCount);
            Stick midStick = new Stick("Middle", diskCount);
            sourceStick.loadDisk(diskCount);
            // Print the disk in the source stick
            Console.WriteLine("Current sourceStick:");
            sourceStick.printInside();
            // Start the game
            hanoi(diskCount, sourceStick, destStick, midStick);
            // Print the disk in the sticks after the game
            Console.WriteLine("Source stick:");
            sourceStick.printInside();
            // Print the disk in the destination stick
            Console.WriteLine("\nDestination stick:");
            destStick.printInside();
            // Print the disk in the middle stick
            Console.WriteLine("\nMiddle stick:");
            midStick.printInside();
        }
    }
}
