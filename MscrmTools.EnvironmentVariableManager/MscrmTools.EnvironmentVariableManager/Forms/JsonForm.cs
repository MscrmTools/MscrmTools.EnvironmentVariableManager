using ScintillaNET;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MscrmTools.EnvironmentVariableManager.Forms
{
    public partial class JsonForm : Form
    {
        public JsonForm()
        {
            InitializeComponent();

            scintilla1.Lexer = Lexer.Json;
            scintilla1.StyleResetDefault();
            scintilla1.Styles[Style.Default].Font = "Consolas";
            scintilla1.Styles[Style.Default].Size = 10;
            scintilla1.StyleClearAll();
            scintilla1.Styles[Style.Json.Default].ForeColor = Color.Silver;
            scintilla1.Styles[Style.Json.BlockComment].ForeColor = Color.Green;
            scintilla1.Styles[Style.Json.PropertyName].ForeColor = Color.Red;
            scintilla1.Styles[Style.Json.String].ForeColor = Color.Blue;
            scintilla1.Styles[Style.Json.Number].ForeColor = Color.Blue;
            scintilla1.Styles[Style.Json.Keyword].ForeColor = Color.Blue;
            scintilla1.Styles[Style.Json.StringEol].BackColor = Color.Pink;
            scintilla1.Styles[Style.Json.Operator].ForeColor = Color.Black;
            scintilla1.Styles[Style.Json.Uri].ForeColor = Color.Blue;

            // Instruct the lexer to calculate folding
            scintilla1.SetProperty("fold", "1");
            scintilla1.SetProperty("fold.compact", "1");
            scintilla1.SetProperty("fold.html", "1");

            // Configure a margin to display folding symbols
            scintilla1.Margins[2].Type = MarginType.Symbol;
            scintilla1.Margins[2].Mask = Marker.MaskFolders;
            scintilla1.Margins[2].Sensitive = true;
            scintilla1.Margins[2].Width = 20;

            // Set colors for all folding markers
            for (int i = 25; i <= 31; i++)
            {
                scintilla1.Markers[i].SetForeColor(SystemColors.ControlLightLight);
                scintilla1.Markers[i].SetBackColor(SystemColors.ControlDark);
            }

            // Configure folding markers with respective symbols
            scintilla1.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
            scintilla1.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
            scintilla1.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
            scintilla1.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            scintilla1.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
            scintilla1.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            scintilla1.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;
        }

        public JsonForm(string json) : this()
        {
            scintilla1.Text = json;
        }

        public string Json { get; internal set; }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            Json = scintilla1.Text;
        }
    }
}