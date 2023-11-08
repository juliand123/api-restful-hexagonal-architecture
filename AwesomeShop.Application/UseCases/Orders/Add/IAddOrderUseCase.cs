namespace AwesomeShop.Application.UseCases.Orders.Add;

public interface IAddOrderUseCase
{
    Task<int> Execute(AddOrderInput input);
}