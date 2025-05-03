namespace Lab_8;

public class Blue_4: Blue
{
    private int _output;
    
    public int Output => _output;
    
    public Blue_4(string input): base(input)
    {
        this._output = 0;
    }

    public override void Review()
    {
        if (String.IsNullOrEmpty(Input))
        {
            this._output = 0;
            return;
        }
        
        string[] foo = this.Input.Split(" ");

        int summa = 0;
        foreach (var item in foo)
        {
            if (item.Any(char.IsDigit))
            {
                int res = 0;
                foreach (char symbol in item)
                {
                    if (char.IsDigit(symbol)) {
                        res = res * 10 + (symbol - '0');
                    }
                    else {
                        summa += res;
                        res = 0;
                    }
                }

                summa += res;   
            }
        }

        this._output = summa;
    }

    public override string ToString()
    {
        return this._output.ToString();
    }
}