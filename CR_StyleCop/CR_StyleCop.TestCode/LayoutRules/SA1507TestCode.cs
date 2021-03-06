﻿// <copyright file="SA1507TestCode.cs" company="ACME">
//     Copyright (c) 2011. All rights reserved.
// </copyright>
// <summary>Summary for the file</summary>

namespace CR_StyleCop.TestCode
{
    using System;
    using System.Diagnostics.CodeAnalysis;


    
    /// <summary>
    /// Test code for SA1507 rule - multiple blank lines are bad.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "This is about SA1507 rule.")]
    public class SA1507TestCode
    {
        private int PropertyName { get; set; }


        private void MethodName()
        {
            int varName = 6;
   

            this.PropertyName = varName;
        }
    }
}
