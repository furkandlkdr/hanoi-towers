namespace hanoi_towers{
    internal class Program{
        class Stick{
            public string name { get; set; }
            public int[] diskArray { get; set; }
            public Stick(string name, int diskCount){
                this.name = name;
                diskArray = new int[diskCount];
            }
            public void loadDisk(int diskSize){
                for (int i = 1; i < diskArray.Length + 1; i++)
                    this.diskArray[i - 1] = diskArray.Length + 1 - i;
            }
            public void printInside(){
                foreach (int disk in diskArray)
                    Console.Write(disk + " ");
                Console.WriteLine();
            }
        }
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
            Stick sourceStick = new Stick("A", diskCount);
            Stick destStick = new Stick("B", diskCount);
            Stick midStick = new Stick("C", diskCount);
            sourceStick.loadDisk(diskCount);
            Console.WriteLine("Current sourceStick:");
            sourceStick.printInside();
            hanoi(diskCount, sourceStick, destStick, midStick);
            Console.WriteLine("Source stick:");
            sourceStick.printInside();
            Console.WriteLine("\nDestination stick:");
            destStick.printInside();
            Console.WriteLine("\nMiddle stick:");
            midStick.printInside();
        }
    }
}
