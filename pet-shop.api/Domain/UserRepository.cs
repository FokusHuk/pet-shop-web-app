namespace pet_shop.api.Domain
{
    public class UserRepository: IUserRepository
    {
        public UserRepository()
        {
            _balance = 10000;
        }
        
        public double GetUserBalance()
        {
            return _balance;
        }

        public void ChangeUserBalance(double balance)
        {
            _balance = balance;
        }

        private double _balance;
    }
}