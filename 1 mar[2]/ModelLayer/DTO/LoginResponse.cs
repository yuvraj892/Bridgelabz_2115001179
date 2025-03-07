using System;

namespace ModelLayer.DTO
{
    public class LoginResponse
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public bool Cached { get; set; } 
    }
}
