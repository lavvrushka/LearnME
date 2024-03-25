using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace LearnMe.Utils
{
    public class PasswordHasher
    {
        // Метод для хэширования пароля
        public static string HashPassword(string password)
        {
            // Создание объекта для вычисления SHA256 хэша
            SHA256 sha256 = SHA256.Create();

            // Преобразование пароля в массив байтов
            byte[] passwordBytes = Encoding.ASCII.GetBytes(password);

            // Вычисление хэша для массива байтов пароля
            byte[] hashBytes = sha256.ComputeHash(passwordBytes);

            // Преобразование массива байтов хэша в строку шестнадцатеричного представления
            string hashPassword = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

            // Возвращение хэшированного пароля
            return hashPassword;
        }

        // Метод для проверки соответствия пароля и его хэшированной версии
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            // Хэширование введённого пароля
            string inputHash = HashPassword(password);

            // Сравнение хэша введённого пароля с сохранённым хэшем
            return inputHash == hashedPassword;
        }
    }
}
