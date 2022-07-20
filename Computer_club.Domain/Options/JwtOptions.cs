﻿using Microsoft.IdentityModel.Tokens;

namespace Computer_club.Domain.Options;

public class JwtOptions
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int LifeTime { get; set; }
    public SecurityKey Key { get; set; }
}