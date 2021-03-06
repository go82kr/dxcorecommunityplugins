/*
 * Software License Agreement for RedGreen
 * 
 * Copyright (c) 2010 Renaissance Learning, Inc. and James Argeropoulos
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
using System;
using DevExpress.CodeRush.Core;

namespace Impromptu
{
	[UserLevel(UserLevel.NewUser)]
	public partial class ImpromptuOptions : OptionsPage
	{
		// DXCore-generated code...
		#region Initialize
		protected override void Initialize()
		{
			base.Initialize();

			//
			// TODO: Add your initialization code here.
			//
		}
		#endregion

		#region GetCategory
		public static string GetCategory()
		{
			return @"";
		}
		#endregion
		#region GetPageName
		public static string GetPageName()
		{
			return @"Impromptu";
		}
		#endregion

		public static bool ReadDisplayIcon(DecoupledStorage storage)
		{
			return storage.ReadBoolean("Preferences", "DisplayRunIcon", true);
		}

		private void ImpromptuOptions_PreparePage(object sender, OptionsPageStorageEventArgs ea)
		{
			dispalyTile.Checked = ReadDisplayIcon(ea.Storage);
		}

		private void ImpromptuOptions_CommitChanges(object sender, CommitChangesEventArgs ea)
		{
			ea.Storage.WriteBoolean("Preferences", "DisplayRunIcon", dispalyTile.Checked);
		}
	}
}