namespace UI
{
    partial class AdminPanel
    {
        private Button btnCustomers;
        private Button btnProducts;
        private Button btnDeals;

        private void InitializeComponent()
        {
            this.btnCustomers = new Button();
            this.btnProducts = new Button();
            this.btnDeals = new Button();
            this.SuspendLayout();

            // 
            // btnCustomers
            // 
            this.btnCustomers.Text = "Customers";
            this.btnCustomers.Location = new System.Drawing.Point(30, 30);
            this.btnCustomers.Size = new System.Drawing.Size(100, 40);
            this.btnCustomers.Click += new EventHandler(this.btnCustomers_Click);

            // 
            // btnProducts
            // 
            this.btnProducts.Text = "Products";
            this.btnProducts.Location = new System.Drawing.Point(150, 30);
            this.btnProducts.Size = new System.Drawing.Size(100, 40);
            this.btnProducts.Click += new EventHandler(this.btnProducts_Click);

            // 
            // btnDeals
            // 
            this.btnDeals.Text = "Deals";
            this.btnDeals.Location = new System.Drawing.Point(270, 30);
            this.btnDeals.Size = new System.Drawing.Size(100, 40);
            this.btnDeals.Click += new EventHandler(this.btnDeals_Click);

            // 
            // AdminPanel
            // 
            this.ClientSize = new System.Drawing.Size(420, 110);
            this.Controls.Add(this.btnCustomers);
            this.Controls.Add(this.btnProducts);
            this.Controls.Add(this.btnDeals);
            this.Text = "Main Admin Panel";
            this.ResumeLayout(false);
        }
    }
}
