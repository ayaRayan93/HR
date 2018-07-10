using DevExpress.XtraGrid;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HR
{
    public partial class EmployeeReport : Form
    {
        GridControl gridControl;
        string devexpress = "";
        public EmployeeReport(GridControl gridControl,string titel)
        {
            try
            {
                InitializeComponent();
                this.gridControl = gridControl;
                this.devexpress = titel;
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void EmployeeReport_Load(object sender, EventArgs e)
        {
            try
            {
                PrintableComponentLink printableComponentLink = new PrintableComponentLink();

                printableComponentLink.Component = gridControl;
                printableComponentLink.RightToLeftLayout = true;
                printableComponentLink.Landscape = true;
                printableComponentLink.Margins = new System.Drawing.Printing.Margins(50, 50, 50, 50);
                printingSystem1.Links.Add(printableComponentLink);
                printableComponentLink.CreateReportHeaderArea += PrintableComponentLink_CreateReportHeaderArea;
                printableComponentLink.CreateMarginalFooterArea += PrintableComponentLink_CreateMarginalFooterArea;
                printableComponentLink.CreateDocument();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void PrintableComponentLink_CreateMarginalFooterArea(object sender, CreateAreaEventArgs e)
        {
            // Declare bricks.
            PageInfoBrick pageInfoBrick;

            // Specify required settings for the brick graphics.
            BrickGraphics brickGraphics = e.Graph;
            brickGraphics.BackColor = Color.White;
            brickGraphics.Font = new Font("Neo Sans Arabic", 10);

            // Set the rectangle for a page info brick. 
            RectangleF r = RectangleF.Empty;
            r.Height = 20;

            // Display the PageInfoBrick containing the page number among total pages. The page number
            // is displayed in the right part of the MarginalHeader section.
            pageInfoBrick = brickGraphics.DrawPageInfo(PageInfo.NumberOfTotal, "Page {0} of {1}", Color.Black, r, BorderSide.None);
            pageInfoBrick.Alignment = BrickAlignment.Far;
        }

        private void PrintableComponentLink_CreateReportHeaderArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e)
        {
            // Specify required settings for the brick graphics.
            BrickGraphics brickGraphics = e.Graph;
            brickGraphics.BackColor = Color.White;
            brickGraphics.Font = new Font("Neo Sans Arabic", 10);

            // Declare bricks.
            PageInfoBrick pageInfoBrick;
            PageImageBrick pageImageBrick;

            // Define the image to display.
            Image pageImage = HR.Properties.Resources.Logo3;

            // Display the PageImageBrick containing the DevExpress logo.
            pageImageBrick = brickGraphics.DrawPageImage(pageImage, new Rectangle(810, 0, 150, 150), BorderSide.None, Color.Transparent);
            pageImageBrick.Alignment = BrickAlignment.Far;

            // Display the PageInfoBrick containing date-time information. Date-time information is displayed
            // in the left part of the MarginalHeader section using the FullDateTimePattern.
            //{0:F}
            pageInfoBrick = brickGraphics.DrawPageInfo(PageInfo.DateTime, "{0:MM/dd/yyyy hh:mm tt}", Color.Black, new Rectangle(840, 160, 120, 50), BorderSide.None);
            pageInfoBrick.Alignment = BrickAlignment.Far;


            // Declare text strings.
       
            // Specify required settings for the brick graphics.
            BrickGraphics brickGraphics2 = e.Graph;
            brickGraphics2.BackColor = Color.White;
            brickGraphics2.Font = new Font("Neo Sans Arabic", 14, FontStyle.Bold);

            // Display the DevExpress text string.
            SizeF size = brickGraphics2.MeasureString(devexpress);
            pageInfoBrick = brickGraphics2.DrawPageInfo(PageInfo.None, devexpress, Color.Black, new RectangleF(new PointF(440, 50), size), BorderSide.None);
            pageInfoBrick.Alignment = BrickAlignment.Center;
        }

    }
}
