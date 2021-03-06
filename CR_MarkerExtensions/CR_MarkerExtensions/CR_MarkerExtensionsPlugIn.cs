using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using DevExpress.CodeRush.Core;
using DevExpress.CodeRush.PlugInCore;
using DevExpress.CodeRush.StructuralParser;
using DxDwg=DevExpress.DXCore.Platform.Drawing;

namespace CR_MarkerExtensions
{
  public partial class CR_MarkerExtensionsPlugIn : StandardPlugIn
  {
    // DXCore-generated code...
    #region InitializePlugIn
    public override void InitializePlugIn()
    {
      base.InitializePlugIn();
      Opt_MarkerExtensions.LoadSettings(_settings);
      this.Disposed += (sender, e) =>
        {
          if ( _locatorBeacon != null )
          {
            _locatorBeacon.Dispose();
            _locatorBeacon = null;
          }
          if ( _cornerBeacon != null )
          {
            _cornerBeacon.Dispose();
            _cornerBeacon = null;
          }
        };
    }
    #endregion
    #region FinalizePlugIn
    public override void FinalizePlugIn()
    {
      base.FinalizePlugIn();
    }
    #endregion

    private enum NavDestination { None, First, Prev, Next, Last, AtCaret, StackTop, StackBottom }

    private void GetMarkerActionProperties(DevExpress.CodeRush.Core.Action action, out NavDestination destination, out bool collect)
    {
      if ( action == MarkerFirstAction || action == MarkerCollectFirstAction )
        destination = NavDestination.First;
      else if ( action == MarkerPrevAction || action == MarkerCollectPrevAction )
        destination = NavDestination.Prev;
      else if ( action == MarkerNextAction || action == MarkerCollectNextAction )
        destination = NavDestination.Next;
      else if ( action == MarkerLastAction || action == MarkerCollectLastAction )
        destination = NavDestination.Last;
      else if ( action == MarkerCollectAtCaretAction )
        destination = NavDestination.AtCaret;
      else if ( action == MarkerStackTopAction )
        destination = NavDestination.StackTop;
      else if ( action == MarkerStackBottomAction )
        destination = NavDestination.StackBottom;
      else
        destination = NavDestination.None;

      collect = action == MarkerCollectFirstAction || action == MarkerCollectPrevAction
        || action == MarkerCollectNextAction || action == MarkerCollectLastAction || action == MarkerCollectAtCaretAction;
    }
    private int LoadMarkerList(List<IMarker> markers, bool skipSelectionMarkers)
    {
      markers.Clear();
      foreach ( IMarker marker in CodeRush.Markers )
      {
        if ( marker.TextDocument == CodeRush.Documents.ActiveTextDocument && !marker.Hidden && !marker.Temporal )
        {
          bool skipIt = skipSelectionMarkers && marker is ISelectionMarker && ((ISelectionMarker)marker).HasSelection;
          if ( !skipIt )
            markers.Add(marker);
        }
      }
      return markers.Count;
    }
    private void SortMarkerListInDocumentOrder(List<IMarker> markers)
    {
      markers.Sort((m1, m2) =>
      {
        int result = m1.Line - m2.Line;
        if ( result == 0 )
          result = m1.Column - m2.Column;
        return result;
      });
    }
    private IMarker GetTargetMarker(NavDestination destination)
    {
      if ( destination == NavDestination.None || CodeRush.Documents.ActiveTextDocument == null )
        return null;

      TextView activeView = CodeRush.Documents.ActiveTextDocument.ActiveView;
      if ( activeView == null )
        return null;

      var markers = new List<IMarker>();
      LoadMarkerList(markers, _settings.SkipSelectionMarkers);
      if ( markers.Count == 0 )
        return null;

      // all non-stack operations require the marker list to be in document order
      if ( destination != NavDestination.StackTop && destination != NavDestination.StackBottom )
        SortMarkerListInDocumentOrder(markers);

      IMarker closestMarker = null;
      IMarker firstMarker = markers[0];
      IMarker lastMarker = markers[markers.Count - 1];
      int caretLine = activeView.Caret.Line;
      int caretColumn = activeView.Caret.ViewColumn;
      switch ( destination )
      {
        case NavDestination.First:
        case NavDestination.StackBottom:
          closestMarker = firstMarker;
          break;
        case NavDestination.Prev:
        case NavDestination.Next:
          if ( destination == NavDestination.Prev )
            closestMarker = markers.FindLast(marker =>
              marker.Line < caretLine || (marker.Line == caretLine && marker.Column < caretColumn));
          else
            closestMarker = markers.Find(marker =>
              marker.Line > caretLine || (marker.Line == caretLine && marker.Column > caretColumn));

          // if no target found and we have only a single marker, that's the new target
          if ( closestMarker == null && markers.Count == 1 )
          {
            IMarker marker = firstMarker;
            if ( marker.Line == caretLine && marker.Column == caretColumn )
              closestMarker = marker;
          }
          // if we allow "rolling over" on prev/next, do so
          if ( _settings.RollOverOnPrevNext && closestMarker == null )
          {
            if ( destination == NavDestination.Prev )
              closestMarker = lastMarker;
            else if ( destination == NavDestination.Next )
              closestMarker = firstMarker;
          }
          break;
        case NavDestination.Last:
        case NavDestination.StackTop:
          closestMarker = lastMarker;
          break;
        case NavDestination.AtCaret:
          closestMarker = markers.FindLast(marker => marker.Line == caretLine && marker.Column == caretColumn);
          break;
      }
      return closestMarker;
    }
    private void ShineLocatorBeacon(IMarker marker)
    {
      if ( marker == null || marker.TextDocument == null || marker.TextDocument.ActiveView == null )
        return;

      if ( _settings.ShowBeacon )
      {
        bool wasBeaconAnimated = false;

        var selectionMarker = marker as ISelectionMarker;
        if ( selectionMarker != null && selectionMarker.HasSelection )
        {
          if ( _cornerBeacon == null )
            _cornerBeacon = new DevExpress.CodeRush.PlugInCore.CornerBeacon();

          if ( _cornerBeacon.AccomplishedPercent > 0f )
            _cornerBeacon.Stop();

          _cornerBeacon.Color = DxDwg.Color.ConvertFrom(_settings.BeaconColor);
          _cornerBeacon.Duration = _settings.BeaconDuration;
          var range = new SourceRange(selectionMarker.AnchorLine, selectionMarker.AnchorColumn, selectionMarker.Line, selectionMarker.Column);
          _cornerBeacon.Start(marker.TextDocument.ActiveView, range.Top, range.Bottom, 0x1a);

          wasBeaconAnimated = true;
        }

        if ( !wasBeaconAnimated )
        {
          if ( _locatorBeacon == null )
            _locatorBeacon = new DevExpress.CodeRush.PlugInCore.LocatorBeacon();

          if ( _locatorBeacon.AccomplishedPercent > 0f )
            _locatorBeacon.Stop();
          _locatorBeacon.Color = DxDwg.Color.ConvertFrom(_settings.BeaconColor);
          _locatorBeacon.Duration = _settings.BeaconDuration;
          _locatorBeacon.Start(marker.TextDocument.ActiveView, marker.Line, marker.Column);
        }
      }
    }

    private PlugInSettings _settings = new PlugInSettings();
    private DevExpress.CodeRush.PlugInCore.LocatorBeacon _locatorBeacon;
    private DevExpress.CodeRush.PlugInCore.CornerBeacon _cornerBeacon;

    private void CR_MarkerExtensionsPlugIn_OptionsChanged(OptionsChangedEventArgs e)
    {
      if ( e.OptionsPages.Contains(typeof(Opt_MarkerExtensions)) )
        Opt_MarkerExtensions.LoadSettings(_settings);
    }
    private void MarkerAction_Execute(ExecuteEventArgs e)
    {
      NavDestination destination;
      bool collect;
      GetMarkerActionProperties(e.Action, out destination, out collect);
      IMarker marker = GetTargetMarker(destination);
      if ( marker != null )
      {
        marker.RestorePosition();
        ShineLocatorBeacon(marker);
        if ( collect )
          CodeRush.Markers.Remove(marker);
      }
    }
    private void MarkerClearAllAction_Execute(ExecuteEventArgs ea)
    {
      List<IMarker> markers = new List<IMarker>();
      LoadMarkerList(markers, false);
      foreach ( IMarker marker in markers )
        CodeRush.Markers.Remove(marker);
    }
  }
}