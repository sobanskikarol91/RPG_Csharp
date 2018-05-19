using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;


public class Okno : System.Windows.Forms.Form
{
    private System.ComponentModel.Container komponenty = null;
    private Image obrazek;

    public Okno(string nazwaObrazka)
    {
        // sciezka do folderu projektu i obrazka
        obrazek = new Bitmap(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/grafika//" + nazwaObrazka + ".png");
        
        SetStyle(ControlStyles.Opaque, true);
        komponenty = new System.ComponentModel.Container();
        // ustawiamy wielksoc okna zalezna od wielksoci obrazka
        Size = new System.Drawing.Size(obrazek.Size.Width, obrazek.Size.Height);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
       // rysujemy obrazek
        Graphics g = e.Graphics;
        g.DrawImage(obrazek, ClientRectangle);
    }

    // statyczna metoda pozwala na tworzenie okna z kazdego miejsca odwolujac sie do klasy Okno
    public static void StworzOkno(string nazwaObrazka)
    {
        Application.Run(new Okno(nazwaObrazka));
    }
}