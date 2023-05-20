namespace Application.Common.Models;

public class EntitiesPermissions
{
}
public class Admin
{
    public const string defult = "Permission.admin ,";
    public const string admin = "Permission.admin";
}
public class Users
{
    public const string View = "Permission.User.View";
    public const string Create = "Permission.User.Create";
    public const string Edit = "Permission.User.Edit";
    public const string Delete = "Permission.User.Delete";
}
public class Roles
{
    public const string View = "Permission.Role.View";
    public const string Create = "Permission.Role.Create";
    public const string Edit = "Permission.Role.Edit";
    public const string Delete = "Permission.Role.Delete";
}
public class UserDefault
{
    public const string AllUserAccess = "Permission.AllUserAccess";
}
