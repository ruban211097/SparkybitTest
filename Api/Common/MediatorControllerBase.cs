using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Common
{
    public abstract class MediatorControllerBase : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator
        {
            get
            {
                if (_mediator != null)
                    return _mediator;
                return _mediator = (IMediator)HttpContext.RequestServices.GetService(typeof(IMediator));
            }
        }
    }
}
