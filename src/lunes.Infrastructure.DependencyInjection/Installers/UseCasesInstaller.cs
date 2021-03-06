﻿using lunes.Application.UseCases.Accounts.AddExpense;
using lunes.Application.UseCases.Accounts.AddRevenue;
using lunes.Application.UseCases.Accounts.CreateAccount;
using lunes.Application.UseCases.Accounts.DeleteAccount;
using lunes.Application.UseCases.Accounts.GetAccount;
using lunes.Application.UseCases.Accounts.ListAccounts;
using lunes.Application.UseCases.Accounts.MakeTransfer;
using lunes.Application.UseCases.Accounts.UpdateAccount;
using Microsoft.Extensions.DependencyInjection;

namespace lunes.Infrastructure.DependencyInjection.Installers
{
    public static class UseCasesInstaller
    {
	    public static void Install(IServiceCollection servicesCollection)
	    {
		    servicesCollection.AddScoped<IListAccountsUseCase, ListAccountsUseCase>();

		    servicesCollection.AddScoped<ICreateAccountUseCase, CreateAccountUseCase>();

		    servicesCollection.AddScoped<IUpdateAccountUseCase, UpdateAccountUseCase>();

		    servicesCollection.AddScoped<IAddExpenseUseCase, AddExpenseUseCase>();

		    servicesCollection.AddScoped<IAddRevenueUseCase, AddRevenueUseCase>();

		    servicesCollection.AddScoped<IMakeTransferUseCase, MakeTransferUseCase>();

		    servicesCollection.AddScoped<IGetAccountUseCase, GetAccountUseCase>();

		    servicesCollection.AddScoped<IDeleteAccountUseCase, DeleteAccountUseCase>();
		}
    }
}
