﻿// <copyright file="SA1303TestCode.cs" company="ACME">
//     Copyright (c) 2011. All rights reserved.
// </copyright>
// <summary>Summary for the file</summary>

namespace CR_StyleCop.TestCode
{
    using System;
    using System.Diagnostics.CodeAnalysis;

#pragma warning disable 1591

    /// <summary>
    /// Test code for SA1303 rule - const must be upper cased.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "This is about SA1302 rule.")]
    public class SA1303TestCode
    {
        public const int ultimateAnswer2 = 42;

        internal const int ultimateAnswer3 = 42;

        protected internal const int ultimateAnswer4 = 42;

        protected const int ultimateAnswer5 = 42;

        private const int ultimateAnswer = 42;
    }
}
