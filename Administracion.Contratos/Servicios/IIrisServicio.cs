using Administracion.Enum;

namespace Administracion.Contratos
{
    public interface IIrisServicio
    {
        byte[] CapturarIris(TipoBiometrico tipoCaptura);
    }
}