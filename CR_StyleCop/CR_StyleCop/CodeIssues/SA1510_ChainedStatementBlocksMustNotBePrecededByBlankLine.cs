﻿namespace CR_StyleCop.CodeIssues
{
    using System;

    internal class SA1510_ChainedStatementBlocksMustNotBePrecededByBlankLine : KeywordCodeIssue
    {
        public SA1510_ChainedStatementBlocksMustNotBePrecededByBlankLine()
            : base(Underline.FirstKeywordOnLine, "else", "catch", "finally")
        {
        }
    }
}