namespace UI
{
    partial class MainForm
    {
        private Button btnAdmin;
        private Button btnCashier;

        private void InitializeComponent()
        {
            btnAdmin = new Button();
            btnCashier = new Button();

            SuspendLayout();

            // btnAdmin
            btnAdmin.Text = "Admin";
            btnAdmin.Location = new System.Drawing.Point(50, 30);
            btnAdmin.Size = new System.Drawing.Size(100, 40);
            btnAdmin.Click += new EventHandler(btnAdmin_Click);

            // btnCashier
            btnCashier.Text = "Cashier";
            btnCashier.Location = new System.Drawing.Point(200, 30);
            btnCashier.Size = new System.Drawing.Size(100, 40);
            btnCashier.Click += new EventHandler(btnCashier_Click);

            // MainForm
            ClientSize = new System.Drawing.Size(400, 120);
            Controls.Add(btnAdmin);
            Controls.Add(btnCashier);
            Text = "Opening Screen";

            ResumeLayout(false);
        }
    }
}