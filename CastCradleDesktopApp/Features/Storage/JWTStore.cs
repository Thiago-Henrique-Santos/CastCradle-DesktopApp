using System;
using System.Text;
using System.Text.Json;

namespace CastCradleDesktopApp.Features.Storage
{
    public static class JWTStore
    {
        private static string _token = string.Empty;
        private static JwtData? _jwtData;

        public static void SetToken(string encodedJwt)
        {
            if (string.IsNullOrWhiteSpace(encodedJwt))
            {
                throw new ArgumentException("O token JWT não pode ser nulo ou vazio.", nameof(encodedJwt));
            }

            var parts = encodedJwt.Split('.');
            if (parts.Length != 3)
            {
                throw new ArgumentException("O token JWT está mal formatado.");
            }

            _jwtData = JWTDecoder.Decoder.DecodePayload<JwtData>(encodedJwt);
            _token = encodedJwt;
        }

        public static string GetToken()
        {
            return _token;
        }

        public static bool IsTokenValid()
        {
            return _jwtData != null && DateTime.UtcNow < DateTimeOffset.FromUnixTimeSeconds(_jwtData.Exp).UtcDateTime;
        }

        private class JwtData
        {
            public required string Jti { get; set; }
            public required string Sub { get; set; }
            public required string Email { get; set; }
            public required string UserId { get; set; }
            public required string Nome { get; set; }
            public required string Role { get; set; }
            public long Nbf { get; set; }
            public long Exp { get; set; }
            public long Iat { get; set; }
            public required string Iss { get; set; }
            public string[] Aud { get; set; } = Array.Empty<string>();
        }
    }
}
