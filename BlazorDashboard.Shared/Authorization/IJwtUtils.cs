using BlazorDashboard.Shared.Entities;

namespace BlazorDashboard.Shared.Authorization;

public interface IJwtUtils
{
    public string GenerateJwtToken(Account account);
    public int? ValidateJwtToken(string token);
    public RefreshToken GenerateRefreshToken(string ipAddress);
}
