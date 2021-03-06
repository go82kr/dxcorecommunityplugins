﻿// <copyright file="SA1203TestCode.cs" company="ACME">
//     Copyright (c) 2011. All rights reserved.
// </copyright>
// <summary>Summary for the file</summary>

namespace CR_StyleCop.TestCode
{
    using System;
    using System.Diagnostics.CodeAnalysis;

#pragma warning disable 1591

    /// <summary>
    /// Test code for SA1203 rule - const and readonly fields must come first.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "This is about SA1203 rule.")]
    public class SA1203TestCode
    {
        private string regular;
        private readonly string readOnly = string.Empty;
        private string regular2;
        private const string Constant = "";
        
        public string Regular
        {
            get { return this.regular; }
            set { this.regular = value; }
        }

        public string Regular2
        {
            get { return this.regular2; }
            set { this.regular2 = value; }
        }

        public string ReadOnly
        {
            get { return this.readOnly; }
        }

        public string Const1
        {
            get { return Constant; }
        }
    }
}
