﻿namespace UserService.Application.DTOs
{
    public class UserLogin
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
