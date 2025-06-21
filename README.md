# Avalonia Utils

Provide some utilities for Avalonia.

## Get Started

### Add NuGet Package:

```bash
dotnet add package AvaloniaUtils
```

### Include in Your Axaml:
```xaml
xmlns:utils="https://github.com/metaone01/AvaloniaUtils"
```

## GridUtils

Arguments in *[ ]* means they are optional.

`Grid.Position`: `Row`\[+`RowSpan`\] `Column` \[+ `ColumnSpan`\]
```xaml
<CONTROL utils:Grid.Position="1+2 2"/>
<!-- ↑ using AvaloniaUtils ↑ -->

<!-- ↓ Avalonia default ↓ -->
<CONTROL Grid.Row="1" Grid.Column="2" Grid.RowSpan="2"/>
```