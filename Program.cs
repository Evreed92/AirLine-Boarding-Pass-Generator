//Origins: Springfield (SGF) Tulsa (TUL)
//Destination: Denver (DEN) Chicago-Midway (MDW) Dallas (DAL)

using System.Numerics;

double[,] flightCosts =
{
    {153, 124, 186},
    {110, 139, 74}
};

string[,] flightNumbers = //{origin,destination]
{
    {"A0137", "A0142", "A0117"},
    {"A0237", "A0242", "A0217"}
};

Console.WriteLine("Passenger Name: First Last");
string name = Console.ReadLine().ToUpper();

//prompt origin SGF or TUL
int originIndex = 0;
string origin;
bool isValid = false;
do
{
    Console.WriteLine("Origin: Springfield(SGF) Tulsa(TUL)");
    origin = Console.ReadLine().ToUpper();
    switch (origin)
    {
        case "SGF":
            originIndex = 0;
            isValid = true;
            break;
        case "TUL":
            originIndex = 1;
            isValid = true;
            break;
        default:
            isValid = false;
            break;
    }
} while (isValid == false);

//Prompt destination DEN, MDW, DAL
int destinationIndex = 0;
string destination;
isValid = false;
do
{
    Console.WriteLine("Destination: Denver(DEN) Chicago-Midway(MDW) Dallas(DAL)");
    destination = Console.ReadLine().ToUpper();
    switch (destination)
    {
        case "DEN":
            destinationIndex = 0;
            isValid = true;
            break;
        case "MDW":
            destinationIndex = 1;
            isValid = true;
            break;
        case "DAL":
            destinationIndex = 2;
            isValid = true;
            break;
        default:
            break;
    }
} while (isValid == false);
//look up base airfare
double baseCost = flightCosts[originIndex, destinationIndex];
double total = baseCost;

Console.WriteLine("Total Base: " + total.ToString("C"));
//prompt extra cost 30 for first bag 40 for second bad
isValid = false;
do
{
    Console.WriteLine("How many checked bags? 0 = $0 First(1) = $30, Second(2) = $40");
    int numBags = Convert.ToInt32(Console.ReadLine());
    if (numBags == 1)
    {
        total += 30.00;
        isValid = true;
    }
    else if (numBags == 2)
    {
        isValid = true;
        total += 70.00;
    }
} while (isValid = false);
Console.WriteLine("Total + Bags:\t" + total.ToString("C"));

//9.11 Security Fee 5.60
Console.WriteLine("Security Fee $5.60");
total += 5.60;
Console.WriteLine("Total + 5.60:\t" + total.ToString("C"));

//Passenger Charges 18
Console.WriteLine("Passenger Charges $18.00");
total += 18;
Console.WriteLine("Total + 18:\t" + total.ToString("C"));

//Government Excise Tax: 4 per segment + 7.5% of flight cost
Console.WriteLine($"Tax $4.00 per segment + 7.5% Flight Cost ({baseCost * .075})");
total += baseCost * .075 + 4;
Console.WriteLine("Total + Tax:\t" + total.ToString("C"));

//generate Seat
string flightNumber = flightNumbers[originIndex, destinationIndex];
Console.WriteLine("Seat Choices");
Console.WriteLine("Row (1 - 32)");
string row = Console.ReadLine();
Console.WriteLine("Seat (A - F)");
string seat = Console.ReadLine().ToUpper();
string userSeat = row + seat;


Console.Clear();


//Generate Boarding Pass
Console.WriteLine("S K Y  A I R L I N E S  P A S S");
Console.WriteLine("");
Console.WriteLine("  Passenger Name\tDate");
Console.WriteLine("  "+name +"\t\t25JUL");
Console.WriteLine("");
Console.WriteLine("  From\t\tFlight\tSeat");
Console.WriteLine($"  {origin}\t\t{flightNumbers[originIndex, destinationIndex]}\t{userSeat}");
Console.WriteLine("");
Console.WriteLine("  To\t\tGate\tFare");
Console.WriteLine($"  {destination}\t\t18\t{total.ToString("C")}");