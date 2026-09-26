using BOMProject.Business.Contracts;
using BOMProject.Entities;
using System.Diagnostics;

namespace bomApp
{
    public partial class BOMProject : Form
    {
        private Material? _selectedMaterial;
        private readonly IMaterialService _materialService;
        private readonly IExcelImportService _excelImportService;
        private readonly IImportHistoryService _importHistoryService;
        private string? _selectedImagePath;
        private readonly IActivityLogService _activityLogService;
        private bool _isLogHistoryOpen = false;

        public BOMProject(IExcelImportService excelImportService,
            IMaterialService materialService,
            IImportHistoryService importHistoryService,
            IActivityLogService activityLogService)
        {
            InitializeComponent();
            _excelImportService = excelImportService;
            _materialService = materialService;
            _importHistoryService = importHistoryService;
            _activityLogService = activityLogService;
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.None;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.None;

                column.Width = 140;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _materialService.DeleteZeroQuantityMaterials();

            var materials = _materialService.GetAllMaterials();

            if (materials.Count > 0)
            {
                dataGridView1.DataSource = materials;
                HideGridColumns();
            }
            else
            {
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();

                dataGridView1.Columns.Add("Message", "");

                dataGridView1.Rows.Add("Listelenecek ürün bulunamadı.");

                dataGridView1.Columns[0].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
            }

            // Basic DataGridView settings
            dataGridView1.BackgroundColor =
                Color.FromArgb(245, 247, 250);

            dataGridView1.BorderStyle = BorderStyle.None;

            dataGridView1.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dataGridView1.GridColor =
                Color.FromArgb(230, 235, 240);

            // row settings
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(35, 47, 62);

            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                Color.FromArgb(35, 47, 62);

            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionForeColor =
                Color.White;

            // row settings
            dataGridView1.DefaultCellStyle.Font =
                new Font("Segoe UI", 9.5F);

            dataGridView1.DefaultCellStyle.BackColor =
                Color.White;

            dataGridView1.DefaultCellStyle.ForeColor =
                Color.FromArgb(45, 55, 65);

            dataGridView1.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dataGridView1.DefaultCellStyle.Padding =
                new Padding(5, 0, 5, 0);


            // row settings for alternating rows
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(242, 246, 250);

            // row settings for alternating rows
            dataGridView1.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(210, 230, 250);

            dataGridView1.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(25, 45, 65);

            dataGridView1.AlternatingRowsDefaultCellStyle.SelectionBackColor =
                Color.FromArgb(210, 230, 250);

            dataGridView1.AlternatingRowsDefaultCellStyle.SelectionForeColor =
                Color.FromArgb(25, 45, 65);

            cmbSearchField.SelectedIndex = 0;
        }

        private void btnExcelSelect_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
                openFileDialog.Title = "Bom Excel Dosyasını Seçin";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var result = _excelImportService.ImportExcelData(openFileDialog.FileName);

                        ShowTemporaryLog(
                            $"{result.ProcessedMaterialCount} kayıt işlendi.");

                        foreach (var warning in result.Warnings)
                        {
                            ShowTemporaryLog(warning);
                        }

                        MessageBox.Show(
                            "Excel verileri başarıyla işlendi.",
                            "Başarılı",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        ShowTemporaryLog(
                            $"{DateTime.Now:dd.MM.yyyy HH:mm:ss} - HATA: {ex.Message}");
                        MessageBox.Show(
                            $"Excel verileri işlenirken bir hata oluştu:\n{ex.Message}",
                            "Hata",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _materialService.GetAllMaterials();
            HideGridColumns();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtMaterial.Text;
            string searchField = cmbSearchField.SelectedItem?.ToString() ?? "";
            dataGridView1.DataSource =
                _materialService.SearchMaterials(searchText, searchField);
            HideGridColumns();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            _selectedMaterial =
                dataGridView1.Rows[e.RowIndex].DataBoundItem as Material;

            if (_selectedMaterial == null)
                return;

            // Ürün bilgileri
            txtQuantity.Text = _selectedMaterial.Quantity.ToString();
            txtComment.Text = _selectedMaterial.Comment;
            txtFootprint.Text = _selectedMaterial.Footprint;
            txtValue.Text = _selectedMaterial.Value;

            // Konum
            lblLocation.Text = _selectedMaterial.Location;

            // Ürün görseli
            pictureBox1.ImageLocation =
                !string.IsNullOrEmpty(_selectedMaterial.ImagePath)
                && File.Exists(_selectedMaterial.ImagePath)
                    ? _selectedMaterial.ImagePath
                    : null;
        }

        private void btnFilePicture_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Title = "Resim Dosyasını Seçin";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.ImageLocation = openFileDialog.FileName;
                    _selectedImagePath = openFileDialog.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Resim yüklenirken bir hata oluştu:\n{ex.Message}",
                        "Hata",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void HideGridColumns()
        {
            dataGridView1.Columns["Id"]!.Visible = false;
            dataGridView1.Columns["Location"]!.Visible = false;
            dataGridView1.Columns["ImagePath"]!.Visible = false;
        }

        private void ClearForm()
        {
            txtComment.Clear();
            txtFootprint.Clear();
            txtLocation.Clear();
            txtQuantity.Clear();
            txtValue.Clear();

            _selectedMaterial = null;
            _selectedImagePath = null;

            lblLocation.Text = " Ürün Seçilmedi! ";

            pictureBox1.ImageLocation =
                Path.Combine(Application.StartupPath, "Images", "No products.png");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedMaterial == null)
            {
                MessageBox.Show("Önce bir malzeme seçiniz.");
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity < 0)
            {
                MessageBox.Show(
                    "Miktar geçerli bir sayı olmalıdır.",
                    "Geçersiz Miktar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            _selectedMaterial.Quantity = quantity;
            _selectedMaterial.Comment = txtComment.Text;
            _selectedMaterial.Footprint = txtFootprint.Text;
            _selectedMaterial.Value = txtValue.Text;

            _selectedMaterial.Location = txtLocation.Text;
            if (!string.IsNullOrWhiteSpace(_selectedImagePath))
            {
                var result = MessageBox.Show(
                    "Mevcut ürün resmi silinecek ve yeni resim ile değiştirilecektir. Devam etmek istiyor musunuz?",
                    "Resim Değiştirme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                    return;

                string? oldImagePath = _selectedMaterial.ImagePath;

                // Önce yeni resmi güvenli şekilde kaydet
                string newImagePath =
                    _materialService.SaveMaterialImage(_selectedImagePath);

                // Yeni resim başarıyla kaydedildiyse eski resmi sil
                _materialService.DeleteMaterialImage(oldImagePath);

                // Yeni yolu ürüne ata
                _selectedMaterial.ImagePath = newImagePath;
            }

            _materialService.UpdateMaterial(_selectedMaterial);
            dataGridView1.DataSource = _materialService.GetAllMaterials();
            HideGridColumns();
            _activityLogService.AddActivityLog(
                $"Malzeme güncellendi. Konum: {_selectedMaterial.Location}");
            ShowTemporaryLog(
                $"Malzeme güncellendi. Konum: {_selectedMaterial.Location}");
            MessageBox.Show("Malzeme başarıyla güncellendi.");

            ClearForm();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_selectedMaterial == null)
            {
                MessageBox.Show("Önce bir malzeme seçiniz.");
                return;
            }

            if (!int.TryParse(txtDecreaseQuantity.Text, out int quantityToDecrease))
            {
                MessageBox.Show("Geçerli bir miktar giriniz.");
                return;
            }

            try
            {
                int oldQuantity = _selectedMaterial.Quantity;

                _materialService.DecreaseQuantity(
                    _selectedMaterial.Id,
                    quantityToDecrease);

                string logMessage;

                if (oldQuantity - quantityToDecrease == 0)
                {
                    logMessage =
                        $"{_selectedMaterial.Comment} ürünü kaldırıldı. " +
                        $"Sebep: Quantity 0'a düştü.";
                }
                else
                {
                    logMessage =
                        $"{_selectedMaterial.Comment} ürününün miktarı azaltıldı. " +
                        $"{oldQuantity} → {oldQuantity - quantityToDecrease}";
                }

                _activityLogService.AddActivityLog(logMessage);

                ShowTemporaryLog(logMessage);
                MessageBox.Show("Ürün miktarı başarıyla azaltıldı.");

                dataGridView1.DataSource = _materialService.GetAllMaterials();
                HideGridColumns();

                ClearForm();
                txtDecreaseQuantity.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedMaterial == null)
            {
                MessageBox.Show("Önce silmek istediğiniz ürünü seçiniz.");
                return;
            }

            var result = MessageBox.Show(
                "Seçili ürünü silmek istediğinize emin misiniz?",
                "Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            string deletedMaterial = _selectedMaterial.Comment ?? "İsimsiz ürün";

            _materialService.DeleteMaterial(_selectedMaterial.Id);

            string logMessage =
                $"{deletedMaterial} ürünü manuel olarak silindi.";

            _activityLogService.AddActivityLog(logMessage);

            ShowTemporaryLog(logMessage);

            dataGridView1.DataSource = _materialService.GetAllMaterials();
            HideGridColumns();

            ClearForm();

            MessageBox.Show("Ürün başarıyla silindi.");
        }

        private async void ShowTemporaryLog(string message)
        {
            if (_isLogHistoryOpen)
                return;

            Label logLabel = new Label();

            logLabel.Text = $"{DateTime.Now:HH:mm:ss}  •  {message}";
            logLabel.AutoSize = false;
            logLabel.Width = flowLog.ClientSize.Width - 25;
            logLabel.Height = 45;

            logLabel.Font = new Font("Segoe UI", 9F);
            logLabel.TextAlign = ContentAlignment.MiddleLeft;

            logLabel.BackColor = Color.FromArgb(240, 244, 248);
            logLabel.ForeColor = Color.FromArgb(45, 55, 65);

            logLabel.Padding = new Padding(10);
            logLabel.Margin = new Padding(3, 3, 3, 5);

            flowLog.Controls.Add(logLabel);
            flowLog.Controls.SetChildIndex(logLabel, 0);

            await Task.Delay(30000);

            if (!logLabel.IsDisposed)
            {
                flowLog.Controls.Remove(logLabel);
                logLabel.Dispose();
            }
        }

        private async void btnLogHistory_Click(object sender, EventArgs e)
        {
            _isLogHistoryOpen = true;

            var importLogs = _importHistoryService.GetAllImportHistories()
                .Select(history => new
                {
                    Date = history.ImportedAt,
                    Description = $"{history.FileName} aktarıldı."
                });

            var activityLogs = _activityLogService.GetAllActivityLogs()
                .Select(log => new
                {
                    Date = log.CreatedAt,
                    Description = log.Description
                });

            var allLogs = importLogs
                .Concat(activityLogs)
                .OrderByDescending(log => log.Date)
                .ToList();

            flowLog.Controls.Clear();

            foreach (var log in allLogs
                .Where(x => !string.IsNullOrWhiteSpace(x.Description)))
            {
                Label logLabel = new Label();

                logLabel.Text =
                    $"{log.Date:dd.MM.yyyy HH:mm:ss}  •  {log.Description}";

                logLabel.AutoSize = false;
                logLabel.Width = flowLog.ClientSize.Width - 25;
                logLabel.Height = 45;

                logLabel.Font = new Font("Segoe UI", 9F);
                logLabel.TextAlign = ContentAlignment.MiddleLeft;

                logLabel.BackColor = Color.FromArgb(240, 244, 248);
                logLabel.ForeColor = Color.FromArgb(45, 55, 65);

                logLabel.Padding = new Padding(10);
                logLabel.Margin = new Padding(3, 3, 3, 5);

                flowLog.Controls.Add(logLabel);
            }

            await Task.Delay(30000);

            flowLog.Controls.Clear();

            _isLogHistoryOpen = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.linkedin.com/in/efe-akbiyik-261610323/",
                UseShellExecute = true
            });

        }

        private void BOMProject_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                _materialService.BackupDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Veritabanı yedeklenemedi:\n{ex.Message}",
                    "Yedekleme Hatası",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
