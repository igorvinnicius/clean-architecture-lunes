﻿using System;
using System.Threading.Tasks;
using lunes.Application.Exceptions;
using lunes.Application.Repositories.Accounts;

namespace lunes.Application.UseCases.Accounts.UpdateAccount
{
    public class UpdateAccountUseCase : IUpdateAccountUseCase
    {
	    private readonly IAccountReadOnlyRepository _accountReadOnlyRepository;
	    private readonly IAccountWriteOnlyRepository _accountWriteOnlyRepository;

		public UpdateAccountUseCase(IAccountReadOnlyRepository accountReadOnlyRepository, IAccountWriteOnlyRepository accountWriteOnlyRepository)
	    {
		    this._accountReadOnlyRepository = accountReadOnlyRepository;
		    this._accountWriteOnlyRepository = accountWriteOnlyRepository;
	    }

	    public async Task<UpdateAccountOutput> Run(Guid accountId, string accountName)
	    {
		    var account = await _accountReadOnlyRepository.GetAccount(accountId);

		    if (account == null)
			    throw new AccountNotFoundException("Account not found.");

			account.UpdateName(accountName);

		    await _accountWriteOnlyRepository.Update(account);

			return new UpdateAccountOutput(account.Id, account.Name);
	    }
    }
}
