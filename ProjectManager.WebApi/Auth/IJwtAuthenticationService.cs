using ProjectManager.EntidadesDeNegocio;

namespace ProjectManager.WebApi.Auth
{
    public interface IJwtAuthenticationService
    {
        string Authenticate(Usuario pUsuario);
    }
}
