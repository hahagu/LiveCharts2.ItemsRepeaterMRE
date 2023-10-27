using Avalonia;
using Avalonia.Controls;
using Avalonia.Threading;
using Avalonia.VisualTree;
using ReactiveUI;
using System.Threading;

namespace LiveCharts2.MRE.Views
{
    public partial class GraphView : UserControl
    {
        public GraphView()
        {
            InitializeComponent();

            Initialized += GraphView_Initialized;
        }

        private void GraphView_Initialized(object? sender, System.EventArgs e)
        {
            wrapper.Content = new GraphWrapper()
            {
                DataContext = this.DataContext
            };
        }
    }
}
