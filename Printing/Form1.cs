using SATOPrinterAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Printing
{
    public partial class Form1 : Form
    {
        private bool keepPrinting = true;
        Printer SATOPrinter = null;
        Driver SATODriver = null;
        private string label = @"[ESC]A[ESC]H60[ESC]V10 [ESC]X22,IDENTIFICATION CARD[ESC]H70[ESC]V48 [ESC]X22,ITEM [ESC]H350[ESC]V48 [ESC]X22,[Item_ToReplace][ESC]H70[ESC]V86 [ESC]X22,ITEM NAME [ESC]H350[ESC]V86 [ESC]X22,[Item_Name_ToReplace][ESC]H70[ESC]V189 [ESC]X22,PLANT CODE [ESC]H350[ESC]V189 [ESC]X22,[Plant_Code_ToReplace][ESC]H70[ESC]V227 [ESC]X22,STORAGE LOCATION [ESC]H350[ESC]V227 [ESC]X22,[Storage_Location_ToReplace][ESC]H70[ESC]V266 [ESC]X22,VENDOR CODE [ESC]H350[ESC]V266 [ESC]X22,[Vendor_Code_ToReplace][ESC]H70[ESC]V304 [ESC]X22,VENDOR LOT NO [ESC]H350[ESC]V304 [ESC]X22,[Vendor_Lot_Number_ToReplace][ESC]H70[ESC]V343 [ESC]X22,MAMM LOT NO [ESC]H350[ESC]V343[ESC]X22,[Mamm_Lot_No_ToReplace][ESC]H70[ESC]V381 [ESC]X22,PRINT DATE [ESC]H350[ESC]V381 [ESC]X22,[Print_Date_ToReplace][ESC]H70[ESC]V420 [ESC]X22,QUANTITY [ESC]H350[ESC]V420 [ESC]X22,[Quantity_ToReplace][ESC]H70[ESC]V450 [ESC]X22,UOM [ESC]H450[ESC]V450 [ESC]X22,[Uom_ToReplace][ESC]H600[ESC]V130[ESC]2D30,L,06,0,0[ESC]DS2,[Qrcode_ToReplace][ESC]Z";
        private string testlabel = @"[ESC]A[ESC]H60[ESC]V10 [ESC]X22,IDENTIFICATION CARD[ESC]H70[ESC]V48 [ESC]X22,ITEM [ESC]H350[ESC]V48 [ESC]X22,10000120653[ESC]H70[ESC]V86 [ESC]X22,ITEM NAME [ESC]H350[ESC]V86 [ESC]X22,FE-FMG834+A[ESC]H70[ESC]V189 [ESC]X22,PLANT CODE [ESC]H350[ESC]V189 [ESC]X22,MM01[ESC]H70[ESC]V227 [ESC]X22,STORAGE LOCATION [ESC]H350[ESC]V227 [ESC]X22,W001[ESC]H70[ESC]V266 [ESC]X22,VENDOR CODE [ESC]H350[ESC]V266 [ESC]X22,1000011647[ESC]H70[ESC]V304 [ESC]X22,VENDOR LOT NO [ESC]H350[ESC]V304 [ESC]X22,20243-0184 [ESC]H70[ESC]V343 [ESC]X22,MAMM LOT NO [ESC]H350[ESC]V343[ESC]X22,1005533271[ESC]H70[ESC]V381 [ESC]X22,PRINT DATE [ESC]H350[ESC]V381 [ESC]X22,2024/05/31102342250[ESC]H70[ESC]V420 [ESC]X22,QUANTITY [ESC]H350[ESC]V420 [ESC]X22,4435.000[ESC]H70[ESC]V450 [ESC]X22,UOM [ESC]H450[ESC]V450 [ESC]X22,PC[ESC]H600[ESC]V130[ESC]2D30,L,06,0,0[ESC]DS2,0000100734ZZZ1[HT]392PCZMM01B003N917P3O4MM01D131202309182117205[ESC]Z";
        PrintingDAL dAL = new PrintingDAL();
        public Form1()
        {
            InitializeComponent();
            SATOPrinter = new Printer();
            SATODriver = new Driver();
            AddCmbItems();
        }


        private void AddCmbItems()
        {
            List<string> items = new List<string>
            {   "All Labes",
                "Specific Items",

            };
            comboBox1.Items.AddRange(items.ToArray());
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            keepPrinting = true;
            SATOPrinter.Interface = Printer.InterfaceType.TCPIP;
            SATOPrinter.TCPIPAddress = textBox1.Text;
            SATOPrinter.TCPIPPort = textBox2.Text;

            List<TrxLabelTag> trxLabelTags = new List<TrxLabelTag>();


            if (comboBox1.SelectedIndex == 1)
            {
                trxLabelTags = dAL.GetLabels(textBoxCode.Text);
            }
            else
            {
                trxLabelTags = dAL.GetLabels();
            }
            await Task.Run(() => Print(trxLabelTags));
        }
        private void Print(List<TrxLabelTag> trxLabelTags, bool testLabel = false)
        {
            SATOPrinter.Interface = Printer.InterfaceType.TCPIP;

            foreach (var tag in trxLabelTags)
            {
                if (keepPrinting == false)
                {
                    log("Printing stopped");
                    return;
                }
                if (string.IsNullOrEmpty(tag.req_ip))
                {
                    log("Ip is empty for VendorLotNo " + tag.vendor_lot_no);
                    continue;
                }


                SATOPrinter.TCPIPAddress = tag.req_ip;
                SATOPrinter.TCPIPPort = "9100";

                log("Label printing for VendorLotNo : " + tag.vendor_lot_no);
                var labelToPrint = Replacedlabel(tag, label);
                byte[] cmddata = Utils.StringToByteArray(ControlCharReplace(labelToPrint), "utf8");
                try
                {
                    SATOPrinter.Send(cmddata);
                    dAL.UpdateLabel(tag.vendor_lot_no);
                    log("Label printed for VendorLotNo : " + tag.vendor_lot_no);
                }
                catch (Exception ex)
                {
                    log("Error: VendorLotNo : " + tag.vendor_lot_no + "Message : " + ex.Message);
                }


            }
            log("Label Done ");
        }

        private string Replacedlabel(TrxLabelTag tag, string label)
        {
            string finalLabel = string.Empty;
            finalLabel = label.Replace("[Item_ToReplace]", tag.item_cd.ToString())
                              .Replace("[Item_Name_ToReplace]", tag.item_nm.ToString())
                              .Replace("[Plant_Code_ToReplace]", tag.plnt_cd.ToString())
                              .Replace("[Storage_Location_ToReplace]", tag.str_location.ToString())
                              .Replace("[Vendor_Code_ToReplace]", tag.vendor_cd.ToString())
                              .Replace("[Vendor_Lot_Number_ToReplace]", tag.vendor_lot_no.ToString())
                              .Replace("[Mamm_Lot_No_ToReplace]", tag.mamm_lot_no.ToString())
                              .Replace("[Print_Date_ToReplace]", tag.print_date.ToString())
                              .Replace("[Quantity_ToReplace]", tag.qty.ToString())
                              .Replace("[Uom_ToReplace]", tag.uom.ToString())
                              .Replace("[Qrcode_ToReplace]", tag.qr_cd.ToString());

            return finalLabel;
        }


        private string ControlCharReplace(string data)
        {
            Dictionary<string, char> chrList = ControlCharList();
            foreach (string key in chrList.Keys)
            {
                data = data.Replace(key, chrList[key].ToString());
            }
            return data;
        }

        private Dictionary<string, char> ControlCharList()
        {
            Dictionary<string, char> ctr = new Dictionary<string, char>();
            ctr.Add("[NUL]", '\u0000');
            ctr.Add("[SOH]", '\u0001');
            ctr.Add("[STX]", '\u0002');
            ctr.Add("[ETX]", '\u0003');
            ctr.Add("[EOT]", '\u0004');
            ctr.Add("[ENQ]", '\u0005');
            ctr.Add("[ACK]", '\u0006');
            ctr.Add("[BEL]", '\u0007');
            ctr.Add("[BS]", '\u0008');
            ctr.Add("[HT]", '\u0009');
            ctr.Add("[LF]", '\u000A');
            ctr.Add("[VT]", '\u000B');
            ctr.Add("[FF]", '\u000C');
            ctr.Add("[CR]", '\u000D');
            ctr.Add("[SO]", '\u000E');
            ctr.Add("[SI]", '\u000F');
            ctr.Add("[DLE]", '\u0010');
            ctr.Add("[DC1]", '\u0011');
            ctr.Add("[DC2]", '\u0012');
            ctr.Add("[DC3]", '\u0013');
            ctr.Add("[DC4]", '\u0014');
            ctr.Add("[NAK]", '\u0015');
            ctr.Add("[SYN]", '\u0016');
            ctr.Add("[ETB]", '\u0017');
            ctr.Add("[CAN]", '\u0018');
            ctr.Add("[EM]", '\u0019');
            ctr.Add("[SUB]", '\u001A');
            ctr.Add("[ESC]", '\u001B');
            ctr.Add("[FS]", '\u001C');
            ctr.Add("[GS]", '\u001D');
            ctr.Add("[RS]", '\u001E');
            ctr.Add("[US]", '\u001F');
            ctr.Add("[DEL]", '\u007F');
            return ctr;
        }
        private void log(string message)
        {
            listBox1.Invoke((Action)(() =>
            {
                if (listBox1.Items.Count > 1000)
                {
                    listBox1.Items.RemoveAt(1000);

                }
                listBox1.Items.Insert(0, message);
            }));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            keepPrinting = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SATOPrinter.Disconnect();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            keepPrinting = false;
            if (comboBox1.SelectedIndex == 1)
            {
                lblCode.Visible = true;
                textBoxCode.Visible = true;
            }
            else
            {
                lblCode.Visible = false;
                textBoxCode.Visible = false;
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                log("Ip and Port cant be empty for test label");
                return;
            }
            byte[] cmddata = Utils.StringToByteArray(ControlCharReplace(testlabel), "utf8");
            SATOPrinter.Interface = Printer.InterfaceType.TCPIP;
            SATOPrinter.TCPIPAddress = textBox1.Text;
            SATOPrinter.TCPIPPort = textBox2.Text;
            SATOPrinter.Send(cmddata);

        }
    }
}
