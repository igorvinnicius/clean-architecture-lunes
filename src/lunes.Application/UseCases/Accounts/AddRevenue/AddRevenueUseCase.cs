﻿using System;
using System.Threading.Tasks;
using lunes.Application.Exceptions;
using lunes.Application.Repositories.Accounts;

namespace lunes.Application.UseCases.Accounts.AddRevenue
{
    public class AddRevenueUseCase : IAddRevenueUseCase
    {
	    private readonly IAccountReadOnlyRepository _accountReadOnlyRepository;
	    private readonly IAccountWriteOnlyRepository _accountWriteOnlyRepository;

	    public AddRevenueUseCase(IAccountReadOnlyRepository accountReadOnlyRepository, IAccountWriteOnlyRepository accountWriteOnlyRepository)
	    {
		    this._accountReadOnlyRepository = accountReadOnlyRepository;
		    this._accountWriteOnlyRepository = accountWriteOnlyRepository;
	    }

		public async Task<AddRevenueOutput> Run(Guid accountId, string name, decimal expectedBalance)
	    {
		    var account = await this._accountReadOnlyRepository.GetAccount(accountId);

		    if (account == null)
			    throw new AccountNotFoundException("Account not found.");

			account.AddRevenue(name, expectedBalance);

		    await _accountWriteOnlyRepository.Update(account);

			return new AddRevenueOutput(account.Id, account.GetCurrentBalance());
	    }
    }
}
