using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace Cert
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stream myStream;
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();

            OpenFileDialog1.Filter = "cer files (*.cer|*.cer|All files (*.*)|*.*";

            if (OpenFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((myStream = OpenFileDialog1.OpenFile()) != null)
                {
                    myStream.Close();
                }
                textBox1.Text = OpenFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FolderBrowserDialog1 = new FolderBrowserDialog();

            DialogResult result = FolderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox2.Text = FolderBrowserDialog1.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            X509Certificate cert = new X509Certificate(textBox1.Text);
            string ogrn = cert.Subject.Substring(cert.Subject.IndexOf("OGRN=")+5, 13);

            Context db = new Context();
            var uchastnik = db.Uchastniki_SMEV.FirstOrDefault(p => p.OGRN == ogrn);

            Word._Application oWord = new Word.Application();
            Word.Document oDoc = oWord.Documents.Add(Environment.CurrentDirectory + "\\Заявка на перерегистрацию ЭП.dotx");
            oDoc.Bookmarks["Namespace"].Range.Text = "Продуктивная среда";
            oDoc.Bookmarks["FullName"].Range.Text = uchastnik.Polnoe_naimenovanie_Uchastnika;
            oDoc.Bookmarks["ShortName"].Range.Text = uchastnik.Kratkoe_naimenovanie_Uchastnika;
            oDoc.Bookmarks["OGRN"].Range.Text = uchastnik.OGRN;
            if (uchastnik.Tip_Uchastnika == 1) oDoc.Bookmarks["Type"].Range.Text = "ОМСУ";
            else oDoc.Bookmarks["Type"].Range.Text = "РОИВ";
            oDoc.Bookmarks["Mnemonic"].Range.Text = uchastnik.Mnemonika_Uchastnika_v_SMEV3;
            oDoc.Bookmarks["FullNameIS"].Range.Text = uchastnik.Polnoe_naimenovanie_IS;
            oDoc.Bookmarks["ShortNameIS"].Range.Text = uchastnik.Kratkoe_naimenovanie_IS;
            oDoc.Bookmarks["MnemonicIS"].Range.Text = uchastnik.Mnemonika_IS_v_SMEV3;
            oDoc.SaveAs(FileName: textBox2.Text + $"\\Заявка на перерегистрацию ЭП ОВ {uchastnik.Polnoe_naimenovanie_IS} прод.docx");
            oDoc.Close();

            oDoc = oWord.Documents.Add(Environment.CurrentDirectory + "\\Заявка на перерегистрацию ЭП.dotx");
            oDoc.Bookmarks["Namespace"].Range.Text = "Тестовая среда";
            oDoc.Bookmarks["FullName"].Range.Text = uchastnik.Polnoe_naimenovanie_Uchastnika;
            oDoc.Bookmarks["ShortName"].Range.Text = uchastnik.Kratkoe_naimenovanie_Uchastnika;
            oDoc.Bookmarks["OGRN"].Range.Text = uchastnik.OGRN;
            if (uchastnik.Tip_Uchastnika == 1) oDoc.Bookmarks["Type"].Range.Text = "ОМСУ";
            else oDoc.Bookmarks["Type"].Range.Text = "РОИВ";
            oDoc.Bookmarks["Mnemonic"].Range.Text = uchastnik.Mnemonika_Uchastnika_v_SMEV3;
            oDoc.Bookmarks["FullNameIS"].Range.Text = uchastnik.Polnoe_naimenovanie_IS;
            oDoc.Bookmarks["ShortNameIS"].Range.Text = uchastnik.Kratkoe_naimenovanie_IS;
            string mnemonicIS = uchastnik.Mnemonika_IS_v_SMEV3;
            if (uchastnik.Mnemonika_IS_v_SMEV3[uchastnik.Mnemonika_IS_v_SMEV3.Length - 1] == 'S') mnemonicIS = mnemonicIS.Replace('S', 'T');
            oDoc.Bookmarks["MnemonicIS"].Range.Text = mnemonicIS;
            oDoc.SaveAs(FileName: textBox2.Text + $"\\Заявка на перерегистрацию ЭП ОВ {uchastnik.Polnoe_naimenovanie_IS} тест.docx"); ;
            oDoc.Close();

            toolStripStatusLabel1.Text = "";
            toolStripStatusLabel1.Text = "Готово";
        }
    }
}
