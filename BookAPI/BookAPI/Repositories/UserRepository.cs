using System;
using BookAPI.Models;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace BookAPI.Repositories
{
    public class UserRepository
    {
        public User Read(Guid id)
        {
            var allUsers = LoadData();
            return allUsers.Find(c => c.Id == id);
        }

        public List<User> ReadAll()
        {
            var allUser = LoadData();
            return allUser;
        }

        public void Create(User user)
        {
            var allUsers = LoadData();
            user.Id = Guid.NewGuid();
            allUsers.Add(user);
            SaveData(allUsers);
        }

        public void Update(User user)
        {
            var allUsers = LoadData();
            var savedCourse = allUsers.Find(c => c.Id == user.Id);
            savedCourse.userName = user.userName;
            savedCourse.userAddress = user.userAddress;
            savedCourse.userContactNumber = user.userContactNumber;
            SaveData(allUsers);
        }

        public void Delete(Guid id)
        {
            var allUsers = LoadData();
            var usersToRemove = allUsers.Find(c => c.Id == id);
            allUsers.Remove(usersToRemove);
            SaveData(allUsers);
        }

        private List<User> LoadData()
        {
            var dataString = File.ReadAllText("J:/Educational stuffs/5th semester/ServerProgramming/67-bookapi/BookAPI/BookAPI/Data/User.json");
            return JsonConvert.DeserializeObject<List<User>>(dataString);
        }

        private void SaveData(List<User> data)
        {
            var dataString = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText("J:/Educational stuffs/5th semester/ServerProgramming/67-bookapi/BookAPI/BookAPI/Data/User.json", dataString);
        }
    }
}
