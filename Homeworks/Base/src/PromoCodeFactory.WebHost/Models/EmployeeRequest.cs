using PromoCodeFactory.Core.Domain.Administration;

namespace PromoCodeFactory.WebHost.Models
{
    public record EmployeeRequest(
        string FirstName,
        string LastName,
        string Email,
        Role[] Roles,
        int AppliedPromocodesCount);
}
