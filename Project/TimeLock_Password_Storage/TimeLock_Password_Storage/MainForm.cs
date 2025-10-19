using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace PasswordVault
{
    public partial class MainForm : Form
    {
        private const string DATA_FILE = "vault.dat";
        private const string LOCK_FILE = "vault.lock";
        private TextBox txtPasswords;
        private NumericUpDown numDays;
        private NumericUpDown numHours;
        private Button btnLock;
        private Button btnUnlock;
        private Label lblStatus;
        private Label lblTimeRemaining;
        private System.Windows.Forms.Timer timer;

        public MainForm()
        {
            InitializeComponent();
            CheckLockStatus();

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // Her saniye güncelle
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void InitializeComponent()
        {
            this.Text = "Oyun Şifre Kilidi";
            this.Size = new Size(650, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Başlık
            Label lblTitle = new Label
            {
                Text = "Oyun Hesap Şifreleri Kilitleme Sistemi",
                Font = new Font("Arial", 14, FontStyle.Bold),
                Location = new Point(170, 20),
                Size = new Size(350, 30)
            };

            // Şifre giriş alanı
            Label lblPasswords = new Label
            {
                Text = "Şifrelerinizi buraya yazın:",
                Location = new Point(20, 60),
                Size = new Size(200, 20)
            };

            txtPasswords = new TextBox
            {
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Location = new Point(20, 85),
                Size = new Size(540, 200),
                Font = new Font("Consolas", 10),
                Enabled = true,
                ReadOnly = false
            };

            // Süre seçimi
            Label lblDuration = new Label
            {
                Text = "Kilitleme Süresi:",
                Location = new Point(20, 300),
                Size = new Size(100, 20)
            };

            Label lblDays = new Label
            {
                Text = "Gün:",
                Location = new Point(130, 300),
                Size = new Size(35, 20)
            };

            numDays = new NumericUpDown
            {
                Location = new Point(165, 298),
                Size = new Size(60, 25),
                Maximum = 365,
                Minimum = 0,
                Value = 7
            };

            Label lblHours = new Label
            {
                Text = "Saat:",
                Location = new Point(235, 300),
                Size = new Size(35, 20)
            };

            numHours = new NumericUpDown
            {
                Location = new Point(270, 298),
                Size = new Size(60, 25),
                Maximum = 23,
                Minimum = 0,
                Value = 0
            };

            // Butonlar
            btnLock = new Button
            {
                Text = "KİLİTLE",
                Location = new Point(20, 340),
                Size = new Size(150, 40),
                BackColor = Color.Red,
                ForeColor = Color.White,
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            btnLock.Click += BtnLock_Click;

            btnUnlock = new Button
            {
                Text = "KİLİDİ AÇ",
                Location = new Point(180, 340),
                Size = new Size(150, 40),
                BackColor = Color.Green,
                ForeColor = Color.White,
                Font = new Font("Arial", 12, FontStyle.Bold),
                Enabled = false
            };
            btnUnlock.Click += BtnUnlock_Click;

            // Acil Aç butonu (Test için)
            Button btnEmergency = new Button
            {
                Text = "ACİL AÇ (Test)",
                Location = new Point(340, 340),
                Size = new Size(120, 40),
                BackColor = Color.Orange,
                ForeColor = Color.White,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            btnEmergency.Click += (sender, e) =>
            {
                // Sistemi tamamen sıfırla
                try
                {
                    if (File.Exists(LOCK_FILE)) File.Delete(LOCK_FILE);
                    if (File.Exists(DATA_FILE)) File.Delete(DATA_FILE);

                    txtPasswords.Enabled = true;
                    txtPasswords.ReadOnly = false;
                    txtPasswords.Text = "";
                    numDays.Enabled = true;
                    numHours.Enabled = true;
                    btnLock.Enabled = true;
                    btnUnlock.Enabled = false;
                    lblStatus.Text = "Sistem sıfırlandı! Yeni şifreler girebilirsiniz.";
                    lblStatus.ForeColor = Color.Blue;
                    lblTimeRemaining.Text = "";
                    txtPasswords.Focus();

                    MessageBox.Show("Sistem başarıyla sıfırlandı!\nArtık yeni şifreler girebilirsiniz.",
                        "Sıfırlama Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            // Test butonu (sadece test için)
            Button btnTest = new Button
            {
                Text = "Acil Aç (Test)",
                Location = new Point(340, 340),
                Size = new Size(100, 40),
                BackColor = Color.Orange,
                ForeColor = Color.White,
                Font = new Font("Arial", 10)
            };
            btnTest.Click += (s, e) => {
                // Tüm dosyaları sil ve sıfırla
                if (File.Exists(LOCK_FILE)) File.Delete(LOCK_FILE);
                if (File.Exists(DATA_FILE)) File.Delete(DATA_FILE);

                txtPasswords.Enabled = true;
                txtPasswords.ReadOnly = false;
                txtPasswords.Text = "";
                numDays.Enabled = true;
                numHours.Enabled = true;
                btnLock.Enabled = true;
                btnUnlock.Enabled = false;
                lblStatus.Text = "Sistem sıfırlandı. Yeni şifreler girebilirsiniz.";
                lblStatus.ForeColor = Color.Blue;
                lblTimeRemaining.Text = "";

                MessageBox.Show("Sistem sıfırlandı!", "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            // Durum etiketi
            lblStatus = new Label
            {
                Location = new Point(20, 395),
                Size = new Size(540, 25),
                Font = new Font("Arial", 10)
            };

            // Kalan süre etiketi
            lblTimeRemaining = new Label
            {
                Location = new Point(20, 420),
                Size = new Size(540, 25),
                Font = new Font("Arial", 11, FontStyle.Bold),
                ForeColor = Color.Blue
            };

            // Kontrolleri forma ekle
            this.Controls.AddRange(new Control[] {
                lblTitle, lblPasswords, txtPasswords,
                lblDuration, lblDays, numDays, lblHours, numHours,
                btnLock, btnUnlock, btnEmergency, lblStatus, lblTimeRemaining
            });
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (File.Exists(LOCK_FILE))
            {
                UpdateTimeRemaining();
            }
        }

        private void UpdateTimeRemaining()
        {
            try
            {
                string lockData = File.ReadAllText(LOCK_FILE);
                DateTime unlockTime = DateTime.Parse(lockData);
                TimeSpan remaining = unlockTime - DateTime.Now;

                if (remaining.TotalSeconds > 0)
                {
                    lblTimeRemaining.Text = $"Kalan Süre: {remaining.Days} gün, {remaining.Hours} saat, " +
                                          $"{remaining.Minutes} dakika, {remaining.Seconds} saniye";
                    lblTimeRemaining.ForeColor = Color.Red;
                }
                else
                {
                    lblTimeRemaining.Text = "Kilit süresi doldu! Artık şifrelerinize erişebilirsiniz.";
                    lblTimeRemaining.ForeColor = Color.Green;
                    btnUnlock.Enabled = true;
                }
            }
            catch
            {
                // Hata durumunda sessizce devam et
            }
        }

        private void CheckLockStatus()
        {
            if (File.Exists(LOCK_FILE) && File.Exists(DATA_FILE))
            {
                try
                {
                    string lockData = File.ReadAllText(LOCK_FILE);
                    DateTime unlockTime = DateTime.Parse(lockData);

                    if (DateTime.Now < unlockTime)
                    {
                        // Hala kilitli
                        txtPasswords.Enabled = false;
                        txtPasswords.ReadOnly = true;
                        numDays.Enabled = false;
                        numHours.Enabled = false;
                        btnLock.Enabled = false;
                        btnUnlock.Enabled = false;

                        TimeSpan remaining = unlockTime - DateTime.Now;
                        lblStatus.Text = "Şifreler kilitli!";
                        lblStatus.ForeColor = Color.Red;

                        UpdateTimeRemaining();
                    }
                    else
                    {
                        // Kilit süresi dolmuş
                        txtPasswords.Enabled = false;
                        txtPasswords.ReadOnly = true;
                        numDays.Enabled = false;
                        numHours.Enabled = false;
                        btnLock.Enabled = false;
                        btnUnlock.Enabled = true;

                        lblStatus.Text = "Kilit süresi doldu. 'KİLİDİ AÇ' butonuna tıklayın.";
                        lblStatus.ForeColor = Color.Green;
                        lblTimeRemaining.Text = "Kilit süresi doldu! Artık şifrelerinize erişebilirsiniz.";
                        lblTimeRemaining.ForeColor = Color.Green;
                    }
                }
                catch
                {
                    // Dosya bozuksa sıfırla
                    if (File.Exists(LOCK_FILE)) File.Delete(LOCK_FILE);
                    if (File.Exists(DATA_FILE)) File.Delete(DATA_FILE);
                    ResetApplication();
                }
            }
            else
            {
                // Dosyalar eksikse temiz başlat
                if (File.Exists(LOCK_FILE)) File.Delete(LOCK_FILE);
                if (File.Exists(DATA_FILE)) File.Delete(DATA_FILE);
                ResetApplication();
            }
        }

        private void ResetApplication()
        {
            // Metin kutusunu temizle ve aktif et
            txtPasswords.Clear();
            txtPasswords.Enabled = true;
            txtPasswords.ReadOnly = false;

            // Süre seçimlerini aktif et
            numDays.Enabled = true;
            numHours.Enabled = true;
            numDays.Value = 7;
            numHours.Value = 0;

            // Butonları ayarla
            btnLock.Enabled = true;
            btnUnlock.Enabled = false;

            // Durum mesajlarını güncelle
            lblStatus.Text = "Şifrelerinizi girin ve kilitleme süresini belirleyin.";
            lblStatus.ForeColor = Color.Black;
            lblTimeRemaining.Text = "";
        }

        private void BtnLock_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPasswords.Text))
            {
                MessageBox.Show("Lütfen en az bir şifre girin!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numDays.Value == 0 && numHours.Value == 0)
            {
                MessageBox.Show("Lütfen geçerli bir süre belirleyin!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Şifreleriniz {numDays.Value} gün {numHours.Value} saat boyunca kilitlenecek.\n\n" +
                "Bu süre dolmadan şifrelere ERİŞEMEZSİNİZ!\n\n" +
                "Emin misiniz?",
                "Onay",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                LockPasswords();
            }
        }

        private void LockPasswords()
        {
            try
            {
                // Metin kutusunun boş olmadığından emin ol
                if (string.IsNullOrWhiteSpace(txtPasswords.Text))
                {
                    MessageBox.Show("Lütfen kilitlemeden önce şifrelerinizi yazın!", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Şifreleri encrypt et
                string encryptedData = EncryptString(txtPasswords.Text);
                File.WriteAllText(DATA_FILE, encryptedData);

                // Kilit süresini kaydet
                DateTime unlockTime = DateTime.Now
                    .AddDays((double)numDays.Value)
                    .AddHours((double)numHours.Value);
                File.WriteAllText(LOCK_FILE, unlockTime.ToString());

                // Dosyaları gizli yap
                File.SetAttributes(DATA_FILE, FileAttributes.Hidden);
                File.SetAttributes(LOCK_FILE, FileAttributes.Hidden);

                MessageBox.Show(
                    $"Şifreler başarıyla kilitlendi!\n\n" +
                    $"Açılma zamanı: {unlockTime:dd.MM.yyyy HH:mm}\n\n" +
                    $"Bu zamana kadar şifrelerinize ERİŞEMEYECEKSİNİZ!",
                    "Kilitleme Başarılı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CheckLockStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUnlock_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(DATA_FILE))
                {
                    MessageBox.Show("Kilitli şifre dosyası bulunamadı!", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Önce şifreleri oku
                string encryptedData = File.ReadAllText(DATA_FILE);
                string decryptedData = DecryptString(encryptedData);

                // Dosyaları sil
                if (File.Exists(LOCK_FILE)) File.Delete(LOCK_FILE);
                if (File.Exists(DATA_FILE)) File.Delete(DATA_FILE);

                // Metin kutusunu aktif et ve şifreleri göster
                txtPasswords.Enabled = true;
                txtPasswords.ReadOnly = false;
                txtPasswords.Text = decryptedData;

                // Diğer kontrolleri aktif et
                numDays.Enabled = true;
                numHours.Enabled = true;
                numDays.Value = 7;
                numHours.Value = 0;
                btnLock.Enabled = true;
                btnUnlock.Enabled = false;

                // Durum mesajlarını güncelle
                lblStatus.Text = "Şifreler açıldı! İstediğiniz gibi düzenleyebilirsiniz.";
                lblStatus.ForeColor = Color.Green;
                lblTimeRemaining.Text = "";

                // Metin kutusuna odaklan
                txtPasswords.Focus();
                txtPasswords.SelectionStart = txtPasswords.Text.Length;

                MessageBox.Show(
                    "Şifreler başarıyla açıldı!\n\n" +
                    "• Şifrelerinizi görebilirsiniz\n" +
                    "• Yeni şifreler ekleyebilirsiniz\n" +
                    "• Düzenleyip tekrar kilitleyebilirsiniz",
                    "Kilit Açıldı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Şifreleme metodları
        private static string EncryptString(string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                // Sabit bir anahtar kullanıyoruz (gerçek uygulamada daha güvenli yöntemler kullanılmalı)
                aes.Key = Encoding.UTF8.GetBytes("ThisIs32ByteLongPasswordForAES!!");
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }
                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        private static string DecryptString(string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes("ThisIs32ByteLongPasswordForAES!!");
                aes.IV = iv;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

      
    }
}