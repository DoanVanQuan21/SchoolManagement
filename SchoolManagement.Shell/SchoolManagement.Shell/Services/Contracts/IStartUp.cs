namespace SchoolManagement.Shell.Services.Contracts
{
    internal interface IStartUp
    {
        void StartUp();

        IStartUp UseProject();
    }
}