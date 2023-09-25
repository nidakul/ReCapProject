using System;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
	public interface IUserService 
	{
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetByUserId(int userId);
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByMail(string email);

        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
    }
}
