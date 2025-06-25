namespace QuesosKesada.Shared.Guards;
public static class Guard
{
    public static GuardBuilderString Against(string value, string paramName)
    {
        return new GuardBuilderString(value, paramName);
    }
}
