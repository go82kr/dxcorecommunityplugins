﻿// <copyright file="SA1624TestCode.cs" company="ACME">
//     Copyright (c) 2011. All rights reserved.
// </copyright>
// <summary>Summary for the file</summary>

namespace CR_StyleCop.TestCode
{
    using System;
    using System.Diagnostics.CodeAnalysis;

#pragma warning disable 649

    /// <summary>
    /// Test code for SA1624 rule - restricted setters must be omitted from documentation text.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1609:PropertyDocumentationMustHaveValue", Justification = "This is about SA1624 rule")]
    public class SA1624TestCode
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "This is about SA1624 rule")]
        private int readOnlyProperty;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "This is about SA1624 rule")]
        private bool booleanReadOnlyProperty;

        /// <summary>
        /// Gets or sets a value indicating whether read only boolean value is true.
        /// </summary>
        public bool BooleanReadOnlyProperty
        {
            get { return this.booleanReadOnlyProperty; }
        }

        /// <summary>
        /// Gets or sets read only property.
        /// </summary>
        public int ReadOnlyProperty
        {
            get { return this.readOnlyProperty; }
        }
        
        /// <summary>
        /// Gets or sets index.
        /// </summary>
        public int Index { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether it is good comment.
        /// </summary>
        public bool BoolProperty { get; private set; }
    }
}
