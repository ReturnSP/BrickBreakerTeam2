using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Media;

namespace BrickBreaker
{
    class UIPaint
    {
        static public void PaintTransRectangle(Graphics e, Color color, Rectangle rectangle, int transparencyPercent)
        {
            GraphicsPath rectanglePath = new GraphicsPath();
            Color transparentColor = Color.FromArgb(Convert.ToInt32(transparencyPercent), color);
            SolidBrush colorBrush = new SolidBrush(transparentColor);
            rectanglePath.AddRectangle(rectangle);
            e.FillPath(colorBrush, rectanglePath);
            rectanglePath.Dispose();
            colorBrush.Dispose();
        }

        static public void PaintText(Graphics e, string displayText, int size, Point position, Color color)
        {
            Font myFont = new Font("Chiller", size, FontStyle.Bold);
            SolidBrush brush = new SolidBrush(color);
            e.DrawString(displayText, myFont, brush, position.X, position.Y );
            brush.Dispose();
            myFont.Dispose();
        }
    }
}
