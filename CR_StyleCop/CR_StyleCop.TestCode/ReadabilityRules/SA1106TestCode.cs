﻿// <copyright file="SA1106TestCode.cs" company="ACME">
//     Copyright (c) 2011. All rights reserved.
// </copyright>
// <summary>Summary for the file</summary>

namespace CR_StyleCop.TestCode
{
    using System;
    using System.Diagnostics.CodeAnalysis;

#pragma warning disable 642

    /// <summary>
    /// Test code for SA1106 rule - code must not contain empty statements.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "*", Justification = "This is about SA1106 rule.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "This is about SA1106 rule.")]
    [SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1002:SemicolonsMustBeSpacedCorrectly", Justification = "This is about SA1106 rule.")]
    public class SA1106TestCode
    {
        private void MethodName()
        {
            for (int i = 0; i < 31; i++)
            {
                i--;;
            }

            if (6 == 6)
                ;
        }
    }
}
