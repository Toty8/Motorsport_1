namespace Mototsport1.Services.Data.Interfaces
{
    public interface IUserService
    {
        public Task<string> GetFullNameByEmailAsync(string email);
    }
}
