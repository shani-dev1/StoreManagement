using BlApi;
using BO;

namespace UI
{
    public partial class SalesForm : Form
    {
        private readonly IBl bl = Factory.Get();

        public SalesForm()
        {
            InitializeComponent();
            ModernStyleHelper.ApplyModernStyle(this);
            LoadData();
        }

        private void LoadData(DateTime? endDateFilter = null)
        {
            var sales = bl.sale.ReadAll();

            if (endDateFilter.HasValue)
            {
                sales = sales.Where(s => s.EndSale >= endDateFilter.Value).ToList();
            }

            dataGridView1.DataSource = sales
                .Select(s => new
                {
                    s.BarcodeSale,
                    s.ProductId,
                    s.RequiredItems,
                    s.TotalPrice,
                    s.IsCustomersClub,
                    s.BeginingSale,
                    s.EndSale
                })
                .ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                bl.sale.Create(new Sale(
                    0,
                    int.Parse(txtProductId.Text),
                    int.Parse(txtQuantity.Text),
                    int.Parse(txtTotal.Text),
                    chkClub.Checked,
                    dtStart.Value,
                    dtEnd.Value));

                LoadData();
            }
            catch (BLCodeExistException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(txtBarcode.Text);

                bl.sale.Update(new Sale(
                    id,
                    int.Parse(txtProductId.Text),
                    int.Parse(txtQuantity.Text),
                    int.Parse(txtTotal.Text),
                    chkClub.Checked,
                    dtStart.Value,
                    dtEnd.Value));

                LoadData();
            }
            catch (BLIdNotExistException ex)
            {
                MessageBox.Show("Sale does not exist: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating sale: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtBarcode.Text, out int barcode))
            {
                try
                {
                    bl.sale.Delete(barcode);
                    LoadData();
                    MessageBox.Show("Sale deleted successfully.");
                }
                catch (BLIdNotExistException ex)
                {
                    MessageBox.Show("Cannot delete sale that does not exist: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting sale: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid code.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int saleCode = int.TryParse(txtBarcode.Text, out int code) ? code : -1;

            try
            {
                var sale = bl.sale.Read(saleCode);
                dataGridView1.DataSource = new System.Collections.Generic.List<BO.Sale> { sale };
            }
            catch (BLIdNotExistException ex)
            {
                MessageBox.Show(ex.Message);
                dataGridView1.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
