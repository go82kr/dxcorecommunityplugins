﻿// <copyright file="SA1503TestCode.cs" company="ACME">
//     Copyright (c) 2011. All rights reserved.
// </copyright>
// <summary>Summary for the file</summary>

namespace CR_StyleCop.TestCode
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Test code for SA1503 rule - curly brackets must not be omitted.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "This is about SA1503 rule.")]
    public class SA1503TestCode
    {
        private object syncRoot = new object();

        private void MethodName(string x)
        {
            if (string.IsNullOrEmpty(x))
                throw new ArgumentException("x is null or empty.", "x");

            while (string.IsNullOrEmpty(x))
                x = x.Substring(1);

            lock (this.syncRoot) 
                x = x.Substring(1);

            for (int i = 0; i < 5; i++)
                x = x.Substring(1);

            foreach (int s in new int[] { 1, 2 })
                x = x.Substring(1);

            do
                x = x.Substring(1);
            while (string.IsNullOrEmpty(x));

            using (new System.IO.StreamReader("aaa"))
                x = x.Substring(1);
        }
    }
}
