﻿namespace CR_StyleCop.CodeIssues
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DevExpress.CodeRush.Core;
    using DevExpress.CodeRush.StructuralParser;
    using Microsoft.StyleCop;

    internal class KeywordCodeIssue : ICodeIssue
    {
        private readonly IEnumerable<string> keywords;

        public KeywordCodeIssue(IEnumerable<string> keywords)
        {
            this.keywords = keywords;
        }

        public void AddViolationIssue(CheckCodeIssuesEventArgs ea, IDocument document, Violation violation)
        {
            string message = String.Format("{0}: {1}", violation.Rule.CheckId, violation.Message);
            if (violation.Element == null)
            {
                ea.AddSmell(new SourceRange(violation.Line, 1, violation.Line, document.LengthOfLine(violation.Line) + 1), message, 10);
                return;
            }
            foreach (var token in violation.Element.ElementTokens.Where(t => t.LineNumber == violation.Line))
            {
                if (this.keywords.Contains(token.Text))
                {
                    SourceRange sourceRange = new SourceRange(token.Location.StartPoint.LineNumber, token.Location.StartPoint.IndexOnLine + 1, token.Location.EndPoint.LineNumber, token.Location.EndPoint.IndexOnLine + 2);
                    ea.AddSmell(sourceRange, message, 10);
                    return;
                }
            }
        }
    }
}