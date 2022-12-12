
public interface  IPower 
{
    public bool PowerOn();
   
    public void SwitchOn();
    public void SwitchOff();

    public string GetDescription();
}

public abstract class PowerSource : IPower
{
    private bool IsOn = false;
    public bool PowerOn()
    {
        return IsOn;
    }
    
    public PowerSource() : this(false)
    {

    }
    public PowerSource(bool IsOn)
    {
        this.IsOn = IsOn;
    }


     public void SwitchOn()
     {
        IsOn = true;
     }
    public void SwitchOff()
     {
        IsOn = false;
     }

    public abstract string GetDescription();
}


public class EskomPower : PowerSource
{
    public EskomPower(bool IsOn) : base(IsOn)
    {

    }
    public override string GetDescription()
    {
        return "Using Electricity";
    }
}

public class SolarPower : PowerSource
{
    public SolarPower(bool IsOn) : base(IsOn)
    {

    }
     public override string GetDescription()
    {
        return "Using Solar";
    }
}
public   class BatteryPower : PowerSource
{
     public BatteryPower(bool IsOn) : base(IsOn)
    {

    }
      public override string GetDescription()
    {
        return "Using Battery";
    }
}