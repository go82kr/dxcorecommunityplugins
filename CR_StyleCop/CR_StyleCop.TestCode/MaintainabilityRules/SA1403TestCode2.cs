﻿// <copyright file="SA1403TestCode2.cs" company="ACME">
//     Copyright (c) 2011. All rights reserved.
// </copyright>
// <summary>Summary for the file</summary>

namespace CR_StyleCop.TestCode
{
    using System;

    /// <summary>
    /// Test code for SA1403 rule - file can have only one namespace declaration.
    /// </summary>
    public class SA1403TestCode2
    {
    }
}

namespace Second
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Test code for SA1403 rule - file can have only one namespace declaration.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "This is about SA1403 rule.")]
    public class SecondClass2
    {
    }
}