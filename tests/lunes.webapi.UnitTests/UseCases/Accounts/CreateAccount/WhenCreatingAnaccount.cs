using lunes.Application.UseCases.Accounts.CreateAccount;
using lunes.WepApi.UseCases.Accounts.CreateAccount;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace lunes.webapi.UnitTests.UseCases.Accounts.CreateAccount
{
    public class WhenCreatingAnaccount
    {
        private readonly Mock<ICreateAccountUseCase> _mockCreateAccountUseCase;

        private readonly AccountsController _sut;

        public WhenCreatingAnaccount()
        {
            _mockCreateAccountUseCase = new Mock<ICreateAccountUseCase>();
            _sut = new AccountsController(_mockCreateAccountUseCase.Object);
        }

        [Fact]
        public async Task ShouldReturnPresenterCorrectly()
        {
            AssumeUseCaseRun();

            var createAccountRequest = new CreateAccountRequest() { Name = "Account 1"};

            var result = await _sut.Post(createAccountRequest);

            Assert.NotNull(result);
            Assert.IsType<CreatedAtRouteResult>(result);

            var createdAtRouteResult = (CreatedAtRouteResult)result;
            
            Assert.IsType<CreateAccountOutput>(createdAtRouteResult.Value);

            var createdAccountOutput = (CreateAccountOutput)createdAtRouteResult.Value;

            Assert.Equal("Account 1", (createdAccountOutput.AccountName));

        }

        private void AssumeUseCaseRun()
        {
            var createAccountOutput = new CreateAccountOutput(Guid.NewGuid(), "Account 1", 0);
                       
            _mockCreateAccountUseCase.Setup(x => x.Run(It.IsAny<string>())).ReturnsAsync(createAccountOutput);
        }


    }
}
