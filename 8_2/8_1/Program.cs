interface IBankomat
{
    void AddMoney(int sum, int quantity);
    void WithdrawMoney(int amount);
    void DisplayRemainingAmount();
}
abstract class ATM : IBankomat
{
    protected Dictionary<int, int> Money;
    protected int CurrentSum;
    public ATM()
    {
        Money = new Dictionary<int, int>();
    }

    protected void UpdateTotalAmount()
    {
        CurrentSum = 0;
        foreach (var pair in Money)
        {
            CurrentSum += pair.Key * pair.Value;
        }
    }

    public abstract void AddMoney(int denomination, int quantity);
    public abstract void WithdrawMoney(int amount);
    public abstract void DisplayRemainingAmount();
}

class Bankomat : ATM
{
    public string BankomatID;
    public int MinimumSum;
    public int MaximumSum;

    public Bankomat(string bankomatid, int minimumsum, int maximumsum)
    {
        this.BankomatID = bankomatid;
        Money = new Dictionary<int, int>
        {
            { 1000, 13 },
            { 500, 19 },
            { 200, 89 },
            { 100, 50 },
            { 50, 30 },
            { 10, 100 }
        };
        this.MinimumSum = minimumsum;
        this.MaximumSum = maximumsum;
        UpdateTotalAmount();
    }

    ~Bankomat()
    {
        Console.WriteLine("чета происходит...");
    }
    

    public override void AddMoney(int sum, int quantity)
    {
        if (Money.ContainsKey(sum))
        {
            Money[sum] += quantity;
            UpdateTotalAmount();
            Console.WriteLine($"Добавлено {sum*quantity} руб.");
        }
        else
        {
            Console.WriteLine("Недопустимый номинал! >:(");
        }
    }

    public override void WithdrawMoney(int amount)
    {
        if (amount < MinimumSum)
        {
            Console.WriteLine("Сумма для снятия меньше минимально допустимой!");
        }
        else if (amount > MaximumSum)
        {
            Console.WriteLine("Сумма для снятия превышает максимально допустимую!");
        }
        else if (amount > CurrentSum)
        {
            Console.WriteLine("В банкомате недостаточно средств :(");
        }
        else
        {
            List<int> sortedSum = new List<int>(Money.Keys);
            sortedSum.Sort((x, y) => y.CompareTo(x));

            Dictionary<int, int> withdrawal = new Dictionary<int, int>();
            int remainingAmount = amount;

            foreach (int sum in sortedSum)
            {
                int MoneyToWithdraw = remainingAmount / sum;
                if (MoneyToWithdraw > Money[sum])
                {
                    MoneyToWithdraw = Money[sum];
                }
                withdrawal.Add(sum, MoneyToWithdraw);
                remainingAmount -= MoneyToWithdraw * sum;
            }

            if (remainingAmount == 0)
            {
                foreach (var pair in withdrawal)
                {
                    Money[pair.Key] -= pair.Value;
                }
                UpdateTotalAmount();
                Console.WriteLine($"Выдана сумма: {amount} руб.");
            }
            else
            {
                Console.WriteLine("Невозможно выдать указанную сумму.");
            }
        }
    }
    public override void DisplayRemainingAmount()
    {
        Console.WriteLine($"Остаток в банкомате: {CurrentSum} руб.");
    }
}

class Program
{
    static void Main()
    {
        Bankomat bankomat = new Bankomat("SV12345", 100, 10000);

        Console.WriteLine("Добро пожаловать в банкомат! Выберите действие:");
        Console.WriteLine("1 - Загрузить купюры в банкомат");
        Console.WriteLine("2 - Снять деньги с банкомата");

        string choise = Console.ReadLine();

        switch (choise)
        {
            case "1":
                Console.WriteLine("Введите номинал купюр и их количество:");
                try
                {
                    int nominal = int.Parse(Console.ReadLine());
                    int amount = int.Parse(Console.ReadLine());
                    bankomat.AddMoney(nominal, amount);
                }
                catch (Exception)
                {
                    Console.WriteLine("Что-то пошло не так. Попробуйте еще раз.");
                }
                bankomat.DisplayRemainingAmount();
                break;
            case "2":
                Console.WriteLine("Введите снимаемую сумму (от 100 руб. до 10000 руб.):");
                try
                {
                    int withdraw = int.Parse(Console.ReadLine());
                    bankomat.WithdrawMoney(withdraw);
                }
                catch (Exception)
                {
                    Console.WriteLine("Что-то пошло не так. Попробуйте еще раз.");
                }

                bankomat.DisplayRemainingAmount();
                break;
            default:
                Console.WriteLine("Что-то пошло не так. Попробуйте еще раз.");
                break;
        }
    }
}