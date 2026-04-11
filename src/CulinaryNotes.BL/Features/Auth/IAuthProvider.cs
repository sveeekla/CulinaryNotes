using CulinaryNotes.BL.Features.Auth.Entities;
using CulinaryNotes.BL.Features.Users.Entities;

namespace CulinaryNotes.BL.Features.Auth;

public interface IAuthProvider
{
    Task<TokensResponse> AuthorizeUserAsync(AuthorizeUserModel model);
    Task<UserModel> RegisterUserAsync(RegisterUserModel model);
    Task<TokensResponse> RefreshTokenAsync(string refreshToken);
}