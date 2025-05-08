public abstract class BaseRepositorio
{
    protected readonly FitConnectContexto _contexto;

    protected BaseRepositorio(FitConnectContexto contexto)
    {
        _contexto = contexto;
    }
}