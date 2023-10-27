using LiveChartsCore.Defaults;
using LiveChartsCore.Drawing;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LiveCharts2.MRE.ViewModels
{
    public class GraphViewModel : ViewModelBase
    {
        public object SyncObject { get; } = new();

        private Axis _xAxis;
        public Axis[] XAxes { get; }

        private Axis _yAxis;
        public Axis[] YAxes { get; }

        private LineSeries<ObservablePoint> _series;
        public ISeries[] Series { get; }

        private ObservableCollection<ObservablePoint> _values = new();

        private Timer timer;

        public GraphViewModel()
        {
            _xAxis = new Axis
            {
                LabelsPaint = new SolidColorPaint(SKColors.White),
            };

            XAxes = new Axis[] { _xAxis };

            _yAxis = new Axis
            {
                LabelsPaint = new SolidColorPaint(SKColors.White),
            };

            YAxes = new Axis[] { _yAxis };

            _series = new LineSeries<ObservablePoint>
            {
                DataPadding = new LvcPoint(0, 2),
                Values = _values,
                Fill = new SolidColorPaint(SKColors.White),
                Stroke = null,
                GeometryFill = null,
                GeometryStroke = null,
            };

            Series = new ISeries[] { _series };

            timer = new Timer((_) => Tick(), null, 0, 100);
        }

        private Random random = new Random();
        private int _index = -1;
        private double _lastValue = 10;

        private void Tick()
        {
            lock (SyncObject)
            {
                double newValue = _lastValue + random.NextDouble() - 0.5;
                _values.Add(new(_index++, newValue));
                if (_values.Count > 50) _values.RemoveAt(0);
            }
        }
    }
}
