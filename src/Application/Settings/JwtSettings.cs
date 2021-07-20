using System;

namespace Application.Settings
{
    public class JwtSettings
    {
        public string SecretKey {get; set;}
        public TimeSpan TokenLifeTime {get; set;}
    }
}