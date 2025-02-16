using System;
using JWT;
using JWT.Algorithms;
using JWT.Builder;

public class JwtGenerator
{
    public static string GetToken(string username, string secret)
    {
        var expiration = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 60;

        var token = JwtBuilder.Create()
            .WithAlgorithm(new HMACSHA256Algorithm())
            .WithSecret(secret)
            .AddClaim("username", username)
            .AddClaim("exp", expiration)
            .Encode();

        return token;
    }
}