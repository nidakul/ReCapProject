﻿using System;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
	public interface IRentalService
	{
		IDataResult<List<Rental>> GetAll();
		IDataResult<Rental> GetByRentalId(int rentalId);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();

        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
    }
}

