using System.Drawing;
using System.Windows.Forms;

namespace MscrmTools.EnvironmentVariableManager.AppCode
{
    /// <summary>
    /// Code from https://csharpuideveloper.blogspot.com/2010/09/how-to-insert-image-with-text-in-one.html
    /// </summary>
    public class TextAndImageCell : DataGridViewTextBoxCell
    {
        private Size imageSize;
        private Image imageValue;

        public bool DisplayWarningImage { get; set; }

        public Image Image
        {
            get
            {
                if (this.OwningColumn == null ||
            this.OwningTextAndImageColumn == null)
                {
                    return imageValue;
                }
                else if (this.imageValue != null)
                {
                    return this.imageValue;
                }
                else
                {
                    return this.OwningTextAndImageColumn.Image;
                }
            }
            set
            {
                if (this.imageValue != value)
                {
                    this.imageValue = value;
                    this.imageSize = value.Size;

                    Padding inheritedPadding = this.InheritedStyle.Padding;
                    this.Style.Padding = new Padding(imageSize.Width,
                    inheritedPadding.Top, inheritedPadding.Right,
                    inheritedPadding.Bottom);
                }
            }
        }

        private TextAndImageColumn OwningTextAndImageColumn
        {
            get { return this.OwningColumn as TextAndImageColumn; }
        }

        public override object Clone()
        {
            TextAndImageCell c = base.Clone() as TextAndImageCell;
            c.imageValue = this.imageValue;
            c.imageSize = this.imageSize;
            return c;
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds,
                                        Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState,
                                        object value, object formattedValue, string errorText,
                                        DataGridViewCellStyle cellStyle,
                                        DataGridViewAdvancedBorderStyle advancedBorderStyle,
                                        DataGridViewPaintParts paintParts)
        {
            // Paint the base content
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle,
                    advancedBorderStyle, paintParts);

            if (DisplayWarningImage)
            {
                // Draw the image clipped to the cell.
                System.Drawing.Drawing2D.GraphicsContainer container =
                graphics.BeginContainer();

                graphics.SetClip(cellBounds);
                graphics.DrawImage(Properties.Resources.warning16, new Rectangle(cellBounds.X + cellBounds.Width - 20, cellBounds.Y + 2, 16, 16), new Rectangle(0, 0, 16, 16), GraphicsUnit.Pixel);

                graphics.EndContainer(container);
            }
        }
    }
}