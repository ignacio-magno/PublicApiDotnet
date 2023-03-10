namespace Sii.Domain;

public class CredentialSii
{
    public string Rut { get; set; }
    public string Password { get; set; }
    
    public CredentialSii(string rut, string password)
    {
        Rut = rut;
        Password = password;
    }
}