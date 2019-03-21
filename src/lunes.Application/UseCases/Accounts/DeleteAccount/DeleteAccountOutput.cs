namespace lunes.Application.UseCases.Accounts.DeleteAccount
{
    public class DeleteAccountOutput
    {
	    public bool AccountDeleted { get; }

	    public DeleteAccountOutput(bool accountDeleted)
	    {
		    AccountDeleted = accountDeleted;
	    }
    }
}
