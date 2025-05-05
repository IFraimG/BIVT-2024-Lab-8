using System.Text;

namespace Lab_8;

public class Blue_3: Blue
{
    private (char, double)[] _output;

    private char[] listSymbols = new char[] { '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };
    
    public (char, double)[] Output
    {
        get
        {
            if (_output == null) return null;

            (char, double)[] result = new (char, double)[_output.Length];

            for (int i = 0; i < _output.Length; i++)
            {
                result[i] = (_output[i].Item1, _output[i].Item2);
            }

            return result;
        }
    }
    
    public Blue_3(string input): base(input)
    {
        this._output = null;
    }

    public override void Review()
    {
        if (string.IsNullOrEmpty(this.Input)) {
           this._output = null;
            return;
        }

        string[] foo = this.Input.Split(" ");

        char[] arrSymbols = new char[char.MaxValue];
        int countSymbols = 0;
        int countChars = 0;
        for (int i = 0; i < foo.Length; i++)
        {
            bool isTrue = false;
            for (int j = 0; j < foo[i].Length; j++)
            {
                if (char.IsDigit(foo[i][j]) && !isTrue)
                {
                    isTrue = true;
                    countChars++;
                }
                if (!char.IsLetter(foo[i][j])) continue;

                if (!arrSymbols.Contains(char.ToLower(foo[i][j])) && !isTrue)
                {
                    arrSymbols[countSymbols] = char.ToLower(foo[i][j]);
                    countSymbols++;
                }
                isTrue = true;
            }

            if (!isTrue) countChars++;
        }
        
        (char, double)[] result = new (char, double)[countSymbols];
        for (int i = 0; i < countSymbols; i++)
        {
            result[i] = (arrSymbols[i], 0.0);
        }
        for (int i = 0; i < foo.Length; i++) {
                bool isTrue = false;
                for (int j = 0; j < result.Length; j++)
                {
                    int index = 0;
                    while (index < foo[i].Length && !char.IsLetter(foo[i][index]))
                    {
                        if (char.IsDigit(foo[i][index])) isTrue = true;
                        index++;
                    }

                    if (index == foo[i].Length) index = 0;
                    if (result[j].Item1.Equals(char.ToLower(foo[i][index])) && !isTrue)
                    {
                        result[j].Item2++;
                        isTrue = true;
                    }
                }
        }

        for (int i = 0; i < result.Length; i++)
        {
            result[i].Item2 = Math.Round(result[i].Item2 * 100.0 / (foo.Length - countChars), 4);
        }
        
        Array.Sort(result, (first, second) =>
        {
            if (first.Item2 == second.Item2) return first.Item1.CompareTo(second.Item1);
            return second.Item2.CompareTo(first.Item2);
        });
        
        this._output = result;
    }

    public override string ToString()
    {
        if (this._output == null || this._output.Length == 0) return "";

        var result = new StringBuilder();
        for (int i = 0; i < this._output.Length; i++)
        {
            if (i > 0) result.AppendLine();
            result.Append($"{this._output[i].Item1} - {this._output[i].Item2:F4}");
        }

        return result.ToString();
    }
}