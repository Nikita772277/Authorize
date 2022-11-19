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
        private string _way= @"C:\Users\Студент 3\Desktop\Users.txt";
        private void SetLogin()
        {
            while (true)
            {
                Console.WriteLine($"Введите логин");
                string login = Console.ReadLine();
                bool a = CheckLogin(login);
                if (a == true)
                {
                    break;
                }
            }
        }
        private bool CheckLogin(string login)
        {
            using(StreamReader reader=new StreamReader(_way))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    if(login == line) 
                    {
                        return true;
                    }
                    else 
                    {
                                             
                    }
                }
                if(line == null)
                {
                    Console.WriteLine($"Логин не найден");
                }
            }
            return false;
        }
        private void SetPassword()
        {
            while (true)
            {
                Console.WriteLine($"Введите пароль");
                string password = Console.ReadLine();
                bool a = CheckPassword(password);
                if (a == true)
                {
                    break;
                }
            }
        }
        private bool CheckPassword(string password)
        {
            using (StreamReader reader = new StreamReader(_way))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (password == line)
                    {
                        return true;
                    }
                    else
                    {
                                          
                    }
                }
                if (line == null)
                {
                    Console.WriteLine($"Пароль не найден");
                }
            }
            return false;
        }
        public void UserAuthorization()
        {
            SetLogin();
            SetPassword();
        }
    }
}
