﻿// <copyright file="SA1605TestCode.cs" company="ACME">
//     Copyright (c) 2011. All rights reserved.
// </copyright>
// <summary>Summary for the file</summary>

namespace CR_StyleCop.TestCode
{
    using System;

#pragma warning disable 1710

    /// <typeparam name="T">Generic parameter.</typeparam>
    public partial class SA1605TestCode<T>
    {
        /// <param name="paramName">The parameter for method.</param>
        partial void Method(int paramName);
    }

    /// <typeparam name="T">Generic parameter.</typeparam>
    public partial class SA1605TestCode<T>
    {
        /// <param name="paramName">The parameter for method.</param>
        partial void Method(int paramName)
        {
        }
    }
}
