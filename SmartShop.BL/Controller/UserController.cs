using SmartShop.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SmartShop.BL.Controller 
{
  public class UserController : ControllerBase
{
       public List<User> Users { get; set; }
       public User CurrentUser { get; set; }
        public bool IsNewUser { get; } = false;

        public UserController(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null", nameof(name));

            }
            Users = GetUsersData();
            CurrentUser = Users.SingleOrDefault(u => u.Name == name);

            if (CurrentUser == null)
            {
                CurrentUser = new User(name);
                Users.Add(CurrentUser);
                IsNewUser = true;
            }
        }
        public void SetNewUserData(DateTime birthday, string email)
        {
            CurrentUser.Birthday = birthday;
            CurrentUser.Email = email;
            
           Save();
        }

        // получить сохраненный список пользователя.
        private List<User> GetUsersData()
        {
            return Load<User>() ?? new List<User>();
        }


        // Сохранить данные пользователя 
        public void Save()
        {
            Save(Users);
        }





    }
}
