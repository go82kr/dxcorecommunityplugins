﻿namespace CR_StyleCop.CodeIssues
{
    using System;

    internal class SA1300_ElementMustBeginWithUpperCaseLetter : StyleCopRule
    {
        public SA1300_ElementMustBeginWithUpperCaseLetter()
            : base(new ElementNameIssueLocator())
        {
        }
    }
}
