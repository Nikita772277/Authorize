using Authorize;

Registration registration = new Registration();
Authorization authorization = new Authorization();
void Menu()
{
    Console.WriteLine();
    Console.WriteLine($"1) Регистрация");
    Console.WriteLine($"2) Авторизация");
    Console.WriteLine();
}
void GetMenu()
{
    registration.SetWay();
    registration.DataFile();
    while (true)
    {
        Menu();
        string enter = Console.ReadLine();
        Console.WriteLine();
        bool chek = int.TryParse(enter, out int result);
        if (result == 1)
        {
            registration.UserRegistration();
            return;
        }
        else if (result == 2)
        {
            authorization.UserAuthorization();
            return;
        }
        else if (result == 3)
        {
            authorization.Get();
            return;
        }
        else
        {
            Console.WriteLine($"Выберите пункт из меню");
        }
    }
}
GetMenu();
