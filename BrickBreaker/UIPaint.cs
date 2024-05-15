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

        static public void PaintTextTrans(Graphics e, string displayText, int size, Point position, Color color, int transparencyPercent)
        {
            Font myFont = new Font("Chiller", size, FontStyle.Bold);
            Color transparentColor = Color.FromArgb(Convert.ToInt32(transparencyPercent), color);
            SolidBrush brush = new SolidBrush(transparentColor);
            e.DrawString(displayText, myFont, brush, position.X, position.Y);
            brush.Dispose();
            myFont.Dispose();
        }

        static public void PaintTextRotate(Graphics e, string displayText, int size, Point position, Color color, double angle, Point offset)
        {
            Font myFont = new Font("Chiller", size, FontStyle.Bold);
            GraphicsPath path = new GraphicsPath();
            SolidBrush brush = new SolidBrush(color);
            path.AddString(displayText, myFont.FontFamily, (int)myFont.Style, myFont.Size, new Point(position.X - offset.X / 2, position.Y - offset.Y / 2), StringFormat.GenericDefault);

            Matrix matrix = new Matrix();
            matrix.RotateAt((float)angle, position);
            //matrix.Translate(-position.X, -position.Y);
            // Transform the GraphicsPath
            path.Transform(matrix);
            e.FillPath(brush, path);

            matrix.Dispose();
            path.Dispose();
            brush.Dispose();
            myFont.Dispose();
        }
    }
}
