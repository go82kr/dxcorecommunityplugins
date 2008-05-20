using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.CodeRush.Core;
using DevExpress.CodeRush.PlugInCore;
using DevExpress.CodeRush.StructuralParser;
using System.Collections.Generic;
using System.Text;

namespace CR_BlockPainterPlus
{
    public partial class BlockPainterPlusPlugin : StandardPlugIn
    {
        private const string MethodOpenParen = " (";
        private const string MethodCloseParen = ")";
        private const string CommaDelimiter = ", ";
        private const string Chevron = " «";
        private const string Space = " ";
        private const string OutParam = "out ";
        private const string RefParam = "ref ";
        private List<int> _processedLines = new List<int>();

        private static Color _arrowColor = Color.Red;
        private static Color _fontColor = Color.LightBlue;
        private static int _arrowOpacity = 125;
        private static int _fontOpacity = 125;
        private static bool _minimumLinesRequired = false;
        private static int _minimumLineCount = 10;

        private static readonly string _optionsPageFullName =
            String.Format("{0}\\{1}", BlockPainterOptions.GetCategory(), BlockPainterOptions.GetPageName());

        // DXCore-generated code...
        #region InitializePlugIn
        public override void InitializePlugIn()
        {
            base.InitializePlugIn();
            LoadSettings();
        }


        #endregion
        #region FinalizePlugIn
        public override void FinalizePlugIn()
        {
            base.FinalizePlugIn();
        }
        #endregion

        private void BlockPainterPlusPlugin_EditorPaintBackground(EditorPaintEventArgs ea)
        {
            /* clear out the list of lines that were already processed. */
            _processedLines.Clear();
        }

        private void BlockPainterPlusPlugin_EditorPaintLanguageElement(EditorPaintLanguageElementEventArgs ea)
        {
            DelimiterCapableBlock delimitedBlock = ea.LanguageElement as DelimiterCapableBlock;

            if (delimitedBlock == null) return;
            if (delimitedBlock.BlockType != DelimiterBlockType.Brace) return;
            if(_processedLines.Contains(delimitedBlock.EndLine)) return;
            
            if (_minimumLinesRequired)
            {
                /* only paint the block if it is longer than n lines */
                if ((delimitedBlock.EndLine - delimitedBlock.StartLine) < _minimumLineCount) return;
            }

            /* get the line number that this block ends on */
            int eolOffset = CodeRush.TextViews.Active.LengthOfLine(delimitedBlock.EndLine);

            /* gets a list of blocks that end on the current line */
            /* if code is written in c style, this list will almost always have only one element.
             * however, if java style coding is used, this could be multiple blocks.
             * consider the following code snippet:
             * if(some statement is true){
             *  do some stuff
             * } else { do some other stuff}
             * in this case, we have 2 blocks that end on the same line.
             */
            IList<DelimiterCapableBlock> blocksOnCurrentLine = GetBlocksOnLine(delimitedBlock);

            /* now we take the list of blocks and create a string to paint */
            string overlayText = GetOverLayText(blocksOnCurrentLine);

            PaintBlock(overlayText, delimitedBlock.EndLine, eolOffset, ea.PaintArgs);

            /* by adding the lines already processed to a collection, we eliminate processing elements more than once. */
            _processedLines.Add(delimitedBlock.EndLine);


            /* this section will paint methods in bold, red font */
            if (ea.LanguageElement is Method && !(ea.LanguageElement is OperatorExpression))
            {
                IElement element = ea.LanguageElement as IElement;
                TextView activeTextView = CodeRush.TextViews.Active;
                int startLine = element.NameRanges[0].Start.Line;
                int startOffset = element.NameRanges[0].Start.Offset;

                activeTextView.OverlayText(element.Name, startLine, startOffset, Color.White, true);
                activeTextView.OverlayText(element.Name, startLine, startOffset, Color.Red, true);
            }
        }

        private static IList<DelimiterCapableBlock> GetBlocksOnLine(DelimiterCapableBlock firstBlockOnLine)
        {
            IList<DelimiterCapableBlock> blocksOnLine = new List<DelimiterCapableBlock>();
            /* we always want to add the first block :-P */
            blocksOnLine.Add(firstBlockOnLine);

            /* iterate through every block after our first block until they are
             * not on the same line. the idea is to get every delimiter capable block 
             * that ends on the same line.*/

            LanguageElement siblingElement = firstBlockOnLine.NextCodeSibling;
            while (siblingElement != null)
            {
                if (siblingElement.EndLine != firstBlockOnLine.EndLine) break;

                if (siblingElement is DelimiterCapableBlock)
                {
                    DelimiterCapableBlock siblingBlock = siblingElement as DelimiterCapableBlock;
                    if (siblingBlock.HasDelimitedBlock)
                    {
                        blocksOnLine.Add(siblingBlock);
                    }
                }
                /* now assign the next element to the next code sibling. this prevents infinite looping.*/
                siblingElement = siblingElement.NextCodeSibling;
            }
            return blocksOnLine;
        }

        private static string GetOverLayText(IList<DelimiterCapableBlock> blocksToPaint)
        {
            /*how much memory is this using? is there a way to minimize the impact? */
            StringBuilder overlayTextBuilder = new StringBuilder();

            for (int i = 0; i < blocksToPaint.Count; i++)
            {
                LanguageElement element = blocksToPaint[i] as LanguageElement;
                //overlayTextBuilder.Append(element.GetTypeName().ToLower());
                overlayTextBuilder.Append(element.ElementType.ToString().ToLower());

                /* methods get their signature added to the overlay text */
                if (element is Method)
                {
                    GetMethodOverlayText(element as Method, ref overlayTextBuilder);
                }

                /* is there an easy way to generalize this and make it available for any element type? */
                if (element is Class || element is Namespace)
                {
                    overlayTextBuilder.Append(Space);
                    overlayTextBuilder.Append(element.Name);
                }

                /*append a comma and space if we have more blocks to paint */
                if (i < (blocksToPaint.Count - 1))
                {
                    overlayTextBuilder.Append(CommaDelimiter);
                }
            }

            return overlayTextBuilder.ToString();
        }

        private static void GetMethodOverlayText(Method method, ref StringBuilder overlayTextBuilder)
        {
            overlayTextBuilder.Append(Space);
            overlayTextBuilder.Append(method.Name);
            overlayTextBuilder.Append(MethodOpenParen);

            for (int i = 0; i < method.Parameters.Count; i++)
            {
                Param parameter = method.Parameters[i] as Param;

                if (parameter.IsOutParam)
                {
                    overlayTextBuilder.Append(OutParam);
                }

                if (parameter.IsReferenceParam)
                {
                    overlayTextBuilder.Append(RefParam);
                }

                overlayTextBuilder.Append(parameter.GetTypeName());

                if (i < method.Parameters.Count - 1)
                {
                    overlayTextBuilder.Append(CommaDelimiter);
                }
            }
            overlayTextBuilder.Append(MethodCloseParen);
        }

        private static void PaintBlock(string textToOverlay, int line, int offset, EditorPaintEventArgs paintArgs)
        {
            /* first paint the chevrons */
            paintArgs.OverlayText(Chevron, line, offset + 1, Color.FromArgb(_arrowOpacity, _arrowColor));
            /* now paint the overlay text. */
            paintArgs.OverlayText(textToOverlay, line, offset + 4, Color.FromArgb(_fontOpacity, _fontColor));
        }

        private void LoadSettings()
        {
            using (DecoupledStorage storage = new DecoupledStorage(BlockPainterOptions.GetCategory(), BlockPainterOptions.GetPageName()))
            {
                _arrowColor = storage.ReadColor(BlockPainterOptions.SectionName, BlockPainterOptions.ArrowColor, Color.Red);
                _arrowOpacity = storage.ReadInt32(BlockPainterOptions.SectionName, BlockPainterOptions.ArrowOpacity, 125);
                _fontColor = storage.ReadColor(BlockPainterOptions.SectionName, BlockPainterOptions.FontColor, Color.LightBlue);
                _fontOpacity = storage.ReadInt32(BlockPainterOptions.SectionName, BlockPainterOptions.FontOpacity, 125);
                _minimumLineCount = storage.ReadInt32(BlockPainterOptions.SectionName, BlockPainterOptions.MinimumLineCount, 10);
                _minimumLinesRequired = storage.ReadBoolean(BlockPainterOptions.SectionName, BlockPainterOptions.MinimumLines, false);
            }
        }

        private void BlockPainterPlusPlugin_OptionsChanged(OptionsChangedEventArgs ea)
        {
            if (ea.OptionsPages.Contains(_optionsPageFullName))
            {
                LoadSettings();
            }
        }
    }
}