namespace userservice.Models;

public class OrganizationCreateRequest
{
    public string Name { get; set; }
    public string DisplayName { get; set; }
}

public class OrganizationUpdateRequest
{
    public string Name { get; set; }
    public string DisplayName { get; set; }
}