﻿using System.ComponentModel.DataAnnotations;

namespace DAW_Project.DAL.Models
{
    public class SessionToken
    {
        public SessionToken() { }
        public SessionToken(string jti, int userId, DateTime expirationDate)
        {
            this.Jti = jti;
            this.UserId = userId;
            this.ExpirationDate = expirationDate;
        }
        [Key]
        public string Jti { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
