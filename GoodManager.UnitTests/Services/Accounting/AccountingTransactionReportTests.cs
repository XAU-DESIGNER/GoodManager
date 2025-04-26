using GoodManager.Domain.Interfaces.Accounting;
using Moq;

namespace GoodManager.UnitTests.Services.Accounting;

public class AccountingTransactionReportTests
{
    #region Constructor

    private readonly Mock<IAccountingTransactionRepository> _accountingTransactionRepositoryMock;

    public AccountingTransactionReportTests()
    {
        _accountingTransactionRepositoryMock = new Mock<IAccountingTransactionRepository>();
    }

    #endregion

    [Fact]
    public void GetLastYearCostsAndIncomeAsync_ReturnsMonthlyReportAsViewModel()
    {
        
    }
}