﻿// <copyright file="SA1302TestCode.cs" company="ACME">
//     Copyright (c) 2011. All rights reserved.
// </copyright>
// <summary>Summary for the file</summary>

namespace CR_StyleCop.TestCode
{
    using System;
    using System.Diagnostics.CodeAnalysis;

#pragma warning disable 1591

    /// <summary>
    /// Test code for SA1302 rule - interface name must begin with "I".
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "This is about SA1302 rule.")]
    public class SA1302TestCode
    {
        public interface iMyInterface
        {
        }

        public interface MyInterface
        {
        }

        public interface myInterface
        {
        }

        public interface ImyInterface
        {
        }
    }
}
