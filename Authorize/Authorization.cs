using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorize
{
    internal class Authorization
    {
        public static Dictionary<string, string> _authorization;
        private string _login;
        public Authorization()
        {
            _authorization = new Dictionary<string, string>();
        }
        private string _way= @"C:\Users\Студент 3\Desktop\Users.txt";
        public void Get()
        {
            foreach (var key in _authorization.Keys)
            {
                Console.Write($"{key} - " );
                foreach (var value in _authorization[key])
                {
                    Console.Write(value);
                }
                Console.WriteLine();
            }
        }
        private bool SetLogin()
        {
            for (int i = 3; i > 0; i--)
            {
                Console.WriteLine($"Введите логин");
                string login = Console.ReadLine();
                bool a = CheckLogin(login);
                if (a == true)
                {
                    _login = login;
                    return true;
                    break;
                }
                else
                {
                    Console.WriteLine($"логин введён неверно осталось попыток - {i}");
                    Console.WriteLine();                    
                }
            }
            return false;
        }
        private bool CheckLogin(string login)
        {
            bool verifiedpassword = _authorization.ContainsKey(login);
            if(verifiedpassword == true)
            {
                return true;
            }
            return false;
        }
        private bool SetPassword()
        {
            for (int i = 3; i > 0; i--)
            {
                Console.WriteLine($"Введите пароль");
                string password = Console.ReadLine();
                bool a = CheckPassword(password);
                if (a == true)
                {
                    return true;
                    break;
                }
                else
                {
                    Console.WriteLine($"Пароль введён неверно осталось попыток - {i}");
                    Console.WriteLine();
                }
            }
            return false;
        }
        private bool CheckPassword(string password)
        {
            bool verifiedkey = _authorization.TryGetValue(_login, out var foundelement);
            try
            {
                var verifiedvalue = foundelement.Contains(password);
                if (verifiedvalue == true)
                {
                    return true;
                }
                else { return false; }
            }
            catch
            {
                Console.WriteLine($"Ошибка");
                return false;
            }      
            return false;
        }
        public void UserAuthorization()
        {
            bool check= SetLogin();
            if (check == true) 
            {
                bool check2= SetPassword();
                if(check2 == true)
                {
                    Console.WriteLine($"Вы вошли в систему");
                }
                else
                {
                    Console.WriteLine($"Пароль не подходит попробуйте снова позже");
                }
            }
            else
            {
                Console.WriteLine($"Логин не подходит попробуйте снова позже");
            }
        }
    }
}
