﻿// <copyright file="SA1205TestCode.cs" company="ACME">
//     Copyright (c) 2011. All rights reserved.
// </copyright>
// <summary>Summary for the file</summary>

namespace CR_StyleCop.TestCode
{
    using System;
    using System.Diagnostics.CodeAnalysis;

#pragma warning disable 1591

    /// <summary>
    /// Test code for SA1205 rule - partial elements must declare access.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "This is about SA1205 rule.")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "*", Justification = "This is about SA1205 rule.")]
    public class SA1205TestCode
    {
        partial class PartialInner
        {
        }

        public class Inner
        {
        }
    }
}
