﻿// <copyright file="SA1103TestCode.cs" company="ACME">
//     Copyright (c) 2011. All rights reserved.
// </copyright>
// <summary>Summary for the file</summary>

namespace CR_StyleCop.TestCode
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// Test code for SA1103 rule - query clauses must be on separate lines or on single line.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "This is about SA1103 rule.")]
    public class SA1103TestCode
    {
        private void MethodName()
        {
            var ints = Enumerable.Range(1, 10);
            var odd = from i in ints
                      where i % 2 == 0
                      select i;

            var odd2 = from i in ints
                       where i % 2 == 0 select i;

            var odd3 = from i in ints where i % 2 == 0 select i;

            var odd4 = from i in ints where i % 2 == 0 
                       select i;
        }
    }
}
