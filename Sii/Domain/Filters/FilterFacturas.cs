using Sii.Domain.ApiParse;

namespace Sii.Domain.Filters;

public class FilterFacturas
{
    List<string>? _rutsExclude;
    List<string>? _razonesSocialesOnly;

    bool _onlyOnTrueCondition = false;
    bool _onlyOnFalseCondition = false;

    private FilterFacturas()
    {
    }

    internal bool Filter(Factura factura)
    {
        if (_onlyOnTrueCondition)
            return FilterOnTrue(factura);

        if (_onlyOnFalseCondition)
            return !FilterOnTrue(factura);

        throw new Exception("FilterFacturas: No se ha definido el tipo de filtro");
    }


    private bool FilterOnTrue(Factura factura)
    {
        if (_razonesSocialesOnly != null && _rutsExclude != null)
            return _rutsExclude.Any(j => string.Equals(factura.Provider.Rut, j)) ||
                   _razonesSocialesOnly.Any(j => factura.Provider.RazonSocial.ToLower().Contains(j.ToLower()));

        if (_razonesSocialesOnly != null)
            return _razonesSocialesOnly.Any(j => factura.Provider.RazonSocial.ToLower().Contains(j.ToLower()));

        if (_rutsExclude != null)
            return _rutsExclude.Any(j => string.Equals(factura.Provider.Rut, j));

        return true;
    }

    public class Builder
    {
        private FilterFacturas _filterFacturas;

        private Builder()
        {
            _filterFacturas = new FilterFacturas();
        }

        public static Builder New() => new Builder();

        public Builder ByRut(string s)
        {
            if (_filterFacturas._rutsExclude == null)
                _filterFacturas._rutsExclude = new List<string>();
            _filterFacturas._rutsExclude.Add(s);
            return this;
        }

        public Builder ByRazonSocial(string s)
        {
            if (_filterFacturas._razonesSocialesOnly == null)
                _filterFacturas._razonesSocialesOnly = new List<string>();
            _filterFacturas._razonesSocialesOnly.Add(s);
            return this;
        }

        public FilterFacturas BuildOnlyTrue()
        {
            _filterFacturas._onlyOnTrueCondition = true;
            return _filterFacturas;
        }

        public FilterFacturas BuildOnlyFalse()
        {
            _filterFacturas._onlyOnFalseCondition = true;
            return _filterFacturas;
        }

        public Builder ByRut(List<string> filtersRut)
        {
            if (_filterFacturas._rutsExclude == null)
                _filterFacturas._rutsExclude = new List<string>();
            _filterFacturas._rutsExclude.AddRange(filtersRut);
            return this;
        }
    }
}