using minimal_api_cadastro_veiculos.Dominio.Entidades;

namespace Test.Dominio.Entidades;

[TestClass]
public class AdministradorTest
{
    [TestMethod]
    public void TestarGetSetPropriedades()
    {
        // Arrange
        var adm = new Administrador();

        // Act
        adm.id = 1;
        adm.Email = "teste@teste.com.br";
        adm.Senha = "123456";
        adm.Perfil = "Adm";

        // Assert
        Assert.AreEqual(1, adm.id);
        Assert.AreEqual("teste@teste.com.br", adm.Email);
        Assert.AreEqual("123456", adm.Senha);
        Assert.AreEqual("Adm", adm.Perfil);
    }
}