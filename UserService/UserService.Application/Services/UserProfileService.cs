using UserService.Domain.Interfaces;

public class UserProfileService
{
    private readonly IUserRepository _userRepository;

    public UserProfileService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserProfileDto?> GetProfileAsync(Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null) return null;

        return new UserProfileDto
        {
            FullName = user.FullName,
            Address = user.Address,
            PhoneNumber = user.PhoneNumber,
            DateOfBirth = user.DateOfBirth
        };
    }

    public async Task<bool> UpdateProfileAsync(Guid userId, UserProfileDto profile)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null) return false;

        user.FullName = profile.FullName;
        user.Address = profile.Address;
        user.PhoneNumber = profile.PhoneNumber;
        user.DateOfBirth = profile.DateOfBirth;

        await _userRepository.UpdateAsync(user);
        return true;
    }
}
