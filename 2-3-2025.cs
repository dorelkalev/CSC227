

int numItems = 10;

static void Main(string[] args) {
//Printing to screen:
//Console.WriteLine("..") - prints to screen and moves cursor 
//Console.Write("..") - prints to screen and leaves cursor 
Console.WriteLine("Hello, World!");
Console.Write("So glad we made it into the lab!");
Console.WriteLine("Now I can teach yippie!");

//Accept normal escape sequences:
// \n, \\, \", \t, ...

//Data Types!
//We don't have pritive data types.
//C# is an object oriented programming language.

//ints, doubles, floats, chars, bool
int num1 = 10;
int num2 = 654;
int num3 = -3478;
float f1 = 5.7f;
bool isLabOpen = true;
char letter = 'r';

//Math!
//+, -, *, /, %
int num4 = num1 + num2;
Console.WriteLine("The sum of " + num1 + " and " + num2 + " is " + num4);

int difference = num3 - num2;

int product = num1 * num2;

//**** Whenever a float is involved in math, your answer variable
//**** must be of type float! (or double)
float prod = num1 * f1;

//Selection Statements
//if, if-else, if-else-if.....
//switch
if (num1 > num2)
{
  Console.WriteLine("Unity");
} else
{
  Console.WriteLine("Nope");
}

//Input:
Console.WriteLine("What is the best game?\n");
Console.WriteLine("1. Sekiro Shadows Die Twice");
Console.WriteLine("2. Shadows of Chernobyll");
Console.WriteLine("3. Hearts of Iron 4");
Console.WriteLine("4. Mario Sunshine");
Console.WriteLine("5. Goldeneye 007");
Console.Write("Option: ");
int option = int.Parse(Console.ReadLine());
switch (option) {
  case 1: Console.WriteLine("Why?");
    break;
  case 2: Console.WriteLine("Stay away from radiation!");
    break;
  case 3: Console.WriteLine("Sounds like there were three before it");
    break;
  case 4: Console.WriteLine("Clean the crap");
    break;
  case 5: Console.WriteLine("Shaken not stirred");
    break;
  default: Console.WriteLine("What?");
    break;
}

//Loops!
//for, while, do-while, foreach
for(int i = 0; i < 10; i++)
{
    Console.WriteLine(i);
}
Console.WriteLine();

string answer;
do 
{
  //WORST GAME OF ALL THE TIMES!
  Console.WriteLine("You are playing the worst game of all time.");
  Console.Write("Would you like to play again? (Y/N)");
  answer = Console.ReadLine();
} while (answer != "N")
  Console.WriteLine("You escaped!");

int index = 0;
while(index < 10) 
{
Console.WriteLine(index);
index++;
}

//Collections!
//Arrays and Lists
//Both hold a collection of data of the same type.
//Arrays are of static size.
int[] data = new int[numItems];
//Random numbers! 
Random rng = new Random();
for(int i = 0; i < data.length; i++)
{
data[i] = rng.Next(20, 41); //gives # between 20 and 40
}

//Print out the data!
//A foreach loop is used to traverse a collection.
//It goes from the first item to the last
//YOU CANNOT ALTER THE COLLECTION IN A FOREACH LOOP~~~~~
//YOU DO NOT HAVE AN INDEX TO GO AND CHANGE THE DATA
foreach (int nummy in data)
{
Console.WriteLine(nummy);
}

//Lists
//List can change size dynamically during run time
//The trade off is that they take up more memory than
//an array
List<int> list = new List<int>();
list.Add(65);
list.Add(-534);
list.Add(38);
list.Add(520);
list.Insert(1, 888);
//I can add to a valid location
Console.WriteLine(list);

for(int i = 0; i < list.Count; i++) {
Console.WriteLine(list[i]);  
}
}







