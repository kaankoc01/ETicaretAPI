using MediatR;

namespace ETicaretAPI.Application.Features.Commands.ProductImageFile.ChangeShowCaseProductImage
{
    public class ChangeShowcaseImageCommandHandler : IRequestHandler<ChangeShowcaseImageCommandRequest, ChangeShowcaseImageCommandResponse>
    {
        public Task<ChangeShowcaseImageCommandResponse> Handle(ChangeShowcaseImageCommandRequest request, CancellationToken cancellationToken)
        {
            
        }
    }
}
