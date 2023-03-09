# Documentation

Esta libreria permite leer las cotizaciones de formato pdf pagadas en Previred por el \
empleador, extrae los datos y los asigna a una clase para hacer mas facil su uso.

## Example

```C#
var previredApi = new PreviredApi("Your token api");
var imposition = await previredApi.GetImposition("pathOfFile");
var counEmployees = imposition.Employees.Count;
var monto = imposition.Employees.Sum(x => x.Monto);
Console.WriteLine($"esta cotizacion es pagada a un total de {counEmployees} empleados, un monto de {monto}");

// output: esta cotizacion es pagada a un total de 2 empleados, un monto de 100000
 ```

## Requirements

Esta librería usa de una api para leer los archivos pdf al endpoint,

```http
https://api.ignaciolp.cl/contabilidad/previred/reader-planilla
```

y este endpoint requiere un token, si quieres adquirir tu token puedes hacerlo en el siguiente link:
[Obtener token](https://ignaciolp.cl/apis/token-access)

