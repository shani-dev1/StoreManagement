namespace UI
{
    partial class CustomersForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridView1;
        private TextBox txtId;
        private TextBox txtName;
        private TextBox txtPhone;
        private TextBox txtAddress;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button buttonFilter;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
        private Button button2;

        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            txtId = new TextBox();
            txtName = new TextBox();
            txtPhone = new TextBox();
            txtAddress = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            buttonFilter = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            button2 = new Button();

            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();

            // dataGridView1
            dataGridView1.ColumnHeadersHeight = 29;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(460, 200);
            dataGridView1.TabIndex = 0;

            // txtId
            txtId.Location = new Point(12, 254);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 27);
            txtId.TabIndex = 1;

            // txtName
            txtName.Location = new Point(150, 254);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 27);
            txtName.TabIndex = 2;

            // txtPhone
            txtPhone.Location = new Point(289, 254);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(100, 27);
            txtPhone.TabIndex = 3;

            // txtAddress
            txtAddress.Location = new Point(12, 309);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(100, 27);
            txtAddress.TabIndex = 4;

            // btnAdd
            btnAdd.Location = new Point(12, 383);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 34);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Add";
            btnAdd.Click += btnAdd_Click;

            // btnUpdate
            btnUpdate.Location = new Point(93, 384);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 34);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Update";
            btnUpdate.Click += btnUpdate_Click;

            // btnDelete
            btnDelete.Location = new Point(165, 383);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 34);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Delete";
            btnDelete.Click += btnDelete_Click;

            // buttonFilter
            buttonFilter.Location = new Point(246, 386);
            buttonFilter.Name = "buttonFilter";
            buttonFilter.Size = new Size(131, 29);
            buttonFilter.TabIndex = 8;
            buttonFilter.Text = "Filter by Customer Name";
            buttonFilter.UseVisualStyleBackColor = true;
            buttonFilter.Click += buttonFilter_Click;

            // label1
            label1.AutoSize = true;
            label1.Location = new Point(30, 231);
            label1.Name = "label1";
            label1.Size = new Size(34, 20);
            label1.TabIndex = 9;
            label1.Text = "ID";

            // label2
            label2.AutoSize = true;
            label2.Location = new Point(21, 286);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 10;
            label2.Text = "Address";

            // label3
            label3.AutoSize = true;
            label3.Location = new Point(308, 231);
            label3.Name = "label3";
            label3.Size = new Size(44, 20);
            label3.TabIndex = 11;
            label3.Text = "Phone";

            // label4
            label4.AutoSize = true;
            label4.Location = new Point(165, 231);
            label4.Name = "label4";
            label4.Size = new Size(35, 20);
            label4.TabIndex = 12;
            label4.Text = "Name";

            // button1
            button1.Location = new Point(383, 387);
            button1.Name = "button1";
            button1.Size = new Size(154, 29);
            button1.TabIndex = 13;
            button1.Text = "Show All Customers";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;

            // button2
            button2.Location = new Point(543, 386);
            button2.Name = "button2";
            button2.Size = new Size(137, 29);
            button2.TabIndex = 14;
            button2.Text = "Show Customer by ID";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;

            // CustomersForm
            ClientSize = new Size(729, 442);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonFilter);
            Controls.Add(dataGridView1);
            Controls.Add(txtId);
            Controls.Add(txtName);
            Controls.Add(txtPhone);
            Controls.Add(txtAddress);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Name = "CustomersForm";
            Text = "Customer Management";

            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}