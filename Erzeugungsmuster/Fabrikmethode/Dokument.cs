namespace Erzeugungsmuster.Fabrikmethode;

public abstract class Dokument
{
    public int Belegnummer { get; set; }
	
    public virtual bool IsValid()
    {
        return Belegnummer > 0;
    }
}