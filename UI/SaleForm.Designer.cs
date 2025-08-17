namespace UI
{
    partial class SalesForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridView1;
        private TextBox txtBarcode;
        private TextBox txtProductId;
        private TextBox txtQuantity;
        private TextBox txtTotal;
        private CheckBox chkClub;
        private DateTimePicker dtStart;
        private DateTimePicker dtEnd;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnFilter;
        private Button btnShowByCode;
        private Button btnShowAll;
        private Label labelCode;
        private Label labelProductCode;
        private Label labelStockQuantity;
        private Label labelPrice;
        private Label labelStartDate;
        private Label labelEndDate;

        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            txtBarcode = new TextBox();
            txtProductId = new TextBox();
            txtQuantity = new TextBox();
            txtTotal = new TextBox();
            chkClub = new CheckBox();
            dtStart = new DateTimePicker();
            dtEnd = new DateTimePicker();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnFilter = new Button();
            btnShowByCode = new Button();
            btnShowAll = new Button();
            labelCode = new Label();
            labelProductCode = new Label();
            labelStockQuantity = new Label();
            labelPrice = new Label();
            labelStartDate = new Label();
            labelEndDate = new Label();

            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();

            // dataGridView1
            dataGridView1.ColumnHeadersHeight = 29;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(600, 200);
            dataGridView1.TabIndex = 0;

            // txtBarcode
            txtBarcode.Location = new Point(12, 246);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(100, 27);
            txtBarcode.TabIndex = 1;

            // txtProductId
            txtProductId.Location = new Point(118, 246);
            txtProductId.Name = "txtProductId";
            txtProductId.Size = new Size(100, 27);
            txtProductId.TabIndex = 2;

            // txtQuantity
            txtQuantity.Location = new Point(227, 246);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(100, 27);
            txtQuantity.TabIndex = 3;

            // txtTotal
            txtTotal.Location = new Point(343, 246);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(100, 27);
            txtTotal.TabIndex = 4;

            // chkClub
            chkClub.Location = new Point(471, 248);
            chkClub.Name = "chkClub";
            chkClub.Size = new Size(141, 24);
            chkClub.TabIndex = 5;
            chkClub.Text = "Club Members";

            // dtStart
            dtStart.Location = new Point(12, 315);
            dtStart.Name = "dtStart";
            dtStart.Size = new Size(200, 27);
            dtStart.TabIndex = 6;

            // dtEnd
            dtEnd.Location = new Point(227, 315);
            dtEnd.Name = "dtEnd";
            dtEnd.Size = new Size(200, 27);
            dtEnd.TabIndex = 7;

            // btnAdd
            btnAdd.Location = new Point(28, 388);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 32);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Add";
            btnAdd.Click += btnAdd_Click;

            // btnUpdate
            btnUpdate.Location = new Point(109, 389);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 32);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Update";
            btnUpdate.Click += btnUpdate_Click;

            // btnDelete
            btnDelete.Location = new Point(190, 388);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 32);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete";
            btnDelete.Click += btnDelete_Click;

            // btnFilter
            btnFilter.Location = new Point(271, 391);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(192, 29);
            btnFilter.TabIndex = 11;
            btnFilter.Text = "Filter Active Promotions";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;

            // btnShowByCode
            btnShowByCode.Location = new Point(469, 391);
            btnShowByCode.Name = "btnShowByCode";
            btnShowByCode.Size = new Size(137, 29);
            btnShowByCode.TabIndex = 12;
            btnShowByCode.Text = "Show Promotion by Code";
            btnShowByCode.UseVisualStyleBackColor = true;
            btnShowByCode.Click += button1_Click;

            // btnShowAll
            btnShowAll.Location = new Point(612, 391);
            btnShowAll.Name = "btnShowAll";
            btnShowAll.Size = new Size(176, 29);
            btnShowAll.TabIndex = 13;
            btnShowAll.Text = "Show All Promotions";
            btnShowAll.UseVisualStyleBackColor = true;
            btnShowAll.Click += button2_Click;

            // labelCode
            labelCode.AutoSize = true;
            labelCode.Location = new Point(37, 223);
            labelCode.Name = "labelCode";
            labelCode.Size = new Size(30, 20);
            labelCode.TabIndex = 14;
            labelCode.Text = "Code";

            // labelProductCode
            labelProductCode.AutoSize = true;
            labelProductCode.Location = new Point(128, 224);
            labelProductCode.Name = "labelProductCode";
            labelProductCode.Size = new Size(65, 20);
            labelProductCode.TabIndex = 15;
            labelProductCode.Text = "Product Code";

            // labelStockQuantity
            labelStockQuantity.AutoSize = true;
            labelStockQuantity.Location = new Point(240, 224);
            labelStockQuantity.Name = "labelStockQuantity";
            labelStockQuantity.Size = new Size(87, 20);
            labelStockQuantity.TabIndex = 16;
            labelStockQuantity.Text = "Stock Quantity";

            // labelPrice
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(367, 223);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(41, 20);
            labelPrice.TabIndex = 17;
            labelPrice.Text = "Price";

            // labelStartDate
            labelStartDate.AutoSize = true;
            labelStartDate.Location = new Point(37, 292);
            labelStartDate.Name = "labelStartDate";
            labelStartDate.Size = new Size(139, 20);
            labelStartDate.TabIndex = 18;
            labelStartDate.Text = "Promotion Start Date";

            // labelEndDate
            labelEndDate.AutoSize = true;
            labelEndDate.Location = new Point(262, 292);
            labelEndDate.Name = "labelEndDate";
            labelEndDate.Size = new Size(123, 20);
            labelEndDate.TabIndex = 19;
            labelEndDate.Text = "Promotion End Date";

            // SalesForm
            ClientSize = new Size(789, 420);
            Controls.Add(btnShowAll);
            Controls.Add(btnShowByCode);
            Controls.Add(labelEndDate);
            Controls.Add(labelStartDate);
            Controls.Add(labelPrice);
            Controls.Add(labelStockQuantity);
            Controls.Add(labelProductCode);
            Controls.Add(labelCode);
            Controls.Add(btnFilter);
            Controls.Add(dataGridView1);
            Controls.Add(txtBarcode);
            Controls.Add(txtProductId);
            Controls.Add(txtQuantity);
            Controls.Add(txtTotal);
            Controls.Add(chkClub);
            Controls.Add(dtStart);
            Controls.Add(dtEnd);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);

            Name = "SalesForm";
            Text = "Promotion Management";

            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadData(DateTime.Now);
        }
    }
}