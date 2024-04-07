namespace Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Nickname { get; set; }
    public string PasswordHash { get; set; }
    public string Nationality { get; set; }
    public string? VerificationToken { get; set; }
    public DateTime? VerificationDate { get; set; }
    public string? PasswordResetToken { get; set; }
    public DateTime? PasswordResetTokenExpires { get; set; }
}