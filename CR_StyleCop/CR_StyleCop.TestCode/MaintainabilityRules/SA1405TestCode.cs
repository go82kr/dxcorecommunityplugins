﻿// <copyright file="SA1405TestCode.cs" company="ACME">
//     Copyright (c) 2011. All rights reserved.
// </copyright>
// <summary>Summary for the file</summary>

namespace CR_StyleCop.TestCode
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Test code for SA1405 rule - Debug.Assert must provide message.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "*", Justification = "This is about SA1405 rule")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "This is about SA1405 rule.")]
    public class SA1405TestCode
    {
        private const string MessageConstant = "";
        private const string MessageConstant2 = null;

        private void MethodName(bool val)
        {
            Debug.Assert(val != true, "");
            Debug.Assert(val != true, @"");
            Debug.Assert(val != true, String.Empty);
            Debug.Assert(val != true, System.String.Empty);
            Debug.Assert(val != true, global::System.String.Empty);
            Debug.Assert(val != true, string.Empty);
            Debug.Assert(val != true, null);
            Debug.Assert(val != true);
            string message = null;  
            Debug.Assert(val != true, message);
            Debug.Assert(val != true, MessageConstant);
            Debug.Assert(val != true, MessageConstant2);
        }
    }
}