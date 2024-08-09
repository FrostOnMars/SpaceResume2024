using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace SpaceResume2024.ViewModels;

/// <summary>
/// Interaction logic for DropDownButtonBehaviorController.xaml
/// </summary>
public class DropDownButtonBehaviorController : Behavior<Button>
{
    #region Private Fields

    private bool _isContextMenuOpen;

    #endregion Private Fields

    #region Private Methods

    private void AssociatedObject_Click(object sender, RoutedEventArgs e)
    {
        if (sender is not Button { ContextMenu: not null } source) return;
        if (_isContextMenuOpen) return;

        // Add handler to detect when the ContextMenu closes
        source.ContextMenu.AddHandler(ContextMenu.ClosedEvent, new RoutedEventHandler(ContextMenu_Closed), true);
        // If there is a drop-down assigned to this button, then position and display it
        source.ContextMenu.PlacementTarget = source;
        source.ContextMenu.Placement = PlacementMode.Bottom;
        source.ContextMenu.IsOpen = true;
        _isContextMenuOpen = true;
    }

    private void ContextMenu_Closed(object sender, RoutedEventArgs e)
    {
        _isContextMenuOpen = false;
        if (sender is not ContextMenu contextMenu) return;
        contextMenu.RemoveHandler(ContextMenu.ClosedEvent, new RoutedEventHandler(ContextMenu_Closed));
    }

    #endregion Private Methods

    #region Protected Methods

    protected override void OnAttached()
    {
        base.OnAttached();
        AssociatedObject.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(AssociatedObject_Click), true);
    }

    protected override void OnDetaching()
    {
        base.OnDetaching();
        AssociatedObject.RemoveHandler(ButtonBase.ClickEvent, new RoutedEventHandler(AssociatedObject_Click));
    }

    #endregion Protected Methods
}