using MediatR;
using NTierArchitecture.Entities.Models;

namespace NTierArchitecture.Business.Features.Categories.GetCategories
{
    public class GetCategoriesQuery():IRequest<List<Category>>;
}
