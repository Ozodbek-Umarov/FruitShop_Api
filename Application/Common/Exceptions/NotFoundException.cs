namespace Application.Common.Exeptions;

public class NotFoundException(string message)
    : Exception(message)
{
}
