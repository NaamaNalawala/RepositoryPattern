using CatsyOnlineStore.BAL.Services;
using CatsyOnlineStore.DataAccess.Services;
using CatsyOnlineStore.Model.Models;

namespace CatsyOnlineStore.BAL.Repositories
{
    public class CustomerBAL : GenericBAL<Customer>, ICustomerBAL
    {
        ICustomerRepository _customerRepository;
        public CustomerBAL(IGenericRepository<Customer> genericRepository, ICustomerRepository customerRepository) : base(genericRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<Customer> Login(UserLoginEntity user)
        {
            user.Password = EncodePasswordToBase64(user.Password);
            return _customerRepository.Login(user);
        }
        public new Task<int> AddAsync(Customer customer)
        {
            customer.Password = EncodePasswordToBase64(customer.Password);
            return _customerRepository.AddUpdateAsync(customer);
        }
        public new Task<int> UpdateAsync(Customer customer)
        {
            customer.Password = EncodePasswordToBase64(customer.Password);
            return _customerRepository.AddUpdateAsync(customer);
        }
        public async new Task<IEnumerable<Customer>> GetAllAsync()
        {
            var result = await _customerRepository.GetAllAsync();
            foreach (var item in result)
            {
                item.Password = DecodeFrom64(item.Password);
            }
            return result;
        }
        private static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
        private string DecodeFrom64(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }
    }
}
