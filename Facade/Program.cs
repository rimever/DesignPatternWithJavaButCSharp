// See https://aka.ms/new-console-template for more information

var yamadaAccount = "0001";
var yamadaResult = BankManager.TakeLoan(yamadaAccount, 1_000_000);

Console.WriteLine();
var tanakaAccount = "0002";
var tanakaResult = BankManager.TakeLoan(tanakaAccount, 1_000_000);

public class Account
{
    /// <summary>
    /// 支店番号
    /// </summary>
    public required int BranchNumber { get; init; }

    /// <summary>
    /// 口座番号
    /// </summary>
    public  required string AccountNumber { get; init; }

    /// <summary>
    /// 口座種別
    /// </summary>
    public string AccountType { get; init; }

    /// <summary>
    /// 口座名義人
    /// </summary>
    public string AccountHolder { get; init; }

    /// <summary>
    /// 預金額
    /// </summary>
    public int Deposit { get; set; }

    /// <summary>
    /// ローン金額
    /// </summary>
    /// <returns></returns>
    public int Loan { get; set; }

    /// <summary>
    /// 返済ステータス
    /// </summary>
    public RepaymentStatus RepaymentStatus { get; init; }
}

public enum RepaymentStatus
{
    Success = 0,
    Error = 1
}

public static class BankSystem
{
    private static Dictionary<string, Account> _accountMap = new()
    {
        {
            "0001", new Account()
            {
                BranchNumber = 1,
                AccountNumber = "0001",
                AccountType = "普通",
                AccountHolder = "山田太郎",
                Deposit = 100_000,
                Loan = 1_000_000,
                RepaymentStatus = RepaymentStatus.Error
            }
        },
        {
            "0002", new Account()
            {
                BranchNumber = 1,
                AccountNumber = "0002",
                AccountType = "普通",
                AccountHolder = "田中花子",
                Deposit = 200_000,
                Loan = 0,
                RepaymentStatus = RepaymentStatus.Success
            }            
        }
    };

    public static Account GetAccount(string accountNumber)
    {
        return _accountMap[accountNumber];
    }

    public static bool ExistsAccount(string accountNumber)
    {
        return _accountMap.ContainsKey(accountNumber);
    }

    public static bool IsTakeLoan(string accountNumber)
    {
        var account = GetAccount(accountNumber);
        return account.RepaymentStatus == RepaymentStatus.Success;
    }

    public static bool TakeLoan(string accountNumber, int loanAmount)
    {
        var account = GetAccount(accountNumber);
        account.Deposit += loanAmount;
        account.Loan += loanAmount;
        return true;
    }
}

/// <summary>
/// 銀行システムを使用するために外部公開されているインターフェース
/// </summary>
public class BankManager
{
    private const int Success = 0;
    private const int Error = 1;

    public static int TakeLoan(string accountNumber, int loanAmount)
    {
        var existsAccount = BankSystem.ExistsAccount(accountNumber);
        if (!existsAccount)
        {
            Console.WriteLine("口座情報が存在しません。");
            return Error;
        }

        var checkRepaymentStatus = BankSystem.IsTakeLoan(accountNumber);
        if (!checkRepaymentStatus)
        {
            Console.WriteLine("返済が滞っているため、新規ローンを組めません。");
            return Error;
        }

        var takeLoan = BankSystem.TakeLoan(accountNumber, loanAmount);
        if (!takeLoan)
        {
            Console.WriteLine("ローンを組むのに失敗しました。");
            return Error;
        }
        Console.WriteLine("ローンを組みました。");
        return Success;
    }
}