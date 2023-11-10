using MVCEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCLogic
{
    public class LogicUser
    {


        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User CheckLogin(string userName, string password)
        {
            //实例化数据库上下文类
            DemoEntity demoEntity = new DemoEntity();
            //根据账号，密码进行查询
            var data = demoEntity.User.Where(p => p.UserName == userName && p.Pwd == password).FirstOrDefault();
            return data;
        }





        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        public List<User> GetUsersList(string keyWord)
        {
            //实例化数据库上下文类
            DemoEntity demoEntity = new DemoEntity();

            var data = demoEntity.User.ToList();
            if (!string.IsNullOrEmpty(keyWord))
            {
                data = data.Where(p => p.RealName.Contains(keyWord)).ToList();
            }
            return data;
        }




        /// <summary>
        /// 删除用户数据
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool DelUser(int ID)
        {
            //实例化数据库上下文类
            DemoEntity demoEntity = new DemoEntity();
            //先找出一条数据
            var data = demoEntity.User.Where(p => p.ID == ID).FirstOrDefault();
            if (data != null)
            {
                //再将这条数据删除
                demoEntity.User.Remove(data);
                demoEntity.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取单条用户数据
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public User GetSingleUser(int ID)
        {
            //实例化数据库上下文类
            DemoEntity demoEntity = new DemoEntity();
            //先找出一条数据
            var data = demoEntity.User.Where(p => p.ID == ID).FirstOrDefault();
            return data;
        }


        /// <summary>
        /// 修改单个用户数据
        /// </summary>
        /// <param name="flowers"></param>
        public void UpdateSingleUser(User user)
        {
            //实例化数据库上下文类
            DemoEntity demoEntity = new DemoEntity();
            //先找出一条数据
            var data = demoEntity.User.Where(p => p.ID == user.ID).FirstOrDefault();
            //再修改这条数据
            data.RealName = user.RealName;
            data.Pwd = user.Pwd;
            data.Power = user.Power;
            data.UpdateTime = DateTime.Now;
            demoEntity.SaveChanges();
        }

        /// <summary>
        /// 添加一条用户数据
        /// </summary>
        /// <param name="flowers"></param>
        public void InsertSingleUser(User user)
        {
            //实例化数据库上下文类
            DemoEntity demoEntity = new DemoEntity();
            demoEntity.User.Add(user);
            demoEntity.SaveChanges();
        }

    }
}
