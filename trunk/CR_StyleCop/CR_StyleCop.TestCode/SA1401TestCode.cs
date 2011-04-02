﻿namespace CR_StyleCop.TestCode
{
    using System;
    using System.Diagnostics.CodeAnalysis;

#pragma warning disable 649
#pragma warning disable 169

    /// <summary>
    /// Test code for SA1401 rule - fields must be private.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*", Justification = "We are interested only in SA1401TestCode violations here. We don't want to pollute test code with zillion of comments.")]
    public class SA1401TestCode
    {
        public static readonly string PublicStaticReadonlyField;
        public readonly string PublicReadonlyField;
        public static string PublicStaticField;
        public string PublicField;

        internal static readonly string InternalStaticReadonlyField;
        internal readonly string InternalReadonlyField;
        internal static string InternalStaticField;
        internal string InternalField;

        protected internal static readonly string ProtectedInternalStaticReadonlyField;
        protected internal readonly string ProtectedInternalReadonlyField;
        protected internal static string ProtectedInternalStaticField;
        protected internal string ProtectedInternalField;

        protected static readonly string ProtectedStaticReadonlyField;
        protected readonly string ProtectedReadonlyField;
        protected static string protectedStaticField;
        protected string protectedField;

        private static readonly string privateStaticReadonlyField;
        private readonly string privateReadonlyField;
        private static string privateStaticField;
        private string privateField;

        public struct Inner
        {
            public static readonly string PublicStaticReadonlyField;
            public readonly string PublicReadonlyField;
            public static string PublicStaticField;
            public string PublicField;

            internal static readonly string InternalStaticReadonlyField;
            internal readonly string InternalReadonlyField;
            internal static string InternalStaticField;
            internal string InternalField;

            private static readonly string privateStaticReadonlyField;
            private readonly string privateReadonlyField;
            private static string privateStaticField;
            private string privateField;
        }
    }
}