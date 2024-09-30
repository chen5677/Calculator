using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    private static int[] num = new int[100];  //存放数字
    private static int n;
    private static char[] ch = new char[100]; //存放运算符
    private static int k;
    private static int ans;                  //最终答案
    private static string text;              //显示结果


    // Start is called before the first frame update
    void Start()
    {
        Init();
    }


    void OnGUI()
    {
        GUI.Box(new Rect(250, 50, 300, 300), "");
        GUI.Box(new Rect(265, 60, 270, 40), text);
        if (GUI.Button(new Rect(265, 110, 50, 50), "7"))
        {
            num[n] = num[n] * 10 + 7;
            text += '7';
        }
        if (GUI.Button(new Rect(340, 110, 50, 50), "8"))
        {
            num[n] = num[n] * 10 + 8;
            text += '8';
        }
        if (GUI.Button(new Rect(415, 110, 50, 50), "9"))
        {
            num[n] = num[n] * 10 + 9;
            text += '9';
        }
        if(GUI.Button(new Rect(490, 110, 50, 50), "x"))
        {
            n++;
            ch[k++] = '*';
            text += 'x';
        }

        if (GUI.Button(new Rect(265, 170, 50, 50), "4"))
        {
            num[n] = num[n] * 10 + 4;
            text += '4';

        }
        if (GUI.Button(new Rect(340, 170, 50, 50), "5"))
        {
            num[n] = num[n] * 10 + 5;
            text += '5';
        }
        if (GUI.Button(new Rect(415, 170, 50, 50), "6"))
        {
            num[n] = num[n] * 10 + 6;
            text += '6';
        }
        if (GUI.Button(new Rect(490, 170, 50, 50), "/"))
        {
            n++;
            ch[k++] = '/';
            text += '/';
        }

        if (GUI.Button(new Rect(265, 230, 50, 50), "1"))
        {
            num[n] = num[n] * 10 + 1;
            text += '1';
        }
        if (GUI.Button(new Rect(340, 230, 50, 50), "2"))
        {
            num[n] = num[n] * 10 + 2;
            text += '2';
        }
        if (GUI.Button(new Rect(415, 230, 50, 50), "3"))
        {
            num[n] = num[n] * 10 + 3;
            text += '3';
        }
        if (GUI.Button(new Rect(490, 230, 50, 50), "+"))
        {
            n++;
            ch[k++] = '+';
            text += '+';
        }

        if (GUI.Button(new Rect(265, 290, 50, 50), "AC"))
        {
            if(text.Length != 0)
            {
                text = text.Substring(0, text.Length - 1);
                if (num[n] == 0)
                {
                    n--;
                    ch[--k] = '0';
                }
                else
                {
                    num[n] /= 10;
                }
            }
        }
        if (GUI.Button(new Rect(340, 290, 50, 50), "0"))
        {
            num[n] = num[n] * 10;
            text += '0';
        }
        if (GUI.Button(new Rect(415, 290, 50, 50), "="))
        {
            text += '=';
            calculator();
            int tmp = ans;
            Init();
            num[n] = tmp; //保存运算结果
        }
        if (GUI.Button(new Rect(490, 290, 50, 50), "-"))
        {
            n++;
            ch[k++] = '-';
            text += '-';
        }
    }

    void Init()
    {
        for(int i = 0; i < 10; i++)
        {
            num[i] = 0;
            ch[i] = '0';
        }
        n = 0;
        k = 0;
        ans = 0;
    }

    void calculator()
    {
        int a = 1;
        ans = num[0];
        for(int i = 0;i < k; i++)
        {
            if (ch[i] == '+')
            {
                ans += num[a++];
            }
            if (ch[i] == '-')
            {
                ans -= num[a++];
            }
            if (ch[i] == '*')
            {
                ans *= num[a++];
            }
            if (ch[i] == '/')
            {
                ans /= num[a++];
            }
        }
        text = ans.ToString();
    }

}
