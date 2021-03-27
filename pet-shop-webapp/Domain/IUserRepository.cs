namespace pet_shop.api.Domain
{
    public interface IUserRepository
    {
        public double GetUserBalance();
        public void ChangeUserBalance(double balance);
    }
}