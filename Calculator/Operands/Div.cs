﻿/*
    Copyright (c) 2011, Måns Andersson <mail@mansandersson.se>

    Permission to use, copy, modify, and/or distribute this software for any
    purpose with or without fee is hereby granted, provided that the above
    copyright notice and this permission notice appear in all copies.

    THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES
    WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF
    MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR
    ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES
    WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN
    ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF
    OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator.Operands
{
    /// <summary>
    /// Divison operator
    /// </summary>
    public class Div : Operator
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Div()
        {
            this.Precedence = Precedences.MultDiv;
        }

        /// <summary>
        /// Execute divison operator and put result into operands stack
        /// </summary>
        /// <param name="operands">stack with operands</param>
        /// <param name="mode">mode to operate in</param>
        /// <returns>true/false if execution went well</returns>
        public override bool Execute(Stack<Operand> operands, CalculatorMode mode)
        {
            try
            {
                // b / a
                Operand a = operands.Pop();
                Operand b = operands.Pop();
                Operand c; // result

                // if we are in programming mode and both operands are integers
                // do a integer division
                if (mode == CalculatorMode.Programming &&
                    a.Value == (Int32)a.Value &&
                    b.Value == (Int32)b.Value)
                {
                    c = new Operand((Int32)b.Value / (Int32)a.Value);
                }
                else
                {
                    c = new Operand(b.Value / a.Value);
                }
                operands.Push(c);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
