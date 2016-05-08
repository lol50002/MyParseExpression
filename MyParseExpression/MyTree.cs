using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class MyTree
    {
        string value;
        MyTree left;
        MyTree right;

        public static int findNextOper(string str)
        {
            int delit= -1;
            int minus=-1;
            int umnoj=-1;
            Stack<char> lol= new Stack<char>();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(')
                {
                    lol.Push('(');
                    continue;
                }
                else if (str[i] == ')')
                {   
                    lol.Pop();
                  continue;
                }
                else if((lol.Count ==0)&&(str[i]=='+'))
                        return i;
                else if(((lol.Count ==0)&&(str[i]=='*')&&(minus==-1)))
                        umnoj = i;
                else if(((lol.Count ==0)&&(str[i]=='-')&&(minus==-1)))
                        minus = i;
                



                else    if(((lol.Count ==0)&&(str[i]=='/')&&(minus==-1)))
                        delit = i;
            }
            if (minus != -1)
                return minus;
            else if (umnoj != -1)
                return umnoj;
            else if (delit != -1)
                return delit;
            else return -1;

        }

        public static int IndexOfFirstBreaket(string str)
        {
            int result=-1;
            Stack<char> lolipop = new Stack<char>();
            for (int i = 0; i <= str.Length; i++)
            {
                if (str[i] == '(')
                {
                    lolipop.Push('(');
                    continue;
                }
                else if (str[i] == ')')
                {
                    lolipop.Pop();
                    if (lolipop.Count == 0)
                        return i;
                    continue;
                }
            }
            return result;

        }
        public MyTree(string str)
        {
            this.value = str;
        }

        public static MyTree parsexpression(string str)
        {
            MyTree res;
            if (str[0] == '-')
                str = "0" + str;
            if (str.IndexOfAny(new char[]{'+','-','/','*'}) == -1)
            {
                res = new MyTree(str);
            }
            else if (str[0] == '(')
            {
                if (IndexOfFirstBreaket(str) == str.Length - 1)
                    res = parsexpression(str.Substring(1, str.Length - 2));
                else
                    res = spreadExpression(str, findNextOper(str));
            }
            else
                res = spreadExpression(str, findNextOper(str));
            return res;
         
        }
        
        
        public static MyTree spreadExpression(string exp,int index)
        {
            MyTree res;
            string leftExpression = exp.Substring(0,index);
            string rightExpression = exp.Substring(index+1);
            res = new MyTree(exp[index].ToString());
            res.left = parsexpression(leftExpression);
            res.right = parsexpression(rightExpression);
            return res;
        }

        public double Calculate()
        {
            if (left != null)
            {
                switch (value)
                {
                    case "+": return left.Calculate() + right.Calculate();
                    case "-": return left.Calculate() - right.Calculate();
                    case "/": return left.Calculate() / right.Calculate();
                    case "*": return left.Calculate() * right.Calculate();
                }
            }

            return Convert.ToDouble(value);


        }

         public static Dictionary<string,double> peremenny(string str)
        {
             Dictionary<string,double> res=new Dictionary<string,double>(); 
            int strartindex=-1;
             string temp;
            for (int i = 0; i < str.Length; i++)
            {

                if (Char.IsLetter(str[i]))
                {
                    if (strartindex==-1)
                        strartindex =i;
                    else
                        continue;
                }
                else
                {
                    if(strartindex == -1)
                        continue;
                    else
                    {
                         temp = str.Substring(strartindex,i-strartindex);
                    strartindex=-1;
                    if (!res.Keys.Contains(temp))
                        res.Add(temp,0);
                    else
                        continue;
                    }
                }
                    
              }
             if (strartindex!=-1)
                 temp =str.Substring(strartindex);
           }
            
            
        }
    


        }




    }

