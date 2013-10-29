using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data;


namespace Hogar
{
    public class PrintUtility
    {
        readonly Graphics _graphics;

        readonly List<float> _columnWidth = new List<float>();
        readonly Font _cellFont = new Font("Arial", 10.0F);
        readonly Font _captionFont = new Font(new Font("Arial", 10.0F), FontStyle.Bold);
        readonly Font _defaultFont = new Font("Arial", 10.0F);
        float _rowHeight = 0.0F;

        float _cursorX = 0;
        float _cursorY = 0;

        Pen _defaultPen = new Pen(Color.Black);


        public enum Orientation
        {
            Vertical, Horizontal
        }

        public float RowHeight
        {
            get
            {
                return _rowHeight;
            }
            set
            {
                _rowHeight = value;
            }
        }


        public PrintUtility(Graphics graphics)
        {
            _graphics = graphics;
        }

        public void WriteLine(string text)
        {
            _graphics.DrawString(text, _defaultFont, Brushes.Black, new PointF(_cursorX, _cursorY));
            _cursorY += _graphics.MeasureString(text, _defaultFont).Height;
        }

        public void Write(string text)
        {
            _graphics.DrawString(text, _defaultFont, Brushes.Black, new PointF(_cursorX, _cursorY));
            _cursorX += _graphics.MeasureString(text, _defaultFont).Width;
        }

        public void MoveRight(float d)
        {
            _cursorX += d;
        }

        public void MoveDown(float d)
        {
            _cursorY += d;
        }

        public void SetY(float d)
        {
            _cursorY = d;
        }


        private void CalculateColumnWidth(DataTable _dataTable)
        {
            _columnWidth.Clear();

            if (null != _dataTable)
            {
                foreach (DataColumn dc in _dataTable.Columns)
                {
                    _columnWidth.Add(_graphics.MeasureString(dc.Caption, _captionFont).Width);
                }

                for (int column = 0; column < _dataTable.Columns.Count; ++column)
                {
                    for (int row = 0; row < _dataTable.Rows.Count; ++row)
                    {
                        string s = (string)_dataTable.Rows[row][column];
                        float width = _graphics.MeasureString(s, _cellFont).Width;

                        if (_graphics.MeasureString(s, _cellFont).Height > RowHeight)
                        {
                            RowHeight = _graphics.MeasureString(s, _cellFont).Height;
                        }

                        if (_columnWidth[column] < width)
                        {
                            _columnWidth[column] = width;
                        }
                    }
                }
            }
        }

        float GetGridWidth()
        {

            float w = 0;

            foreach (float f in _columnWidth)
            {
                w += f;
            }

            return w;
        }

        float GetGridHeight(DataTable _dataTable)
        {
            return (_dataTable.Rows.Count + 1) * RowHeight;

        }

        void PrintGrid(DataTable _dataTable, Point topLeft)
        {
            float width = GetGridWidth();
            float height = GetGridHeight(_dataTable);

            Pen pen = new Pen(Color.Black);

            _graphics.DrawRectangle(pen, topLeft.X, topLeft.Y, width, height);

            // Paint Vertical Lines

            float x = topLeft.X;
            for (int col = 0; col < _dataTable.Columns.Count; ++col)
            {
                x += _columnWidth[col];
                _graphics.DrawLine(pen, x, topLeft.Y, x, topLeft.Y + GetGridHeight(_dataTable));
            }

            // Paint Horizontal Lines

            float y = topLeft.Y;

            for (int row = 0; row < _dataTable.Rows.Count; ++row)
            {
                y += RowHeight;

                _graphics.DrawLine(pen, topLeft.X, y, topLeft.X + GetGridWidth(), y);
            }
        }

        public PointF PrintDataTable(DataTable _dataTable, Orientation orientation)
        {
            return PrintDataTable(_dataTable, new Point((int)_cursorX, (int)_cursorY), orientation);
        }

        public PointF PrintDataTable(DataTable _dataTable, Point topLeft, Orientation orientation)
        {
            
            float x = topLeft.X;
            float y = topLeft.Y;

            CalculateColumnWidth(_dataTable);

            PrintGrid(_dataTable, topLeft);

            for (int column = 0; column < _dataTable.Columns.Count; ++column)
            {
                _graphics.DrawString(_dataTable.Columns[column].Caption, _captionFont, Brushes.Black, new PointF(x, y));
                x += _columnWidth[column];
            }

            y += RowHeight;

            for (int row = 0; row < _dataTable.Rows.Count; ++row)
            {
                x = topLeft.X;

                for (int column = 0; column < _dataTable.Columns.Count; ++column)
                {
                    string s = (string)_dataTable.Rows[row][column];

                    _graphics.DrawString(s, _cellFont, Brushes.Black, new PointF(x, y));
                    x += _columnWidth[column];

                }

                y += RowHeight;
            }

            if (orientation == Orientation.Vertical)
            {
                _cursorX = 0;
                _cursorY = topLeft.Y + GetGridHeight(_dataTable);
            }
            else if (orientation == Orientation.Horizontal)
            {
                _cursorX = topLeft.X + GetGridWidth();
                _cursorY = topLeft.Y;
            }


            return new PointF(topLeft.X + GetGridWidth(), topLeft.Y + GetGridHeight(_dataTable));

        }
    }
}
