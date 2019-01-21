using UnityEngine;

public class Hacker : MonoBehaviour {

    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;
    string[] level1Password = { "books", "shelf", "study", "read","library","page","card" };
    string[] level2Password = { "syringe","drugs","capsule","antibiotic","scalpel","surgery" };
    string[] level3Password = { "aeronautics", "trajectory", "vector", "dilation", "Armstrong", "propulsion","fuel tanks","Sputnik","Apollo" };

    // Use this for initialization
    void Start () {
        ShowMainMenu();
        

    }
    void ShowMainMenu() {
        Terminal.ClearScreen();
        currentScreen = Screen.MainMenu;
        Terminal.WriteLine("Welcome to Terminal Hacker");
        Terminal.WriteLine("Press 1 to hack the library");
        Terminal.WriteLine("Press 2 to hack the public hospital");
        Terminal.WriteLine("Press 3 to hack NASA");
        
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }

        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }


    }

     void RunMainMenu(string input)
    {
        bool ValidLevelNum = (input == "1" || input == "2" || input=="3");
        if (ValidLevelNum)
        {
            level = int.Parse(input);
            
            GetPassword();
        }
        //easter eggs
        else if (input == "666")
        {
            Terminal.WriteLine("Not enough for our Lord");
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Mr.Bond, these are your final hours!");
        }
        else
        {
            Terminal.WriteLine("haven't programmed that path yet");
        }
    }

    void GetPassword()
    {

        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        LevelScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter the password,hint: " + password.Anagram());
        

       

    }

   void SetRandomPassword()

    {
        switch (level)
        {
            case 1:

                password = level1Password[Random.Range(0, level1Password.Length)];
                break;
            case 2:
                password = level2Password[Random.Range(0, level2Password.Length)];
                break;
            case 3:
                password = level3Password[Random.Range(0, level3Password.Length)];
                break;


        }
    }

    void CheckPassword(string  input)
    {
        if(input==password)
        {
            ShowWinScreen();

        }
        else
        {
            GetPassword();

        }
    }
    void LevelScreen()
    {
        switch(level)
        {
            case 1:Terminal.WriteLine(@"
Welcome to the Library
                       ");


                break;
            case 2:
                Terminal.WriteLine(@"
 ThePublicHospital™ welcomes you!


 Please verify to issue supplies!");
                break;
            case 3:
                Terminal.WriteLine(@"
 _ __   __ _ ___  __ _ 
| '_ \ / _` / __|/ _` |
| | | | (_| \__ \ (_| |
|_| |_|\__,_|___/\__,_|
                       ");
                break;
        }
    }

     void ShowWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        WinReward();
        Terminal.WriteLine("Type 'menu' to go to menu");
    }

     void WinReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Book issued!");
                Terminal.WriteLine(@"
    _______
   /      /,
  /      //
 /______//
(______(/                        ");
                break;
            case 2:
                Terminal.WriteLine("Drug supply salvaged!");
                Terminal.WriteLine(@"
......
:.  .:
.'  '.
|    |
|    |
`----'      ");
                break;
            case 3:
               
                Terminal.WriteLine(@"
      .
      |
     / \
    / _ \
   |.o '.|
   |'._.'|
   |     |
 ,'|  |  |`.
/  |  |  |  \
|,-'--|--'-.|    ");
                Terminal.WriteLine("Apollo 18 confirmed");
                break;
        }

    }
    void MenuHint()
    {
        Terminal.WriteLine("YOu can access the menu by typing 'menu' anytime");
    }
}
