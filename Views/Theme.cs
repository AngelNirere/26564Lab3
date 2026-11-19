namespace Smart_match.Views;

public static class Theme
{
    public static readonly Color Black = Color.FromArgb(18, 18, 18);
    public static readonly Color DarkGray = Color.FromArgb(32, 32, 32);
    public static readonly Color Green = Color.FromArgb(0, 150, 70);
    public static readonly Color LightGreen = Color.FromArgb(46, 204, 113);

    public static void Apply(Form form)
    {
        form.BackColor = Black;
        form.ForeColor = Color.White;
        ApplyToControls(form.Controls);
    }

    private static void ApplyToControls(Control.ControlCollection controls)
    {
        foreach (Control c in controls)
        {
            switch (c)
            {
                case Button b:
                    b.FlatStyle = FlatStyle.Flat;
                    b.FlatAppearance.BorderSize = 0;
                    b.BackColor = Green;
                    b.ForeColor = Color.White;
                    b.Cursor = Cursors.Hand;
                    b.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                    break;

                case TextBox t:
                    t.BackColor = DarkGray;
                    t.ForeColor = Color.White;
                    t.BorderStyle = BorderStyle.FixedSingle;
                    break;

                case ComboBox cb:
                    cb.FlatStyle = FlatStyle.Flat;
                    cb.BackColor = DarkGray;
                    cb.ForeColor = Color.White;
                    break;

                case NumericUpDown n:
                    n.BackColor = DarkGray;
                    n.ForeColor = Color.White;
                    break;

                case Label l:
                    l.BackColor = Color.Transparent;
                    bool isTitle = l.Font.Bold || l.Name == "lblTitle" || l.Name == "lblWelcome";
                    l.ForeColor = isTitle ? LightGreen : Color.White;
                    if (l.Name == "lblTitle" || l.Name == "lblWelcome")
                        l.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
                    break;

                case DataGridView g:
                    StyleGrid(g);
                    break;
            }

            if (c.HasChildren)
                ApplyToControls(c.Controls);
        }
    }

    private static void StyleGrid(DataGridView g)
    {
        g.EnableHeadersVisualStyles = false;
        g.BackgroundColor = Black;
        g.BorderStyle = BorderStyle.None;
        g.GridColor = Color.FromArgb(60, 60, 60);
        g.RowHeadersVisible = false;

        g.DefaultCellStyle.BackColor = DarkGray;
        g.DefaultCellStyle.ForeColor = Color.White;
        g.DefaultCellStyle.SelectionBackColor = Green;
        g.DefaultCellStyle.SelectionForeColor = Color.White;

        g.ColumnHeadersDefaultCellStyle.BackColor = Green;
        g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        g.ColumnHeadersDefaultCellStyle.SelectionBackColor = Green;
        g.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
    }
}