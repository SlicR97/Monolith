namespace Monolith.DAL.Contracts
{
   public interface IUnitOfWorkFactory
   {
      IUnitOfWork Generate();
   }
}
