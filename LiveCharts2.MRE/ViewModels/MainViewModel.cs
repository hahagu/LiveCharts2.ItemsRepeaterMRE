using LiveChartsCore.Defaults;
using LiveChartsCore.Drawing;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Collections.Generic;

namespace LiveCharts2.MRE.ViewModels;

public class MainViewModel : ViewModelBase
{
    public List<GraphViewModel> Graphs { get; } = new();

    public MainViewModel()
    {
        for (int i = 0; i < 20; i++)
        {
            Graphs.Add(new GraphViewModel());
        }
    }
}
