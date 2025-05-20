public class Match
{
    public string Idopont { get; set; }
    public string Hazai { get; set; }
    public string Idegen { get; set; }
    public int HazaiPont { get; set; }
    public int IdegenPont { get; set; }
    public string Helyszin { get; set; }

    public Match(string sor)
    {
        var mezok = sor.Split(';');
        Idopont = mezok[5];
        Hazai = mezok[0];
        Idegen = mezok[1];
        HazaiPont = int.Parse(mezok[2]);
        IdegenPont = int.Parse(mezok[3]);
        Helyszin = mezok[4];
    }
}