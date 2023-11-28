using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Drawing;

namespace PdfMaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AllowDrop = true;

        }
        private List<Image> images = new List<Image>();

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif";
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in openFileDialog.FileNames)
                {
                    Image image = Image.FromFile(fileName);
                    images.Add(image);

                    PictureBox pictureBox = new PictureBox
                    {
                        Image = image,
                        SizeMode = PictureBoxSizeMode.AutoSize
                    };


                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {




            if (images.Count == 0)
            {
                MessageBox.Show("Lütfen en az bir görsel seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files|*.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string pdfPath = saveFileDialog.FileName;

                using (PdfDocument document = new PdfDocument())
                {
                    foreach (Image image in images)
                    {
                        PdfPage page = document.AddPage();
                        XGraphics gfx = XGraphics.FromPdfPage(page);

                        // Calculate scaling factor to fit the image within A4 page
                        double scaleFactor = Math.Min(page.Width.Point / image.Width, page.Height.Point / image.Height);

                        // Calculate scaled dimensions
                        double scaledWidth = image.Width * scaleFactor;
                        double scaledHeight = image.Height * scaleFactor;

                        // Calculate position to center the image on the page
                        double x = (page.Width.Point - scaledWidth) / 2;
                        double y = (page.Height.Point - scaledHeight) / 2;

                        // Convert Image to XImage using MemoryStream
                        using (MemoryStream ms = new MemoryStream())
                        {
                            image.Save(ms, image.RawFormat);
                            XImage xImage = XImage.FromStream(ms);
                            gfx.DrawImage(xImage, x, y, scaledWidth, scaledHeight);
                        }
                    }

                    document.Save(pdfPath);
                }

                MessageBox.Show("PDF oluþturuldu!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            // Sürüklenen dosyalarýn resim dosyalarý olup olmadýðýný kontrol et
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && IsImageFile((string[])e.Data.GetData(DataFormats.FileDrop)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            // Sürüklenen dosyalarý iþle
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if (IsImageFile(file))
                {
                    Image image = Image.FromFile(file);
                    images.Add(image);

                    PictureBox pictureBox = new PictureBox
                    {
                        Image = image,
                        SizeMode = PictureBoxSizeMode.AutoSize
                    };


                }
            }
            MessageBox.Show("Görseller baþarýyla yüklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // Verilen dosya yollarý arasýnda resim dosyasý olup olmadýðýný kontrol et
        private bool IsImageFile(string[] filepaths)
        {
            foreach (string filepath in filepaths)
            {
                if (!IsImageFile(filepath))
                {
                    return false;
                }
            }
            return true;
        }

        // Verilen dosya yolunun bir resim dosyasý olup olmadýðýný kontrol et
        private bool IsImageFile(string filepath)
        {
            string[] allowedExtensions = { ".bmp", ".jpg", ".jpeg", ".png", ".gif" };
            string extension = Path.GetExtension(filepath.ToLower());
            return Array.Exists(allowedExtensions, element => element == extension);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}