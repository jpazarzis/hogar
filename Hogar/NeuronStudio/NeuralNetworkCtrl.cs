using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hogar.Algorithms.ANN.Neurons;
using Hogar.Algorithms.ANN.Neurons.NeuronNetworks;

namespace NeuronStudio
{
    public partial class NeuralNetworkCtrl : Control
    {
        private int _verticalStep = 40;
        private int _horizontalStep = 200;
        private Pen _pen = new Pen(Color.Blue);
        private readonly SolidBrush _neuralBrush = new SolidBrush(Color.Blue);
        private readonly SolidBrush _treshHoldNeuralBrush = new SolidBrush(Color.Cyan);
        private readonly SolidBrush _outputNeuralBrush = new SolidBrush(Color.MediumVioletRed);
        private readonly SolidBrush _outputHighBruh = new SolidBrush(Color.Blue);
        

        private Pen _synapsesPen = new Pen(Color.Green, 1F);

        private NeuronNetwork _nn;
        private Font _font = new Font("Arial", 8);
        private Font _fontForNeuralValue = new Font("Arial", 10, FontStyle.Bold);
        private Font _fontForSynapticWeight = new Font("Arial", 8, FontStyle.Regular);


        private readonly SolidBrush _neuralValueBrush = new SolidBrush(Color.Red);

        private Dictionary<Neuron, Point> _neuralPosition = new Dictionary<Neuron, Point>();

        public NeuralNetworkCtrl()
        {
            InitializeComponent();
        }

        public void Bind(NeuronNetwork nn)
        {
            _nn = nn;
        }



        protected override void OnPaint(PaintEventArgs pe)
        {

            pe.Graphics.Clear(Color.White);

            if (null == _nn)
                return;

            PaintAllNeurons(pe);
            PaintAllSenapes(pe);
        }

        private void PaintAllSenapes(PaintEventArgs pe)
        {
            double rate = 1.2;

            foreach (var layer in _nn.Layers)
            {
                foreach (var neuron in layer.Neurons)
                {
                    rate *= 1.2;

                    if (rate >= 8)
                        rate = 1.2;

                    foreach (var synapse in neuron.Synapses)
                    {
                        PaintSynapse(synapse, pe, rate);

                    }
                }


            }
        }

        private Point FindWhereToDrawSynapticWeight(Point p1, Point p2, double rate)
        {
            double y = p1.Y + (p2.Y - p1.Y) / rate - 7;
            double x = p1.X + (p2.X - p1.X) / rate;
            return new Point((int)x, (int)y);

        }

        private void PaintSynapse(Synapse synapse, PaintEventArgs pe, double rate)
        {
            var n1 = synapse.Neuron1;
            var n2 = synapse.Neuron2;

            var pos1 = _neuralPosition[n1];
            var pos2 = _neuralPosition[n2];
            
            pe.Graphics.DrawLine(_synapsesPen, pos1.X, pos1.Y, pos2.X, pos2.Y);
            Point p = FindWhereToDrawSynapticWeight(pos1, pos2,rate);
            pe.Graphics.DrawString(string.Format("{0:0.00}", synapse.Weight),_fontForSynapticWeight, _neuralBrush,p.X,p.Y);

        }

        private void PaintAllNeurons(PaintEventArgs pe)
        {
            int left = 10;
            _neuralPosition.Clear();

            foreach (var layer in _nn.Layers)
            {
                int top = 0;
                foreach (var neuron in layer.Neurons)
                {
                    top += _verticalStep;
                    PaintNeuron(neuron, pe.Graphics, top, left);
                }

                left += _horizontalStep;
            }
        }

        private void PaintNeuron(Neuron neuron, Graphics g, int top, int left)
        {
            _neuralPosition.Add(neuron, new Point(left, top));

            Brush brush = _neuralBrush;

            if (neuron is TresholdNeuron)
            {
                brush = _treshHoldNeuralBrush;
            }


            if (neuron is OutputNeuron)
            {
                var n = neuron as OutputNeuron;
                brush = n.DesiredValue < 1.0 ? _outputNeuralBrush : _outputHighBruh;
                g.FillEllipse(brush, left, top, 15, 15);
                g.DrawString(n.ToString(), _fontForNeuralValue, brush, (float)left + 10, (float)top + 20);
            }

            else
            {
                g.FillEllipse(brush, left, top, 15, 15);
                g.DrawString(neuron.ToString(), _fontForNeuralValue, _neuralValueBrush, (float)left + 10, (float)top + 20);
            }
            
            // g.DrawString(neuron.Index.ToString(), _font, _neuralBrush, (float)left + 10, (float)top + 32);

            
        }
    }
}
