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

namespace Printing
{
    public partial class Form1 : Form
    {
        private bool keepPrinting = true;
        Printer SATOPrinter = null;
        Driver SATODriver = null;
        private string label = @"[ESC]A

                        [ESC]H60[ESC]V10 [ESC]X22,IDENTIFICATION CARD

                        [ESC]H70[ESC]V48 [ESC]X22,ITEM [ESC]H350[ESC]V48 [ESC]X22,10000120653

                        [ESC]H70[ESC]V86 [ESC]X22,ITEM NAME [ESC]H350[ESC]V86 [ESC]X22,FE-FMG834+A

                        [ESC]H70[ESC]V189 [ESC]X22,PLANT CODE [ESC]H350[ESC]V189 [ESC]X22,MM01

                        [ESC]H70[ESC]V227 [ESC]X22,STORAGE LOCATION [ESC]H350[ESC]V227 [ESC]X22,W001

                        [ESC]H70[ESC]V266 [ESC]X22,VENDOR CODE [ESC]H350[ESC]V266 [ESC]X22,1000011647
 
                        [ESC]H70[ESC]V304 [ESC]X22,VENDOR LOT NO [ESC]H350[ESC]V304 [ESC]X22,20243-0184 
                        
                        [ESC]H70[ESC]V343 [ESC]X22,MAMM LOT NO [ESC]H350[ESC]V343[ESC]X22,1005533271

                        [ESC]H70[ESC]V381 [ESC]X22,PRINT DATE [ESC]H350[ESC]V381 [ESC]X22,2024/05/31102342250

                        [ESC]H70[ESC]V420 [ESC]X22,QUANTITY [ESC]H350[ESC]V420 [ESC]X22,4435.000

                        [ESC]H70[ESC]V450 [ESC]X22,UOM [ESC]H450[ESC]V450 [ESC]X22,PC

                        [ESC]H600[ESC]V130[ESC]2D30,L,06,0,0[ESC]DS2,0000100734ZZZ1[HT]392PCZMM01B003N917P3O4MM01D131202309182117205

                        [ESC]Z";

        public Form1()
        {
            InitializeComponent();
            SATOPrinter = new Printer();
            SATODriver = new Driver();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            keepPrinting = true;
            SATOPrinter.Interface = Printer.InterfaceType.TCPIP;
            SATOPrinter.TCPIPAddress = textBox1.Text;
            SATOPrinter.TCPIPPort = textBox2.Text;
            Print();
        }
        private void Print()
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                log("Ip and Port cant be empty");
                return;
            }

            while (keepPrinting)
            {
                byte[] cmddata = Utils.StringToByteArray(ControlCharReplace(label), "utf8");
                SATOPrinter.Send(cmddata);
            }
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

            var uniqueCode = 10.ToString("X").PadLeft(8, '0');

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
            //ctr.Add("[COM]", '\u002C');
            ctr.Add("[DEL]", '\u007F');
            return ctr;
        }
        private void log(string message)
        {
            listBox1.Items.Add(message);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            keepPrinting = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SATOPrinter.Disconnect();
        }
    }
}
