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
        private int findNextOper(string str)
        {
            int delit= -1;
            int minus=-1;
            int umnoj=-1;
            Stack<char> lol= new Stack<char>();
            for (int i = 0; i <= str.Length; i++)
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

        private int IndexOfFirstBreaket(string str)
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
        private MyTree parsexpression(string str)
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
          }





        }




    }
}
