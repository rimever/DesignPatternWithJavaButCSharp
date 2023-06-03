// See https://aka.ms/new-console-template for more information

var affairs = new GeneralAffairs("石原");
var manager = new Manager("野口", 10);
var generalManager = new GeneralManager("山田", 20);
var president = new President("佐藤", 30);

affairs.SetNext(manager).SetNext(generalManager).SetNext(president);

var holiday = new DecisionRequest() {
    DocumentName = "有給申請書",
    DocumentType = 1
};

var retire = new DecisionRequest()
{
    DocumentName = "退職届",
    DocumentType = 11
};

var hiring = new DecisionRequest()
{
    DocumentName = "新卒採用申請書", 
    DocumentType = 21
};

var strike = new DecisionRequest()
{
    DocumentName = "ストライキ通知書",
    DocumentType = 99
};

affairs.Decision(holiday);
affairs.Decision(retire);
affairs.Decision(hiring);
affairs.Decision(strike);

public class DecisionRequest
{
    public required string DocumentName { get; init; }
    public required int DocumentType { get; init; }

    public override string ToString()
    {
        return $"[documentName={DocumentName},documentType={DocumentType}]";
    }
}

public abstract class ApprovalPerson
{
    protected ApprovalPerson(string name)
    {
        Name = name;
    }
    public string Name { get; }
    public ApprovalPerson? Next { get; private set; }

    public ApprovalPerson SetNext(ApprovalPerson next)
    {
        Next = next;
        return next;
    }

    public void Decision(DecisionRequest request)
    {
        if (Judge(request))
        {
            Done(request);
        }else if (Next != null)
        {
            Next.Decision(request);
        }
        else
        {
            Fail(request);
        }
    }

    private void Fail(DecisionRequest request)
    {
        Console.WriteLine($"{request} is not decisioned by {Name}");
    }

    private void Done(DecisionRequest request)
    {
        Console.WriteLine($"{request} is decisioned by {Name}");
    }

    protected abstract bool Judge(DecisionRequest request);
    
}

/// <summary>
/// 庶務を表すクラス
/// </summary>
public class GeneralAffairs : ApprovalPerson
{
    public GeneralAffairs(string name) : base(name)
    {
        
    }
    /// <inheritdoc />
    /// <remarks>決裁できないため、稟議を回すだけ</remarks>
    protected override bool Judge(DecisionRequest request)
    {
        return false;
    }
}

/// <summary>
/// 課長を表すクラス
/// </summary>
public class Manager : ApprovalPerson
{
    public Manager(string name) : base(name)
    {
    }

    /// <summary>
    /// 決裁できる稟議書のタイプの上限
    /// </summary>
    private readonly int _documentTypeLimit;

    public Manager(string name, int documentTypeLimit):base(name)
    {
        _documentTypeLimit = documentTypeLimit;
    }

    protected override bool Judge(DecisionRequest request)
    {
        return request.DocumentType <= _documentTypeLimit;
    }
}

/// <summary>
/// 部長を表すクラス
/// </summary>
public class GeneralManager : ApprovalPerson
{
    /// <summary>
    /// 決裁できる稟議書のタイプの上限
    /// </summary>
    private readonly int _documentTypeLimit;

    public GeneralManager(string name, int documentTypeLimit):base(name)
    {
        _documentTypeLimit = documentTypeLimit;
    }

    protected override bool Judge(DecisionRequest request)
    {
        return request.DocumentType <= _documentTypeLimit;
    }
}
/// <summary>
/// 社長を表すクラス
/// </summary>
public class President : ApprovalPerson
{
    /// <summary>
    /// 決裁できる稟議書のタイプの上限
    /// </summary>
    private readonly int _documentTypeLimit;
    
    public President(string name, int documentTypeLimit):base(name)
    {
        _documentTypeLimit = documentTypeLimit;
    }

    protected override bool Judge(DecisionRequest request)
    {
        return request.DocumentType <= _documentTypeLimit;
    }    
}