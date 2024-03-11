using Common.Application;
using Common.Domain.Exceptions;
using Domain.Users;
using Domain.Users.Repository;

namespace Application.Users.Delete;
public class DeleteUserCommandHandler : IBaseCommandHandler<DeleteUserCommand>
{
    private readonly IUserRepository _repository;
    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _repository = userRepository;
    }

    public async Task<OperationResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _repository.GetTracking(request.UserId);
            var CommentUser = _repository.GetCommentByUserId(request.UserId);
            var RequestPay = _repository.GetRequestPayByUserId(request.UserId);
            var Address = _repository.GetAddressByUserId(request.UserId);
            var Cart = _repository.GetCartsByUserId(request.UserId);

            if (CommentUser != null)
            {
                foreach (var item in CommentUser)
                {
                    _repository.DeleteComment(item);
                }
            }

            if (RequestPay != null)
            {
                foreach (var item in RequestPay)
                {
                    _repository.DeleteRequestPay(item);
                }
            }

            if (Address != null)
            {
                _repository.DeleteAddress(Address);
            }

            if (Cart != null)
            {
                foreach (var item in Cart)
                {
                    var CartItem = _repository.GetByCartId(item.Id);
                    foreach (var cartItem in CartItem)
                    {
                        _repository.DeleteCartItem(cartItem);
                    }
                    _repository.DeleteCart(item);
                }
            }

            if (user == null)
                return OperationResult.NotFound();

            _repository.DeleteUser(user);
            await _repository.Save();
            return OperationResult.Success();
        }
        catch (NullOrEmptyException ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }
}