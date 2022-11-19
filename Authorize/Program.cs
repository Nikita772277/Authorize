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
    while (true)
    {
        Menu();
        string enter = Console.ReadLine();
        Console.WriteLine();
        bool chek = int.TryParse(enter, out int result);
        if (result == 1)
        {
            registration.UserRegistration();
        }
        else if (result == 2)
        {
            authorization.UserAuthorization();
            Console.WriteLine($"Вы вошли в систему");
        }
        else
        {
            Console.WriteLine($"Выберите пункт из меню");
        }
    }
}
GetMenu();
