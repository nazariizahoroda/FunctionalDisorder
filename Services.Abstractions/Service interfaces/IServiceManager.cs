namespace Services.Abstractions.Service_interfaces
{
    public interface IServiceManager
    {
        IUserService UserService { get; }
    }
}