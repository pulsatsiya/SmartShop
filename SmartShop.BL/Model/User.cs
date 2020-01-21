using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.BL.Model
{
    [Serializable]
   public class User
    {
        // TODO: реализовать пароль.
        public string Name { get; set; }
        
        public string Email { get; set; }
        public DateTime Birthday { get; set; } 

        public int Age { get { return DateTime.Now.Year - Birthday.Year; } } // TODO: Считает не точно, надо посмотреть в интернете правильный подход.

        // Ниже был конструктор, как и в моделе Smartphone, но потом переделал так, что нужно вводить только имя пользователя в вьюшке.
        // Он сам решит: если такого пользователя нет в данных, то попросит ввести дополнителные данные  (дату рождения и email).

        #region это ненужный конструктор
        // public User(string name, DateTime birthday, string email)
        //  {
        //      #region Проверка условии
        //      if (string.IsNullOrWhiteSpace(name))
        //      {
        //          throw new ArgumentNullException("Имя пользователя не может быть пустым или null", nameof(name));
        //      }
        //      if (birthday < DateTime.Parse("01.01.1900") || birthday >= DateTime.Now)
        //      {
        //          throw new ArgumentException("Невозможная дата рождения.", nameof(birthday));
        //      }
        //      if (string.IsNullOrWhiteSpace(email))
        //      {
        //          throw new ArgumentNullException("Имя пользователя не может быть пустым или null", nameof(email));
        //      }

        //      Name = name;
        //      #endregion
        //      Name = name;
        //      Email = email;
        //      Birthday = birthday;

        //  }
        #endregion
        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null", nameof(name));
            }
            Name = name;
        }

        public override string ToString()
        {
            return Name + " " + Age + " " + Email;
        }

    }
}
