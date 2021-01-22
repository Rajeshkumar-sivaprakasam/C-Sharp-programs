using System;
using System.Collections.Generic;
using System.Text;
public class Calculator
{
    public static int Evaluate(string expression)
    {
        char[] charValue = expression.ToCharArray();

        Stack<int> values = new Stack<int>();

        Stack<char> oprate = new Stack<char>();

        for (int i = 0; i < charValue.Length; i++)
        {
            if (charValue[i] == ' ')
            {
                continue;
            }
            if (charValue[i] >= '0' && charValue[i] <= '9')
            {
                StringBuilder temp = new StringBuilder();
                while (i < charValue.Length &&
                 charValue[i] >= '0' &&
                 charValue[i] <= '9')
                {
                    temp.Append(charValue[i++]);
                }
                values.Push(int.Parse(temp.ToString()));

                i--;

            }
            else if (charValue[i] == '+' ||
            charValue[i] == '-' ||
            charValue[i] == '*' ||
            charValue[i] == '/')
            {
                //oprate.Push(charValue[i]);
                while (oprate.Count > 0 &&
                        HasPrecedence(charValue[i],
                            oprate.Peek()))
                {
                    values.Push(ApplyCalculation(oprate.Pop(),
                                                values.Pop(),
                                                values.Pop()));
                }
                oprate.Push(charValue[i]);
            }
            else if (charValue[i] == '(')
            {
                oprate.Push(charValue[i]);
            }
            else if (charValue[i] == ')')
            {
                while (oprate.Peek() != '(')
                {
                    values.Push(ApplyCalculation(oprate.Pop(),
                                             values.Pop(),
                                             values.Pop()));
                }
                oprate.Pop();
            }
        }
        while (oprate.Count > 0)
        {
            values.Push(ApplyCalculation(oprate.Pop(),
            values.Pop(), values.Pop()));
        }

        return values.Pop();
    }
    public static int ApplyCalculation(char opr, int b, int a)
    {
        switch (opr)
        {
            case '+':
                return a + b;
            case '-':
                return a - b;
            case '*':
                return a * b;
            case '/':
                if (b == 0)
                {
                    throw new System.NotSupportedException(
                        "Cannot divide by Zero");
                }
                return a / b;
        }
        return 0;
    }

    public static bool HasPrecedence(char op1, char op2)
    {
        if (op2 == '(' || op1 == ')')
        {
            return false;
        }
        if ((op1 == '*') || (op1 == '/') &&
             (op2 == '+') || (op2 == '-'))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public static void Main(string[] args)
    {
        Console.WriteLine(Calculator.Evaluate("2+3"));
    }



}