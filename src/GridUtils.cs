using System;
using Avalonia;
using Avalonia.Controls;

namespace AvaloniaUtils;

public readonly record struct GridPosition(int Row = 0, int Column = 0, int RowSpan = 1, int ColumnSpan = 1) {
    public static GridPosition Parse(string s) {
        string[] t = s.Split(' ');
        if (t.Length is 0 or > 2)
            throw new FormatException($"{s} is not a valid grid position.");
        // ReSharper disable once RedundantAssignment
        int row = 0, column = 0, rowSpan = 1, columnSpan = 1;
        string[] rowPosition = t[0].Split('+');
        if (rowPosition.Length is 0 or > 2)
            throw new FormatException($"{rowPosition} is not a valid row position.");
        row = int.Parse(rowPosition[0]);
        if (rowPosition.Length == 2)
            rowSpan = int.Parse(rowPosition[1]);
        // ReSharper disable once InvertIf
        if (t.Length == 2) {
            string[] columnPosition = t[1].Split('+'); 
            if (columnPosition.Length is 0 or > 2)
                throw new FormatException($"{columnPosition} is not a valid column position.");
            column = int.Parse(columnPosition[0]);
            if (columnPosition.Length == 2)
                columnSpan = int.Parse(columnPosition[1]);
        }

        return new GridPosition(row, column, rowSpan, columnSpan);
    }
}

public class Grid : AvaloniaObject {
    public static readonly AttachedProperty<GridPosition?> PositionProperty =
        AvaloniaProperty.RegisterAttached<Grid, Control, GridPosition?>("Position");

    public static void SetPosition(Control control, string value) =>
        control.SetValue(PositionProperty, GridPosition.Parse(value));

    public static GridPosition? GetPosition(Control control) => control.GetValue(PositionProperty);

    static Grid() {
        PositionProperty.Changed.AddClassHandler<Control>((control, args) => {
            if (args.NewValue is not GridPosition newPosition)
                return;
            Avalonia.Controls.Grid.SetRow(control,newPosition.Row);
            Avalonia.Controls.Grid.SetColumn(control,newPosition.Column);
            Avalonia.Controls.Grid.SetRowSpan(control,newPosition.RowSpan);
            Avalonia.Controls.Grid.SetColumnSpan(control,newPosition.ColumnSpan);
        });
    }
}