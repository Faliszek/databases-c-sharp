using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Pracownik
/// </summary>
public class Pracownik
{
    private String imie = null;
    private String nazwisko = null;

    public string Imie { get => imie; set => imie = value; }
    public string Nazwisko { get => nazwisko; set => nazwisko = value; }

    public Pracownik()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Pracownik(string imie, string nazwisko)
    {
        Imie = imie;
        Nazwisko = nazwisko;
    }
}