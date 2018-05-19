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
        InicjalizujKomponenty();
        SetStyle(ControlStyles.Opaque, true);

        // sciezka do folderu projektu i obrazka
        obrazek = new Bitmap(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/grafika//"+ nazwaObrazka + ".png");
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        g.DrawImage(obrazek, ClientRectangle);
    }

    private void InicjalizujKomponenty()
    {
        komponenty = new System.ComponentModel.Container();
        Size = new System.Drawing.Size(300, 300);
    }

    // statyczna metoda pozwala na tworzenie okna z kazdego miejsca odwolujac sie do klasy Okno
    public static void StworzOkno(string nazwaObrazka)
    {
        Application.Run(new Okno(nazwaObrazka));
    }
}