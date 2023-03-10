using System.Reflection;

namespace Sii.Domain.Documents;

public static class TypeDocumentFiscalExtensions
{
    public static bool ConstructorReceiveFacturas(this TypeDocumentFiscal typeDocument) =>
        GetAttributes(typeDocument).Factura;

    public static bool ConstructorReceiveFisco(this TypeDocumentFiscal typeDocument) =>
        GetAttributes(typeDocument).Fisco;


    internal static Type GetBuilder(this TypeDocumentFiscal typeDocument) =>
        GetAttributes(typeDocument).TypeBuilder;

    public static bool IsCredito(this TypeDocumentFiscal typeDocument) => GetAttributes(typeDocument).IsCredito;

    public static bool IsDebito(this TypeDocumentFiscal typeDocument) => GetAttributes(typeDocument).IsDebito;

    public static TypeDocumentFiscal ByCodeDebito(int code)
    {
        return FirstTypeDocumentFiscal(j => j.Code == code && j.IsDebito) ??
               throw new ArgumentOutOfRangeException(nameof(code), code, null);
    }

    public static TypeDocumentFiscal ByCodeCredito(int code)
    {
        return FirstTypeDocumentFiscal(j => j.Code == code && j.IsCredito) ??
               throw new ArgumentOutOfRangeException(nameof(code), code, null);
    }


    private static TypeDocumentFiscal? FirstTypeDocumentFiscal(Func<TypeBuilderAttribute, bool> obtainType)
    {
        var values = Enum.GetValues<TypeDocumentFiscal>();
        foreach (var typeDocumentFiscal in values)
        {
            var attributes = GetAttributes(typeDocumentFiscal);
            if (obtainType(attributes)) return typeDocumentFiscal;
       }

        return null;
    }

    private static TypeBuilderAttribute GetAttributes(TypeDocumentFiscal typeDocument)
    {
        var attribute = typeDocument.GetType()
            .GetMember(typeDocument.ToString())
            .First()
            .GetCustomAttribute<TypeBuilderAttribute>();

        if (attribute == null)
            throw new ArgumentOutOfRangeException(nameof(typeDocument), typeDocument, null);
        return attribute;
    }
}