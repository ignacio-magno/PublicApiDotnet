using System.Runtime.Serialization;

namespace Previred.Domain.ApiResponse;

public enum TipoMov
{
    [EnumMember(Value = "sin movimiento")] SinMovimiento,

    [EnumMember(Value = "contrato indefinido")]
    ContratoIndefinido,

    [EnumMember(Value = "cese relacion")] CeseRelacion,

    [EnumMember(Value = "subsidios (licencia medica)")]
    SubsidiosMedicos,

    [EnumMember(Value = "permiso sin goce de sueldo")]
    PermSinGoseSueldo,

    [EnumMember(Value = "accidente de trabajo")]
    AccidenteTrabajo,

    [EnumMember(Value = "contrato a plazo fijo")]
    ContratoPlazFijo,

    [EnumMember(Value = "cambio de contrato plazo fijo a indefinido")]
    CambContrPlazoFijoToIndefinido,

    [EnumMember(Value = "trabajor part-time")]
    TrabPartTime,

    [EnumMember(Value = "otros movimientos de ausentismo")]
    OtrosMovAusentismo,

    [EnumMember(Value = "error")] Error,

    [EnumMember(Value = "incorporacion")] Incorporacion,

    [EnumMember(Value = "suspension contrato pacto ley 21227")]
    SuspensionContratoPactoLey21227,

    [EnumMember(Value = "suspension contrato acto autoridad ley 21227")]
    SuspensionContratoActoAutoridadLey21227,

    [EnumMember(Value = "termino contrato")]
    TerminoContrato,

    [EnumMember(Value = "otros")] Otros,

    [EnumMember(Value = "reduccion jornada")]
    ReduccionJornada,

    [EnumMember(Value = "inicio relacion laboral")]
    InicioRelacionLaboral,
}