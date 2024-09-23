﻿namespace STMComunication.Dtos.Login
{
    public record LoginResponseDto
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}
