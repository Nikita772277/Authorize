using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Authorize
{
    internal class Registration
    {
        private string _way = @"C:\Users\Студент 3\Desktop\Users.txt";
        public void SetWay()
        {
            Console.WriteLine($"Введите имя пользователя windows");
            string path = Console.ReadLine();
            _way = $@"C:\Users\{path}\Desktop\Users.txt";
        }
        private string SetLogin()
        {
            string login;
            while (true)
            {
                Console.WriteLine($"В логине должно быть минимум 4 символа");
                Console.WriteLine();
                Console.WriteLine($"Введите логин");
                login = Console.ReadLine();
                bool c = LoginIsBusy(login);
                if (c == true)
                {
                    bool a = CheckLogin(login);
                    if (a == true) { break; }
                }
            }
            using (StreamWriter writer = new StreamWriter(_way, true))
            {
                writer.Write ($"{login} ");
            }
            return login;
        }
        private bool LoginIsBusy(string login)
        {
            using (StreamReader reader = new(_way))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    var check= line.Split(' ');
                    if (login == check[0])
                    {
                        Console.WriteLine($"Логин занят");
                        Console.WriteLine();
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool CheckLogin(string login)
        {
            int number = 0;
            foreach (var pair in login)
            {
                if (pair != ' ')
                {
                    number++;
                }
            }
            if (number < 4)
            {
                Console.WriteLine($"Логин не валиден");
                Console.WriteLine();
                return false;
            }
            else
            {
                Console.WriteLine($"Логин валиден");
                Console.WriteLine();
                return true;
            }
        }
        private string SetPassword()
        {
            string password;
            while (true)
            {
                Console.WriteLine($"В пароле должно состоять минимум из 8 символов 2 из которых знаки препинания либо любые другие и одной заглавной буквы");
                Console.WriteLine();
                Console.WriteLine($"Введите пароль");                
                password = Console.ReadLine();
                    bool check2 = CheckPassword(password);
                    if (check2 == true) { break; }
            }
            using (StreamWriter writer = new StreamWriter(_way, true)) { writer.Write($"{password} "); }
            return password;
        }     
        private bool CheckPassword(string password)
        {
            bool a=false;
            bool check=false;
            int numberchar = 0;
            int numbersymbol = 0;
            foreach (var pair in password)
            {
                if (char.IsSymbol(pair)==true|| char.IsPunctuation(pair)==true)
                {
                    numbersymbol++;
                    if (numbersymbol >= 2)
                    {
                        check = true;
                    }
                }
                if (char.IsUpper(pair) == true) 
                    a=true;
                if (pair != ' ')
                {
                    numberchar++;
                }
            }
            if (numberchar < 8||a!=true||check!=true)
            {
                Console.WriteLine($"Пароль не валиден");
                Console.WriteLine();
                return false;
            }
            else
            {
                Console.WriteLine($"Пароль валиден");
                return true;
            }
        }
        private string Setnumber()
        {
            while (true)
            {
                Console.WriteLine($"Введите ваш номер телефона");
                Console.WriteLine();
                Console.WriteLine($"Пример ввода 81234567890");
                string number = Console.ReadLine();
                bool check = CheckNumber(number);
                if (check == true)
                {
                    using (StreamWriter writer = new StreamWriter(_way, true)) { writer.WriteLine($" {number}"); }
                    return number;
                    break;
                }
                else
                {
                    Console.WriteLine($"Вы ввели не подходяший условиям номер");
                    Console.WriteLine();
                }
            }
            return "";
        }
        private bool CheckNumber(string number)
        {
            Regex regex = new(@"^+7\d{10}$");
            Regex regex2 = new(@"^8 [0-9]{3} [0-9]{3} [0-9]{2} [0-9]{2}$");
            Regex regex3 = new(@"^8\d{10}");
            var r= regex.IsMatch(number);
            var r2= regex2.IsMatch(number);
            var r3= regex3.IsMatch(number);
            if(r== true || r2 == true||r3==true)
            {
                Console.WriteLine($"Номер подходит");
                return true;
            }
            else { return false; }            
            return false;
        }
        public async void DataFile()
        {
            using (StreamReader reader = new StreamReader(_way))
            {
                string? line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    var data= line.Split(' ');
                    if (data.Length > 1)
                    {
                        Authorization._authorization.Add(data[0], data[1]);
                    }
                }

            }
        }//возможно сломал
        public void UserRegistration()
        {
            FileInfo fileInfo = new FileInfo(_way);
            if (!fileInfo.Exists)
            {
                using (File.Create(_way)) ;
            }
            string login= SetLogin();
            string password= SetPassword();
            Setnumber();
            Console.WriteLine();
            Console.WriteLine($"Вы успешно зарегистрировались");
            Console.WriteLine();
            Authorization._authorization.Add(login, password);
        }
    }
}
