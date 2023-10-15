﻿using System;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
	public interface ICustomerService
	{
		IDataResult<List<Customer>> GetAll();
		IDataResult<Customer> GetByCustomerId(int customerId);
        IDataResult<List<CustomerDetailDto>> GetCustomerDetails();

        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);
    }
}

