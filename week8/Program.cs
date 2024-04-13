string folderPath = @"C:\\data\";
string heroFile = "heroes.txt";
string villianFile = "villains.txt";


string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villianFile));
string[] weapon = { "magic wand", "plastic fork", " banana", "orange" };




string hero = GetRandomValueFromArray(heroes);
string heroWeapon = GetRandomValueFromArray(weapon);
int heroHP = GetCharacterHP(hero);
int heroStrikeStrength = heroHP;
Console.WriteLine($"Today {hero} ({heroHP}) with {heroWeapon} saves theday!");

string villain = GetRandomValueFromArray(villains);
string villianWeapon = GetRandomValueFromArray(weapon);
int villainHP = GetCharacterHP(villain);
int villianStrikeStrength = villainHP;

Console.WriteLine($"Today {villain} ({villainHP}) with {villianWeapon}  tries to takeover!");

while (heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, villainHP);
    villainHP = villainHP - Hit(hero, heroHP);
}

Console.WriteLine($"Hero {hero}  HP: {heroHP}");
Console.WriteLine($"Hero {villain}  HP: {villainHP}");

if (heroHP > 0)
{
    Console.WriteLine($"{hero} saves the day!");
}
else if (villainHP > 0)
{
    Console.WriteLine("Dark side wins!");
}
else
{
    Console.WriteLine("Draw!");
}

static string GetRandomValueFromArray(string[] someArray)
{
    Random rnd = new Random();
    int randomIndex = rnd.Next(0, someArray.Length);
    string randomStringFromArray = someArray[randomIndex];
    return randomStringFromArray;
}

static int GetCharacterHP(string characterName)
{
    if (characterName.Length < 10)
    {
        return 10;
    }
    else
    {
        return characterName.Length;
    }
}

static int Hit(string characterName, int characterHP)
{
    Random rnd = new Random();
    int strike = rnd.Next(0, characterHP);
    if (strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target");
    }
    else if (strike == characterHP - 1)
    {
        Console.WriteLine($"{characterName} hit {strike}!");
    }
    return strike;
}