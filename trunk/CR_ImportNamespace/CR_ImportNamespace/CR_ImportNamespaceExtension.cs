using System.ComponentModel.Composition;
using DevExpress.CodeRush.Common;

namespace CR_ImportNamespace
{
  [Export(typeof(IVsixPluginExtension))]
  public class CR_ImportNamespaceExtension : IVsixPluginExtension { }
}