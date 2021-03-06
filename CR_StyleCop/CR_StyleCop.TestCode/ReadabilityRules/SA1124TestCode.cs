﻿// <copyright file="SA1124TestCode.cs" company="ACME">
//     Copyright (c) 2011. All rights reserved.
// </copyright>
// <summary>Summary for the file</summary>

namespace CR_StyleCop.TestCode
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

#pragma warning disable 162

    /// <summary>
    /// Test code for SA1124 rule - do not use regions at all.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "This is about SA1121 rule.")]
    public class SA1124TestCode
    {
        #region fields
        private string propertyName;
        private EventHandler eventName;
        #endregion

        #region ctors
        private SA1124TestCode(string propertyName)
        {
            this.propertyName = propertyName;
        }
        #endregion

        #region Events
        private event EventHandler EventName
        {
            #region event
            add
            {
                this.eventName = (EventHandler)Delegate.Combine(this.eventName, value);
            }

            remove
            {
                this.eventName = (EventHandler)Delegate.Remove(this.eventName, value);
            }
            #endregion
        }
        #endregion

        #region Properties
        private string PropertyName
        {
            #region property
            get
            {
                return this.propertyName;
            }

            set
            {
                this.propertyName = value;
            }
            #endregion
        }
        #endregion

        #region methods
        private void MethodName()
        {
            if (true)
            {
                return;
            }

            while (true)
            {
                return;
            }

            lock (this)
            {
                return;
            }

            for (int i = 0; i < 10; i++)
            {
                return;
            }

            foreach (int item in Enumerable.Empty<int>())
            {
                return;
            }

            switch ("foo")
            {
                case "foo":
                    return;
                default:
                    return;
            }
        }
        #endregion
    }
}
