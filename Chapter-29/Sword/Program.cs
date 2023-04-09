Sword sword1 = new Sword(SwordMaterial.Iron, Gemstones.None, 16, 4);

Sword sword2 = sword1 with { material = SwordMaterial.Steel };

Sword sword3 = sword2 with { gemstone = Gemstones.Sapphire };

Sword sword4 = sword2 with { gemstone = Gemstones.Diamond, length = 20 };

Console.WriteLine($"{sword1.ToString()}, {sword2.ToString()}, {sword3.ToString()}, {sword4.ToString()}");

public record Sword(SwordMaterial material, Gemstones gemstone, int length, int width);

public enum SwordMaterial { Wood, Bronze, Iron, Steel, Binarium }
public enum Gemstones { Emerald, Amber, Sapphire, Diamond, Bitstone, None }