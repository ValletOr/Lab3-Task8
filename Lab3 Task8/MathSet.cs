﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Task8
{
    public class MathSet
    {
        //Поля
        private int[] set;

        //Конструкторы
        public MathSet(string input)
        {
            this.set = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
        }
        public MathSet(int[] input)
        {
            this.set = input;
        }

        //Методы

        /// <summary>
        /// Возвращает содержимое объекта.
        /// </summary>
        /// <returns></returns>
        public string Verbose()
        {
            string outMessage = "";
            foreach (int i in this.set)
            {
                outMessage += $"{i} ";
            }
            return outMessage;
        }

        public static MathSet operator+(MathSet firstSet, MathSet secondSet)
        {
            string form = "";
            foreach (int i in firstSet.set)
            {
                form += $"{i} ";
            }
            foreach(int i in secondSet.set)
            {
                if (!firstSet.set.Contains(i))
                {
                    form += $"{i} ";
                }
            }
            return new MathSet(form);
        }

        public static MathSet operator*(MathSet firstSet, MathSet secondSet)
        {
            string form = "";
            foreach(int i in firstSet.set)
            {
                if (secondSet.set.Contains(i))
                {
                    form += $"{i} ";
                }
            }
            return new MathSet(form);
        }

        public static MathSet operator -(MathSet firstSet, MathSet secondSet)
        {
            string form = "";
            foreach(int i in firstSet.set)
            {
                if (!secondSet.set.Contains(i))
                {
                    form += $"{i} ";
                }
            }
            return new MathSet(form);
        }

    }
}
