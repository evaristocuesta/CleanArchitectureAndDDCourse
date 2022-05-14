namespace CleanArchitecture.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, int key) : base($"Entity {name} ({key}) not found")
        {
        }
    }
}
