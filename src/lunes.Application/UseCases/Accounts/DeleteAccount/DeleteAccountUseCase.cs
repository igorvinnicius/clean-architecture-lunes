using System;
using System.Threading.Tasks;
using lunes.Application.Repositories.Accounts;

namespace lunes.Application.UseCases.Accounts.DeleteAccount
{
    public class DeleteAccountUseCase : IDeleteAccountUseCase
    {
	    private readonly IAccountReadOnlyRepository _accountReadOnlyRepository;
	    private readonly IAccountWriteOnlyRepository _accountWriteOnlyRepository;

	    public DeleteAccountUseCase(IAccountReadOnlyRepository accountReadOnlyRepository, IAccountWriteOnlyRepository accountWriteOnlyRepository)
	    {
		    this._accountReadOnlyRepository = accountReadOnlyRepository;
		    this._accountWriteOnlyRepository = accountWriteOnlyRepository;
	    }

		public async Task<DeleteAccountOutput> Run(Guid accountId)
		{
			await _accountWriteOnlyRepository.Delete(accountId);

			return await Task.FromResult(new DeleteAccountOutput(true));
		}
    }
}
