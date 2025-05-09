﻿namespace TaskManagementAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Role Role { get; set; }
    }


    public enum Role
    {
        Admin,
        User
    }
}
