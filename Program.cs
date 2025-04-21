using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json; // 引入 Newtonsoft.Json 库
namespace netframe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. 创建对象并序列化为 JSON（对象→字符串）
            User user = new User
            {
                Name = "Alice",
                Age = 30,
                IsActive = true
            };
            string json = JsonConvert.SerializeObject(user); // 序列化
            Console.WriteLine("序列化后的 JSON：");
            Console.WriteLine(json); // 输出：{"Name":"Alice","Age":30,"IsActive":true}

            // 2. 将 JSON 反序列化为对象（字符串→对象）
            User deserializedUser = JsonConvert.DeserializeObject<User>(json); // 反序列化
            Console.WriteLine("\n反序列化后的对象：");
            Console.WriteLine($"Name: {deserializedUser.Name}, Age: {deserializedUser.Age}, IsActive: {deserializedUser.IsActive}");

            // 3. 处理复杂 JSON（例如数组/字典）
            string jsonArray = "[{\"Name\":\"Bob\",\"Age\":25},{\"Name\":\"Charlie\",\"Age\":35}]";
            var users = JsonConvert.DeserializeObject<User[]>(jsonArray); // 反序列化为数组
            foreach (var u in users)
            {
                Console.WriteLine($"用户：{u.Name}, 年龄：{u.Age}");
            }
        }
        public class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public bool IsActive { get; set; }
        }
    }
}
