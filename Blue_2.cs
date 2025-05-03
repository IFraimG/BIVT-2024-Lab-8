namespace Lab_8;

public class Blue_2: Blue
{
    private string _output;
    private string _search;

    private char[] listSymbols = new char[] { '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };
    public string Output => _output;

    public Blue_2(string input, string search): base(input)
    {
        this._output = null;
        this._search = search;
    }

    public override void Review()
    {
        if (String.IsNullOrEmpty(this.Input) || String.IsNullOrEmpty(this._search)) return;

        string result = "";
        string[] foo = this.Input.Split(" ");

        bool isFirstContinued = false;
        char symbol = ' ';
        for (int i = 0; i < foo.Length; i++)
        {
            if (!foo[i].Contains(this._search))
            {
                if (symbol != ' ') result += symbol;
                if (i > 0 && !isFirstContinued)
                {
                    result += " ";
                }
                isFirstContinued = false;
                result += foo[i];
                symbol = ' ';
            }
            else
            {
                if (listSymbols.Contains(foo[i][foo[i].Length - 1])) symbol = foo[i][foo[i].Length - 1];
                if (i == 0) isFirstContinued = true;
            }
        }

        this._output = result;
    }
    
    public override string ToString()
    {
        if (String.IsNullOrEmpty(this._output)) return null;
        return Output;
    }
}
