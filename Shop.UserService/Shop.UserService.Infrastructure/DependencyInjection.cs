using Microsoft.IdentityModel.Tokens;
using Shop.Common.Application_Layer.Services;
using Shop.Common.Infrastructure_Layer.Services;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Shop.UserService.Infrastructure;

public static class DependencyInjection
{
    const string DIR = "/Shop.Datas/Keys";
    const string RSA_PATH = $"{DIR}/rsa.txt";
    const string PUBLIC_KEY_PATH = $"{DIR}/public_key.txt";
    const string PRIVATE_KEY_PATH = $"{DIR}/private_key.txt";
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Add Repositories
        services.AddSingleton<IRolesRepository, RolesRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        // Add Services
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        SigningCredentials signingCredentials = Task.Run(() =>
        {
            //RSA? rsa;
            //string? privateKey;
            //string? publicKey;
            //EnsureFilesExist();

            //var file = await File.ReadAllTextAsync(RSA_PATH);
            //var privateFile = await File.ReadAllTextAsync(PUBLIC_KEY_PATH);
            //var publicFile = await File.ReadAllTextAsync(PRIVATE_KEY_PATH);
            //if (!string.IsNullOrEmpty(file))
            //{
            //    rsa = JsonSerializer.Deserialize<RSA>(file);
            //    privateKey = privateFile;
            //    publicKey = publicFile;
            //}
            //else
            //{
            //    var sb = new StringBuilder();
            //    string separator = null!;
            //    rsa = RSA.Create();
            //    privateKey = sb.AppendJoin(separator, rsa.ExportRSAPrivateKey()).ToString();
            //    sb.Clear();
            //    publicKey = sb.AppendJoin(separator, rsa.ExportRSAPublicKey()).ToString();
            //    var content = JsonSerializer.Serialize(rsa);
            //    await File.WriteAllTextAsync(RSA_PATH, content);
            //    await File.WriteAllTextAsync(PRIVATE_KEY_PATH, privateKey);
            //    await File.WriteAllTextAsync(PUBLIC_KEY_PATH, publicKey);
            //}

            var rsa = RSA.Create();
            var signingCredentials = new SigningCredentials(
                new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha512);

            return signingCredentials;
        }).Result;
        
        services.AddSingleton(signingCredentials);
        return services;
    }

    private static void EnsureFilesExist()
    {
        if (!Directory.Exists(DIR))
        {
            Directory.CreateDirectory(DIR);
        }
        if (!File.Exists(RSA_PATH))
        {
            var stream = File.Create(RSA_PATH);
            stream.Close();
        }
        if (!File.Exists(PRIVATE_KEY_PATH))
        {
            var stream = File.Create(PRIVATE_KEY_PATH);
            stream.Close();
        }
        if (!File.Exists(PUBLIC_KEY_PATH))
        {
            var stream = File.Create(PUBLIC_KEY_PATH);
            stream.Close();
        }
    }
}
