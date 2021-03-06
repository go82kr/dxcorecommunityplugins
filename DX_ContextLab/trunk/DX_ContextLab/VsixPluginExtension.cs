﻿using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
using DevExpress.CodeRush.Common;

namespace DX_ContextLab
{
	/// <summary>
	/// Shim VSIX extension for DXCore plugin.
	/// </summary>
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Plugin")]
	[SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Vsix")]
	[Export(typeof(IVsixPluginExtension))]
	public class VsixPluginExtension : IVsixPluginExtension
	{
	}
}