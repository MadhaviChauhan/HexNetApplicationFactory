using SPADemo.AppSecurity.Entities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace SPADemo.AppSecurity.Seed_Data
{
    public static class Users
    {
        public static List<CUser> Get()
        {
            var sha1data = HashPassword("secret");
            return new List<CUser>
        {
            new CUser
            {
                UserName = "mani",
                PasswordHash = sha1data
            }
            ,
            new CUser
            {
                UserName = "amit",
                PasswordHash = sha1data
            }
            ,new CUser
            {
                UserName = "foo",
                PasswordHash = sha1data
            }
        };
        }
        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }
    }
}