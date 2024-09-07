using MediatR;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;

namespace NTierArchitecture.Business.Features.Categories.CreateCategory
{
    internal sealed class CraeteCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CraeteCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var isCategoryNameExists = await _categoryRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);

            if (isCategoryNameExists)
            {
                throw new ArgumentException("Bu kategoir daha önce oluşturulmuştur!");
            }

            Category category = new()
            {
                Name = request.Name,
            };
            await _categoryRepository.AddAsync(category, cancellationToken);
            await _unitOfWork.SaveChanegesAsync(cancellationToken);
        }
    }
}
