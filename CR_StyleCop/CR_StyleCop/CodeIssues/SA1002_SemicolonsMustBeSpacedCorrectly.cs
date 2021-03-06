﻿namespace CR_StyleCop.CodeIssues
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using StyleCop.CSharp;

    internal class SA1002_SemicolonsMustBeSpacedCorrectly : StyleCopRule
    {
        public SA1002_SemicolonsMustBeSpacedCorrectly()
            : base(new AggregatedIssueLocator(new ICodeIssueLocator[] 
                { 
                    new AllTokensByTypePrecededByBannedElementIssueLocator(ElementTokens, CsTokenType.Semicolon, CsTokenType.WhiteSpace, CsTokenType.EndOfLine),
                    new AllTokensByTypeNotFollowedByRequiredElementIssueLocator(ElementTokens, CsTokenType.Semicolon, CsTokenType.WhiteSpace, CsTokenType.EndOfLine),
                }))
        {
        }
    }
}
