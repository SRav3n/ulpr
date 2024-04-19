using System.ComponentModel.DataAnnotations;

interface IVector
{
    bool Kollin(vector3D other);
    bool LengthComparison(vector3D other);
}

abstract class Geometry : IVector
{
    public double Length { get; protected set; }
    public abstract bool Kollin(vector3D other);
    public abstract bool LengthComparison(vector3D other);
}
class vector3D : Geometry
{
    public double x_axis;
    public double y_axis;
    public double z_axis;
    
    public vector3D(double x, double y, double z)
    {
        this.x_axis = x;
        this.y_axis = y;
        this.z_axis = z;
        this.Length = CalculateLength();
    }

    ~vector3D()
    {
        Console.WriteLine("чета происходит.....");
    }

    public static vector3D operator +(vector3D a, vector3D b)
    {
        double vectorSumX = a.x_axis + b.x_axis;
        double vectorSumY = a.y_axis + b.y_axis;
        double vectorSumZ = a.z_axis + b.z_axis;

        return new vector3D(vectorSumX, vectorSumY, vectorSumZ);
    }

    public static vector3D operator -(vector3D a, vector3D b)
    {
        double vectorDiffX = a.x_axis - b.x_axis;
        double vectorDiffY = a.y_axis - b.y_axis;
        double vectorDiffZ = a.z_axis - b.z_axis;

        return new vector3D(vectorDiffX, vectorDiffY, vectorDiffZ);
    }

    public static double operator *(vector3D a, vector3D b)
    {
        double vectorProdX = a.x_axis * b.x_axis;
        double vectorProdY = a.y_axis * b.y_axis;
        double vectorProdZ = a.z_axis * b.z_axis;

        double ScalarProd = vectorProdX + vectorProdY + vectorProdZ;

        return ScalarProd;
    }

    public vector3D Prod(double n, vector3D a)
    {
        double ProdX = n * a.x_axis;
        double ProdY = n * a.y_axis;
        double ProdZ = n * a.z_axis;

        return new vector3D(ProdX, ProdY, ProdZ);
    }

    private double CalculateLength()
    {
        return Math.Sqrt(Math.Pow(x_axis, 2) + Math.Pow(y_axis, 2) + Math.Pow(z_axis, 2));
    }

    public override bool Kollin (vector3D other) 
    {
        double k = Math.Abs(this.x_axis / other.x_axis);
        return (this.x_axis == other.x_axis * k & this.y_axis == other.y_axis * k & this.z_axis == other.z_axis * k);
    }

    public override bool LengthComparison (vector3D other)
    {
        return (this.Length == other.Length);
    }
}

class Program()
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Введите координаты вектора а (x, y, z):");
            double x_axis_a = double.Parse(Console.ReadLine());
            double y_axis_a = double.Parse(Console.ReadLine());
            double z_axis_a = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите координаты вектора b (x, y, z):");
            double x_axis_b = double.Parse(Console.ReadLine());
            double y_axis_b = double.Parse(Console.ReadLine());
            double z_axis_b = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите скаляр n:");
            double n = double.Parse(Console.ReadLine());

            vector3D a = new vector3D(x_axis_a, y_axis_a, z_axis_a);
            vector3D b = new vector3D(x_axis_b, y_axis_b, z_axis_b);

            vector3D Sum = a + b;
            Console.WriteLine("Сумма векторов: ({0}, {1}, {2})", Sum.x_axis, Sum.y_axis, Sum.z_axis);
            vector3D Diff = a - b;
            Console.WriteLine("Разность векторов: ({0}, {1}, {2})", Diff.x_axis, Diff.y_axis, Diff.z_axis);
            double Scalar = a * b;
            Console.WriteLine($"Скалярное произведение векторов: {Scalar}");
            Console.WriteLine("Умножение на скаляр вектора а: ({0}, {1}, {2})", a.Prod(n, a).x_axis, a.Prod(n, a).y_axis, a.Prod(n, a).z_axis);
            Console.WriteLine("Умножение на скаляр вектора b: ({0}, {1}, {2})", b.Prod(n, b).x_axis, b.Prod(n, b).y_axis, b.Prod(n, b).z_axis);
            bool Ravn = a == b;
            Console.WriteLine($"Векторы коллинеарны? {a.Kollin(b)}");
            double Length_a = a.Length;
            Console.WriteLine($"Длина вектора а: {Length_a}");
            double Length_b = b.Length;
            Console.WriteLine($"Длина вектора b: {Length_b}");
            Console.WriteLine($"Длины векторов равны? {a.LengthComparison(b)}");
        }
        catch (Exception) { Console.WriteLine("неправильно набран номер, пожалуйста уточните номер и перезвоните :((("); }
    }
}
    