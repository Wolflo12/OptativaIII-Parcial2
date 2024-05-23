
using parcial2.Models.Cliente;
using parcial2.Models.Factura;
using parcial2.Models.Sucursal;
using parcial2.Services.Cliente;
using parcial2.Services.Factura;
using parcial2.Services.Sucursal;

string connectionString = "Host=localhost;Username=postgres;Password=bubuchona;Database=postgres;Port=5432";
ClienteService clienteService = new ClienteService(connectionString);
FacturaService facturaService = new FacturaService(connectionString);
SucursalService sucursalService = new SucursalService(connectionString);

Console.WriteLine("Ingrese: \n a - para insertar \n b - para listar");
string opcion = Console.ReadLine();

if (opcion == "a")
{
    clienteService.add(new ClienteModel
    {
        Nombre = "Octavio",
        Apellido = "Fernandez",
        Documento = "456783",
        Direccion = "su casa",
        Mail = "abcd@gmail.com",
        Celular = "123456789",
        Estado = "Activo"
    });

    facturaService.add(new FacturaModel
    {
        Nro_factura = "Nro° 12345678",
        Fecha_hora = new DateTime(2024, 05, 22),
        Total = new decimal(12),
        Total_iva5 = new decimal(22),
        Total_iva10 = new decimal(32),
        Total_iva = new decimal(42),
        Total_letras = "No se contar",
        Sucursal = "Tacumbu",
    });

    sucursalService.add(new SucursalModel
    {
        Direccion = "ni idea",
        Telefono = "82234689",
        Whatsapp = "92348905",
        Mail = "sucursal@gmail.com",
        Estado = "Activo"
    });
}
if (opcion == "b")
{
    clienteService.GetAll().ToList().ForEach(cliente =>
    Console.WriteLine(
        $"Nombre: {cliente.Nombre} \n " +
        $"Apellido: {cliente.Apellido} \n " +
        $"Documento: {cliente.Documento} \n " +
        $"Direccion {cliente.Direccion} \n " +
        $"Mail: {cliente.Mail} \n " +
        $"Celular: {cliente.Celular} \n " +
        $"Estado: {cliente.Estado} \n "
        )
    );

    facturaService.GetAll().ToList().ForEach(factura =>
    Console.WriteLine(
        $"Nombre: {factura.Nro_factura} \n " +
        $"Apellido: {factura.Fecha_hora} \n " +
        $"Documento: {factura.Total} \n " +
        $"Direccion {factura.Total_iva5} \n " +
        $"Mail: {factura.Total_iva10} \n " +
        $"Celular: {factura.Total_iva} \n " +
        $"Estado: {factura.Total_letras} \n " +
        $"Estado: {factura.Sucursal} \n "
        )
    );

    sucursalService.GetAll().ToList().ForEach(sucursal =>
    Console.WriteLine(
        $"Nombre: {sucursal.Direccion} \n " +
        $"Apellido: {sucursal.Telefono} \n " +
        $"Documento: {sucursal.Whatsapp} \n " +
        $"Estado: {sucursal.Estado} \n "
        )
    );
}
