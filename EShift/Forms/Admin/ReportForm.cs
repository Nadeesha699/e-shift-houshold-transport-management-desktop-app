
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using EShift.Helpers;
using iTextSharp.text.pdf;

using PdfDocument = iTextSharp.text.Document;
using PdfPageSize = iTextSharp.text.PageSize;
using PdfFont = iTextSharp.text.Font;
using PdfParagraph = iTextSharp.text.Paragraph;
using PdfPhrase = iTextSharp.text.Phrase;
using PdfPTable = iTextSharp.text.pdf.PdfPTable;
using PdfPCell = iTextSharp.text.pdf.PdfPCell;
using PdfBaseColor = iTextSharp.text.BaseColor;
using PdfElement = iTextSharp.text.Element;

namespace EShift.Forms.Admin
{
    public partial class ReportsForm : Form
    {
        private DataTable reportTable = new DataTable();
        private readonly PrintDocument printDocument = new PrintDocument();
        private int printRowIndex = 0;

        public ReportsForm()
        {
            InitializeComponent();

            printDocument.PrintPage += PrintDocument_PrintPage;

            ConfigureReportGrid();
            LoadReportTypes();

            dtpStartDate.Value = DateTime.Today.AddMonths(-1);
            dtpEndDate.Value = DateTime.Today;

            dgvReports.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvReports.ReadOnly = true;
            dgvReports.AllowUserToAddRows = false;
            dgvReports.AllowUserToDeleteRows = false;
            dgvReports.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvReports.MultiSelect = false;

            lblReportTitle.Text = "Reports";
            lblRecordCount.Text = "Records: 0";
        }

        private void ConfigureReportGrid()
        {
            dgvReports.AutoGenerateColumns = true;
            dgvReports.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvReports.AllowUserToAddRows = false;
            dgvReports.ReadOnly = true;
            dgvReports.RowHeadersVisible = false;
        }

        private void LoadReportTypes()
        {
            cmbReportType.Items.Clear();

            cmbReportType.Items.Add("Job Summary by Status");
            cmbReportType.Items.Add("Jobs by Date Range");
            cmbReportType.Items.Add("Completed and Declined Jobs");
            cmbReportType.Items.Add("Customer Booking History");
            cmbReportType.Items.Add("Transport Resource Utilisation");

            cmbReportType.SelectedIndex = 0;
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            GenerateReport();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            GenerateReport();
        }

        private void GenerateReport()
        {
            if (cmbReportType.SelectedItem == null)
            {
                MessageHelper.ShowError("Please select a report type.");
                return;
            }

            if (dtpStartDate.Value.Date > dtpEndDate.Value.Date)
            {
                MessageHelper.ShowError("The start date cannot be later than the end date.");
                return;
            }

            string reportType = cmbReportType.SelectedItem.ToString();

            try
            {
                using (MySqlConnection connection =
                    DatabaseConnection.GetConnection())
                {
                    connection.Open();

                    using (MySqlCommand command =
                        new MySqlCommand(GetReportQuery(reportType), connection))
                    {
                        AddReportParameters(command, reportType);

                        using (MySqlDataAdapter adapter =
                            new MySqlDataAdapter(command))
                        {
                            reportTable = new DataTable();
                            adapter.Fill(reportTable);
                        }
                    }
                }

                dgvReports.DataSource = reportTable;

                lblReportTitle.Text = reportType;
                lblRecordCount.Text =
                    "Records: " + reportTable.Rows.Count;

                if (reportTable.Rows.Count == 0)
                {
                    MessageHelper.ShowError("No records were found for the selected report and date range.");
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError( "Unable to generate the report.\n\n" + ex.Message);
            }
        }

        private string GetReportQuery(string reportType)
        {
            switch (reportType)
            {
                case "Job Summary by Status":
                    return @"
                        SELECT
                            Status,
                            COUNT(*) AS TotalJobs
                        FROM Jobs
                        WHERE DATE(CreatedAt)
                            BETWEEN @StartDate AND @EndDate
                        GROUP BY Status
                        ORDER BY Status;";

                case "Jobs by Date Range":
                    return @"
                        SELECT
                            j.JobID,
                            j.JobNumber,
                            u.FullName AS CustomerName,
                            j.PickupLocation,
                            j.Destination,
                            j.RequestedDate,
                            j.Status,
                            j.CreatedAt
                        FROM Jobs j
                        LEFT JOIN Customers c
                            ON c.CustomerID = j.CustomerID
                        LEFT JOIN Users u
                            ON u.UserID = c.UserID
                        WHERE DATE(j.RequestedDate)
                            BETWEEN @StartDate AND @EndDate
                        ORDER BY j.RequestedDate DESC;";

                case "Completed and Declined Jobs":
                    return @"
                        SELECT
                            j.JobID,
                            j.JobNumber,
                            u.FullName AS CustomerName,
                            j.RequestedDate,
                            j.Status,
                            j.DeclineReason
                        FROM Jobs j
                        LEFT JOIN Customers c
                            ON c.CustomerID = j.CustomerID
                        LEFT JOIN Users u
                            ON u.UserID = c.UserID
                        WHERE j.Status IN ('COMPLETED', 'DECLINED')
                          AND DATE(j.RequestedDate)
                            BETWEEN @StartDate AND @EndDate
                        ORDER BY j.RequestedDate DESC;";

                case "Customer Booking History":
                    return @"
                        SELECT
                            c.CustomerID,
                            u.FullName AS CustomerName,
                            u.Email,
                            c.Phone,
                            j.JobID,
                            j.JobNumber,
                            j.PickupLocation,
                            j.Destination,
                            j.RequestedDate,
                            j.Status
                        FROM Customers c
                        INNER JOIN Users u
                            ON u.UserID = c.UserID
                        LEFT JOIN Jobs j
                            ON j.CustomerID = c.CustomerID
                           AND DATE(j.RequestedDate)
                            BETWEEN @StartDate AND @EndDate
                        ORDER BY u.FullName, j.RequestedDate DESC;";

                case "Transport Resource Utilisation":
                    return @"
                        SELECT
                            ta.AssignmentID,
                            ta.AssignedAt,
                            l.RegistrationNumber AS LorryRegistration,
                            l.Status AS LorryStatus,
                            d.FullName AS DriverName,
                            d.Status AS DriverStatus,
                            a.FullName AS AssistantName,
                            a.Status AS AssistantStatus,
                            ct.ContainerNumber,
                            ct.Status AS ContainerStatus
                        FROM TransportAssignments ta
                        LEFT JOIN Lorries l
                            ON l.LorryID = ta.LorryID
                        LEFT JOIN Drivers d
                            ON d.DriverID = ta.DriverID
                        LEFT JOIN Assistants a
                            ON a.AssistantID = ta.AssistantID
                        LEFT JOIN Containers ct
                            ON ct.ContainerID = ta.ContainerID
                        WHERE DATE(ta.AssignedAt)
                            BETWEEN @StartDate AND @EndDate
                        ORDER BY ta.AssignedAt DESC;";

                default:
                    throw new InvalidOperationException(
                        "The selected report type is not supported.");
            }
        }

        private void AddReportParameters(
            MySqlCommand command,
            string reportType)
        {
            // Date filters are used by all five report queries.
            command.Parameters.AddWithValue(
                "@StartDate", dtpStartDate.Value.Date);

            command.Parameters.AddWithValue(
                "@EndDate", dtpEndDate.Value.Date);
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            if (reportTable == null || reportTable.Columns.Count == 0)
            {
                MessageBox.Show(
                    "Please generate a report before exporting it.",
                    "Export PDF",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                saveDialog.Title = "Export Report to PDF";
                saveDialog.FileName =
                    "Report_" + DateTime.Now.ToString("yyyyMMdd_HHmmss")
                    + ".pdf";

                if (saveDialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    CreatePdfReport(saveDialog.FileName);

                    MessageHelper.ShowSuccess("The PDF report was exported successfully.");
                }
                catch (Exception ex)
                {
                    MessageHelper.ShowError("Unable to export the PDF report.\n\n" + ex.Message);
                }
            }
        }

        private void CreatePdfReport(string filePath)
        {
            using (FileStream stream = new FileStream(
                filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (PdfDocument document = new PdfDocument(
                    PdfPageSize.A4.Rotate(), 25f, 25f, 35f, 35f))
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, stream);
                    writer.PageEvent = new ReportPageNumberEvent();

                    document.Open();

                    PdfFont titleFont = new PdfFont(
                        PdfFont.FontFamily.HELVETICA,
                        18,
                        PdfFont.BOLD,
                        new PdfBaseColor(0, 70, 140));

                    PdfFont normalFont = new PdfFont(
                        PdfFont.FontFamily.HELVETICA,
                        9,
                        PdfFont.NORMAL);

                    PdfFont headerFont = new PdfFont(
                        PdfFont.FontFamily.HELVETICA,
                        8,
                        PdfFont.BOLD,
                        PdfBaseColor.WHITE);

                    PdfFont cellFont = new PdfFont(
                        PdfFont.FontFamily.HELVETICA,
                        8,
                        PdfFont.NORMAL);

                    PdfParagraph title = new PdfParagraph(
                        "e-Shift Transport Management System",
                        titleFont);

                    title.Alignment = PdfElement.ALIGN_CENTER;
                    title.SpacingAfter = 5f;
                    document.Add(title);

                    PdfParagraph reportHeading = new PdfParagraph(
                        lblReportTitle.Text,
                        new PdfFont(
                            PdfFont.FontFamily.HELVETICA,
                            13,
                            PdfFont.BOLD));

                    reportHeading.Alignment = PdfElement.ALIGN_CENTER;
                    reportHeading.SpacingAfter = 8f;
                    document.Add(reportHeading);

                    PdfParagraph dateRange = new PdfParagraph(
                        "Date Range: "
                        + dtpStartDate.Value.ToString("dd MMM yyyy")
                        + " - "
                        + dtpEndDate.Value.ToString("dd MMM yyyy"),
                        normalFont);

                    dateRange.Alignment = PdfElement.ALIGN_CENTER;
                    dateRange.SpacingAfter = 4f;
                    document.Add(dateRange);

                    PdfParagraph generatedDate = new PdfParagraph(
                        "Generated: " + DateTime.Now.ToString("dd MMM yyyy HH:mm"),
                        normalFont);

                    generatedDate.Alignment = PdfElement.ALIGN_CENTER;
                    generatedDate.SpacingAfter = 15f;
                    document.Add(generatedDate);

                    if (reportTable.Rows.Count == 0)
                    {
                        PdfParagraph emptyMessage = new PdfParagraph(
                            "No records were found for this report.",
                            normalFont);

                        emptyMessage.Alignment = PdfElement.ALIGN_CENTER;
                        document.Add(emptyMessage);
                    }
                    else
                    {
                        PdfPTable table =
                            new PdfPTable(reportTable.Columns.Count);

                        table.WidthPercentage = 100;
                        table.HeaderRows = 1;
                        table.SplitLate = false;
                        table.SplitRows = true;

                        float[] columnWidths =
                            new float[reportTable.Columns.Count];

                        for (int i = 0;
                             i < reportTable.Columns.Count;
                             i++)
                        {
                            columnWidths[i] = 1f;
                        }

                        table.SetWidths(columnWidths);

                        foreach (DataColumn column in reportTable.Columns)
                        {
                            PdfPCell headerCell = new PdfPCell(
                                new PdfPhrase(column.ColumnName, headerFont));

                            headerCell.BackgroundColor =
                                new PdfBaseColor(0, 70, 140);

                            headerCell.HorizontalAlignment =
                                PdfElement.ALIGN_CENTER;

                            headerCell.VerticalAlignment =
                                PdfElement.ALIGN_MIDDLE;

                            headerCell.Padding = 6f;
                            headerCell.BorderColor =
                                new PdfBaseColor(210, 210, 210);

                            table.AddCell(headerCell);
                        }

                        foreach (DataRow row in reportTable.Rows)
                        {
                            foreach (DataColumn column in reportTable.Columns)
                            {
                                string value = row[column] == DBNull.Value
                                    ? "-"
                                    : Convert.ToString(row[column]);

                                PdfPCell cell = new PdfPCell(
                                    new PdfPhrase(value, cellFont));

                                cell.Padding = 5f;
                                cell.VerticalAlignment =
                                    PdfElement.ALIGN_MIDDLE;

                                cell.BorderColor =
                                    new PdfBaseColor(210, 210, 210);

                                table.AddCell(cell);
                            }
                        }

                        document.Add(table);
                    }

                    document.Close();
                }
            }
        }


        private void PrintDocument_PrintPage(
            object sender,
            PrintPageEventArgs e)
        {
            int left = e.MarginBounds.Left;
            int top = e.MarginBounds.Top;
            int width = e.MarginBounds.Width;
            int y = top;

            using (Font titleFont = new Font(
                "Arial", 15, FontStyle.Bold))
            using (Font headerFont = new Font(
                "Arial", 8, FontStyle.Bold))
            using (Font cellFont = new Font(
                "Arial", 7, FontStyle.Regular))
            using (Pen borderPen = new Pen(Color.Gray))
            {
                e.Graphics.DrawString(
                    "e-Shift Transport Management System",
                    titleFont,
                    Brushes.Black,
                    left,
                    y);

                y += 30;

                e.Graphics.DrawString(
                    lblReportTitle.Text,
                    new Font("Arial", 11, FontStyle.Bold),
                    Brushes.Black,
                    left,
                    y);

                y += 25;

                e.Graphics.DrawString(
                    "Date Range: "
                    + dtpStartDate.Value.ToString("dd MMM yyyy")
                    + " - "
                    + dtpEndDate.Value.ToString("dd MMM yyyy"),
                    cellFont,
                    Brushes.Black,
                    left,
                    y);

                y += 25;

                int columnCount = reportTable.Columns.Count;

                if (columnCount == 0)
                {
                    e.HasMorePages = false;
                    return;
                }

                float columnWidth = (float)width / columnCount;
                int rowHeight = 35;

                // Draw the column headers on each printed page.
                for (int i = 0; i < columnCount; i++)
                {
                    RectangleF rect = new RectangleF(
                        left + i * columnWidth,
                        y,
                        columnWidth,
                        rowHeight);

                    e.Graphics.DrawRectangle(
                        borderPen,
                        rect.X,
                        rect.Y,
                        rect.Width,
                        rect.Height);

                    e.Graphics.DrawString(
                        reportTable.Columns[i].ColumnName,
                        headerFont,
                        Brushes.Black,
                        rect);
                }

                y += rowHeight;

                while (printRowIndex < reportTable.Rows.Count)
                {
                    if (y + rowHeight > e.MarginBounds.Bottom)
                    {
                        e.HasMorePages = true;
                        return;
                    }

                    DataRow row = reportTable.Rows[printRowIndex];

                    for (int i = 0; i < columnCount; i++)
                    {
                        RectangleF rect = new RectangleF(
                            left + i * columnWidth,
                            y,
                            columnWidth,
                            rowHeight);

                        e.Graphics.DrawRectangle(
                            borderPen,
                            rect.X,
                            rect.Y,
                            rect.Width,
                            rect.Height);

                        string value = row[i] == DBNull.Value
                            ? "-"
                            : Convert.ToString(row[i]);

                        e.Graphics.DrawString(
                            value,
                            cellFont,
                            Brushes.Black,
                            rect);
                    }

                    y += rowHeight;
                    printRowIndex++;
                }

                e.HasMorePages = false;
            }
        }

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            AdminDashboardForm form = new AdminDashboardForm();
            form.Show();
            this.Hide();
        }

        private void btn_manageUsers_Click(object sender, EventArgs e)
        {
            ManageUserForm form = new ManageUserForm();
            form.Show();
            this.Hide();

        }

        private void btn_manageCustomers_Click(object sender, EventArgs e)
        {
            ManageCustomerForm form = new ManageCustomerForm();
            form.Show();
            this.Hide();

        }

        private void btn_manageProducts_Click(object sender, EventArgs e)
        {
            ManageProductsForm form = new ManageProductsForm();
            form.Show();
            this.Hide();

        }

        private void btn_manageJobs_Click(object sender, EventArgs e)
        {
            ManageJobForm form = new ManageJobForm();
            form.Show();
            this.Hide();

        }

        private void btn_manageDrivers_Click(object sender, EventArgs e)
        {
            ManageDriverForm form = new ManageDriverForm();
            form.Show();
            this.Hide();

        }

        private void btn_manageAssistants_Click(object sender, EventArgs e)
        {
            ManageAssistantForm form = new ManageAssistantForm();
            form.Show();
            this.Hide();

        }

        private void btn_manageLorries_Click(object sender, EventArgs e)
        {
            ManageVehicleForm form = new ManageVehicleForm();
            form.Show();
            this.Hide();

        }

        private void btn_manageContainers_Click(object sender, EventArgs e)
        {
            ManageContainerForm form = new ManageContainerForm();
            form.Show();
            this.Hide();

        }

        private void btn_manageTransport_Click(object sender, EventArgs e)
        {
            ManageTransportForm form = new ManageTransportForm();
            form.Show();
            this.Hide();

        }

        private void btn_profile_Click(object sender, EventArgs e)
        {
            AdminProfile form = new AdminProfile();
            form.Show();
            this.Hide();

        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
           "Are you sure you want to log out?",
           "Confirm Logout",
           MessageBoxButtons.YesNo,
           MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            this.Hide();

            using (LoginForm login = new LoginForm())
            {
                login.ShowDialog();
            }

            this.Close();

        }
    }

    public class ReportPageNumberEvent : PdfPageEventHelper
    {
        public override void OnEndPage(
            PdfWriter writer,
            PdfDocument document)
        {
            PdfFont footerFont = new PdfFont(
                PdfFont.FontFamily.HELVETICA,
                8,
                PdfFont.ITALIC,
                PdfBaseColor.GRAY);

            PdfPhrase footer = new PdfPhrase(
                "e-Shift Report | Page " + writer.PageNumber,
                footerFont);

            iTextSharp.text.pdf.ColumnText.ShowTextAligned(
                writer.DirectContent,
                PdfElement.ALIGN_CENTER,
                footer,
                document.PageSize.Width / 2,
                document.PageSize.GetBottom(20),
                0);
        }
    }
}
